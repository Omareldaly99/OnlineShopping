/*
    Tangible Grocery Cart Simulator - Cart Demo
    Based on TUIO C# Demo (reacTIVision project)

    This combines:
      1) TUIO object tracking -> Cart Zone (place a marker in the zone = add product)
      2) A TCP socket server -> receives gesture commands from the Python app
         ("add_to_cart", "remove_from_cart", "checkout") and updates the SAME cart

    Both input methods (TUIO markers and MediaPipe gestures) drive one shared
    cart state, so you can compare them for your HCI project.
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TUIO;

public class Product
{
    public string Name;
    public float Price;
    public Image Icon;
    public Product(string name, float price, Image icon) { Name = name; Price = price; Icon = icon; }
}

public class CartDemo : Form, TuioListener
{
    private TuioClient client;
    private Dictionary<long, TuioObject> objectList;

    // Tracks whether each object (by SessionID) is currently inside the Cart Zone,
    // so we only fire Add/Remove once per crossing, not every frame.
    private Dictionary<long, bool> inZoneState = new Dictionary<long, bool>();

    // --- Product catalog: map SymbolID -> Product (edit these to your real products) ---
    private Dictionary<int, Product> catalog;

    private Image LoadIcon(string fileName)
    {
        string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Images", fileName);
        if (System.IO.File.Exists(path))
            return Image.FromFile(path);
        return null; // falls back to a plain circle if the image is missing
    }

    // --- Cart state (shared between TUIO and gesture/socket input) ---
    private Dictionary<string, int> cart = new Dictionary<string, int>(); // product name -> quantity
    private readonly object cartLock = new object();

    // --- Current user, set by the Bluetooth discovery script over the socket ---
    private string currentUser = "Guest";

    // --- Last product touched via a TUIO marker; gestures act on this product ---
    private string lastTuioProduct = null;

    // --- Whether to show the "Selected Product" box in the middle of the screen ---
    private bool showSelectedBox = false;

    public static int width, height;
    private int window_width = 800;
    private int window_height = 600;

    // Cart Zone rectangle, defined as a fraction of the window (0..1)
    // Here: bottom 35% of the screen, full width
    private RectangleF cartZoneNormalized = new RectangleF(0.0f, 0.65f, 1.0f, 0.35f);

    Font font = new Font("Arial", 12.0f);
    Font titleFont = new Font("Arial", 14.0f, FontStyle.Bold);
    SolidBrush fntBrush = new SolidBrush(Color.White);
    SolidBrush bgrBrush = new SolidBrush(Color.FromArgb(0, 0, 64));
    SolidBrush objBrush = new SolidBrush(Color.FromArgb(200, 120, 0));
    SolidBrush zoneBrush = new SolidBrush(Color.FromArgb(60, 0, 180, 0));
    Pen zonePen = new Pen(Color.LightGreen, 2);

    // --- Socket server fields ---
    private TcpListener listener;
    private Thread listenerThread;
    private const int SOCKET_PORT = 6000;

    public CartDemo(int tuioPort)
    {
        width = window_width;
        height = window_height;

        this.ClientSize = new Size(width, height);
        this.Name = "CartDemo";
        this.Text = "Tangible Grocery Cart Simulator";

        this.Closing += new CancelEventHandler(Form_Closing);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.DoubleBuffer, true);

        objectList = new Dictionary<long, TuioObject>(128);

        // Build product catalog with icons (Images/milk.png, Images/bread.png, Images/eggs.png
        // must sit next to the .exe - copy the Images folder into bin\Debug when you build)
        catalog = new Dictionary<int, Product>()
        {
            { 0, new Product("Milk",  35.0f, LoadIcon("milk.png")) },
            { 1, new Product("Bread", 15.0f, LoadIcon("bread.png")) },
            { 2, new Product("Eggs",  60.0f, LoadIcon("eggs.png")) },
        };

        // Start TUIO client
        client = new TuioClient(tuioPort);
        client.addTuioListener(this);
        client.connect();

        // Start socket server for Python gesture commands
        StartSocketServer();
    }

    // ================== SOCKET SERVER (Python -> C#) ==================
    private void StartSocketServer()
    {
        listenerThread = new Thread(() =>
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, SOCKET_PORT);
                listener.Start();
                Console.WriteLine("Socket server listening on port " + SOCKET_PORT);

                while (true)
                {
                    TcpClient pyClient = listener.AcceptTcpClient();
                    Console.WriteLine("Python client connected.");
                    Thread clientThread = new Thread(() => HandleClient(pyClient));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Socket server error: " + e.Message);
            }
        });
        listenerThread.IsBackground = true;
        listenerThread.Start();
    }

    private void HandleClient(TcpClient pyClient)
    {
        NetworkStream stream = pyClient.GetStream();
        byte[] buffer = new byte[1024];

        try
        {
            while (true)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break; // client disconnected

                string command = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                Console.WriteLine("Received command: " + command);

                HandleGestureCommand(command);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Client handler error: " + e.Message);
        }
    }

    // Maps a gesture command string to a cart action.
    // This must run on the UI thread since it triggers a repaint.
    private void HandleGestureCommand(string command)
    {
        this.Invoke((MethodInvoker)delegate
        {
            if (command.StartsWith("user:"))
            {
                // Message from the Bluetooth discovery script, e.g. "user:Ahmed"
                currentUser = command.Substring("user:".Length).Trim();
                Console.WriteLine("User identified via Bluetooth: " + currentUser);
                Invalidate();
                return;
            }

            switch (command)
            {
                case "select_milk":
                    // Bluetooth identified the user - just select their favorite product,
                    // don't add it to the cart yet. The gesture (add/remove) does that.
                    lastTuioProduct = "Milk";
                    showSelectedBox = true;
                    Console.WriteLine("Milk selected via Bluetooth (not added yet).");
                    break;

                case "add_to_cart":
                    if (lastTuioProduct != null)
                    {
                        AddToCart(lastTuioProduct);
                        showSelectedBox = false; // hide the box once the gesture acts on it
                    }
                    else
                        Console.WriteLine("No product selected yet - place a TUIO marker in the Cart Zone first.");
                    break;

                case "remove_from_cart":
                    if (lastTuioProduct != null)
                    {
                        RemoveFromCart(lastTuioProduct);
                        showSelectedBox = false; // hide the box once the gesture acts on it
                    }
                    else
                        Console.WriteLine("No product selected yet - place a TUIO marker in the Cart Zone first.");
                    break;

                case "checkout":
                    Checkout();
                    break;

                default:
                    Console.WriteLine("Unknown command: " + command);
                    break;
            }
            Invalidate(); // trigger repaint
        });
    }

    // ================== CART LOGIC (shared) ==================
    private void AddToCart(string productName)
    {
        lock (cartLock)
        {
            if (!cart.ContainsKey(productName)) cart[productName] = 0;
            cart[productName]++;
        }
        Console.WriteLine(productName + " added. Qty: " + cart[productName]);
    }

    private void RemoveFromCart(string productName)
    {
        lock (cartLock)
        {
            if (cart.ContainsKey(productName))
            {
                cart[productName]--;
                if (cart[productName] <= 0) cart.Remove(productName);
            }
        }
        Console.WriteLine(productName + " removed.");
    }

    private void Checkout()
    {
        float total = GetTotal();
        Console.WriteLine("CHECKOUT - Total: " + total);
        lock (cartLock) { cart.Clear(); }
    }

    private float GetTotal()
    {
        float total = 0;
        lock (cartLock)
        {
            foreach (var kvp in cart)
            {
                Product p = FindProductByName(kvp.Key);
                if (p != null) total += p.Price * kvp.Value;
            }
        }
        return total;
    }

    private Product FindProductByName(string name)
    {
        foreach (var p in catalog.Values)
            if (p.Name == name) return p;
        return null;
    }

    // ================== TUIO CALLBACKS ==================
    public void addTuioObject(TuioObject o)
    {
        lock (objectList) { objectList.Add(o.SessionID, o); }
        inZoneState[o.SessionID] = false;
    }

    public void updateTuioObject(TuioObject o)
    {
        // Normalized coordinates: o.X, o.Y are already 0..1
        bool nowInZone = cartZoneNormalized.Contains(o.X, o.Y);
        bool wasInZone = inZoneState.ContainsKey(o.SessionID) && inZoneState[o.SessionID];

        if (nowInZone && !wasInZone)
        {
            // Marker just entered the Cart Zone -> Add
            if (catalog.ContainsKey(o.SymbolID))
            {
                lastTuioProduct = catalog[o.SymbolID].Name;
                AddToCart(lastTuioProduct);
            }
        }
        else if (!nowInZone && wasInZone)
        {
            // Marker just left the Cart Zone -> Remove
            if (catalog.ContainsKey(o.SymbolID))
            {
                lastTuioProduct = catalog[o.SymbolID].Name;
                RemoveFromCart(lastTuioProduct);
            }
        }

        inZoneState[o.SessionID] = nowInZone;
    }

    public void removeTuioObject(TuioObject o)
    {
        lock (objectList) { objectList.Remove(o.SessionID); }
        inZoneState.Remove(o.SessionID);
    }

    // Cursor/Blob callbacks required by TuioListener interface but unused here
    public void addTuioCursor(TuioCursor c) { }
    public void updateTuioCursor(TuioCursor c) { }
    public void removeTuioCursor(TuioCursor c) { }
    public void addTuioBlob(TuioBlob b) { }
    public void updateTuioBlob(TuioBlob b) { }
    public void removeTuioBlob(TuioBlob b) { }

    public void refresh(TuioTime frameTime)
    {
        Invalidate();
    }

    // ================== DRAWING ==================
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        g.FillRectangle(bgrBrush, new Rectangle(0, 0, width, height));

        // Draw Cart Zone
        Rectangle zoneRect = new Rectangle(
            (int)(cartZoneNormalized.X * width),
            (int)(cartZoneNormalized.Y * height),
            (int)(cartZoneNormalized.Width * width),
            (int)(cartZoneNormalized.Height * height)
        );
        g.FillRectangle(zoneBrush, zoneRect);
        g.DrawRectangle(zonePen, zoneRect);
        g.DrawString("CART ZONE", titleFont, fntBrush, new PointF(zoneRect.X + 10, zoneRect.Y + 5));

        // Draw TUIO objects (markers) using product icons
        lock (objectList)
        {
            foreach (TuioObject tobj in objectList.Values)
            {
                int ox = tobj.getScreenX(width);
                int oy = tobj.getScreenY(height);
                int size = height / 8;

                Product p = catalog.ContainsKey(tobj.SymbolID) ? catalog[tobj.SymbolID] : null;

                if (p != null && p.Icon != null)
                {
                    g.DrawImage(p.Icon, ox - size / 2, oy - size / 2, size, size);
                }
                else
                {
                    // fallback if no icon image was found
                    g.FillEllipse(objBrush, ox - size / 2, oy - size / 2, size, size);
                }

                string label = p != null ? p.Name : tobj.SymbolID.ToString();
                g.DrawString(label, font, fntBrush, new PointF(ox - 15, oy - size / 2 - 20));
            }
        }

        // Draw Cart panel (top-right)
        int panelX = width - 240;
        int panelY = 10;

        g.DrawString("User: " + currentUser, font, fntBrush, new PointF(panelX, panelY));
        g.DrawString("Selected (for gestures): " + (lastTuioProduct ?? "none"), font, fntBrush, new PointF(panelX, panelY + 20));
        g.DrawString("YOUR CART", titleFont, fntBrush, new PointF(panelX, panelY + 45));
        int lineY = panelY + 78;

        lock (cartLock)
        {
            foreach (var kvp in cart)
            {
                Product p = FindProductByName(kvp.Key);
                if (p != null && p.Icon != null)
                    g.DrawImage(p.Icon, panelX, lineY - 4, 26, 26);

                string line = kvp.Key + " x" + kvp.Value + (p != null ? "  (" + (p.Price * kvp.Value) + ")" : "");
                g.DrawString(line, font, fntBrush, new PointF(panelX + 32, lineY));
                lineY += 30;
            }
        }

        g.DrawString("Total: " + GetTotal(), titleFont, fntBrush, new PointF(panelX, lineY + 10));

        // --- Prominent "Selected Product" display in the middle of the screen ---
        if (lastTuioProduct != null && showSelectedBox)
        {
            Product selected = FindProductByName(lastTuioProduct);
            int boxW = 220;
            int boxH = 220;
            int boxX = (width - boxW) / 2;
            int boxY = (height - boxH) / 2 - 60; // slightly above center, above the Cart Zone

            using (SolidBrush selectedBg = new SolidBrush(Color.FromArgb(180, 20, 20, 40)))
            {
                g.FillRectangle(selectedBg, boxX, boxY, boxW, boxH);
            }
            g.DrawRectangle(new Pen(Color.White, 2), boxX, boxY, boxW, boxH);

            if (selected != null && selected.Icon != null)
                g.DrawImage(selected.Icon, boxX + (boxW - 140) / 2, boxY + 20, 140, 140);

            string caption = "Selected: " + lastTuioProduct;
            SizeF textSize = g.MeasureString(caption, titleFont);
            g.DrawString(caption, titleFont, fntBrush, new PointF(boxX + (boxW - textSize.Width) / 2, boxY + boxH - 35));
        }
    }

    private void Form_Closing(object sender, CancelEventArgs e)
    {
        client.removeTuioListener(this);
        client.disconnect();
        if (listener != null) listener.Stop();
        Environment.Exit(0);
    }

    public static void Main(String[] argv)
    {
        int tuioPort = 3333;
        CartDemo app = new CartDemo(tuioPort);
        Application.Run(app);
    }
}
