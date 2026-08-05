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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TUIO;

namespace TangibleCartSimulator
{

    public partial class CartDemo : Form, TuioListener, IGestureListener
    {
        private TuioClient client;
        private Dictionary<long, TuioObject> objectList;


        // --- Gesture and Circular Menu Fields ---
        private GestureSocketClient gestureClient;
        private CircularMenu circularMenu;
        private Point handPoint; // The current location of the user's hand

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

        public static int width, height;
        private int window_width = 800;
        private int window_height = 600;

        // Cart Zone rectangle, defined as a fraction of the window (0..1)
        // Here: bottom 35% of the screen, full width
        private RectangleF cartZoneNormalized = new RectangleF(0.0f, 0.65f, 1.0f, 0.35f);



        // --- Socket server fields ---
        private TcpListener listener;
        private Thread listenerThread;
        private const int SOCKET_PORT = 6000;

        public CartDemo(int tuioPort)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            // Create and add a button column for the "Remove" action
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "actionColumn";
            removeButtonColumn.HeaderText = "Action";
            removeButtonColumn.Text = "Remove";
            removeButtonColumn.UseColumnTextForButtonValue = true; // Use the Text property for the button text
            removeButtonColumn.FlatStyle = FlatStyle.Flat;

            // Add the button column to the grid
            this.shoppingCartGrid.Columns.Add(removeButtonColumn);

            // Remove the old text-based "Action" column you created in the designer
            // It might be named "actionColumn" or "Action", so we check for both.
            if (this.shoppingCartGrid.Columns.Contains("actionColumn"))
            {
                this.shoppingCartGrid.Columns.Remove("actionColumn");
            }
            if (this.shoppingCartGrid.Columns.Contains("Action"))
            {
                this.shoppingCartGrid.Columns.Remove("Action");
            }

            width = window_width;
            height = window_height;
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

            // --- Initialize Gesture Client and Circular Menu ---
            gestureClient = new GestureSocketClient();
            gestureClient.AddListener(this);
            gestureClient.Connect();

            circularMenu = new CircularMenu();
            circularMenu.OnMenuItemSelected += CircularMenu_OnMenuItemSelected;
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
                    // Update the user label on the UI
                    if (this.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate { userNameLabel.Text = "User: " + currentUser; });
                    }
                    else
                    {
                        userNameLabel.Text = "User: " + currentUser;
                    }
                    return;
                }

                switch (command)
                {
                    case "add_milk":
                        // Triggered when the Bluetooth script identifies this user's device
                        AddToCart("Milk");
                        lastTuioProduct = "Milk";
                        break;

                    case "add_to_cart":
                        if (lastTuioProduct != null)
                            AddToCart(lastTuioProduct);
                        else
                            Console.WriteLine("No product selected yet - place a TUIO marker in the Cart Zone first.");
                        break;

                    case "remove_from_cart":
                        if (lastTuioProduct != null)
                            RemoveFromCart(lastTuioProduct);
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
            UpdateCartDisplay();
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
            UpdateCartDisplay();
        }


        private void UpdateCartDisplay()
        {
            // This ensures our UI updates are thread-safe
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(UpdateCartDisplay));
                return;
            }

            lock (cartLock)
            {
                shoppingCartGrid.Rows.Clear(); // Clear the grid before redrawing

                float subtotal = 0;

                foreach (var productName in cart.Keys)
                {
                    int quantity = cart[productName];
                    Product productInfo = null;

                    // Find the product details from our catalog
                    foreach (var p in catalog.Values)
                    {
                        if (p.Name == productName)
                        {
                            productInfo = p;
                            break;
                        }
                    }

                    if (productInfo != null)
                    {
                        float itemSubtotal = productInfo.Price * quantity;
                        subtotal += itemSubtotal;

                        // --- THIS IS THE CORRECTED PART ---
                        // We now add the values directly to the grid's rows.
                        shoppingCartGrid.Rows.Add(
                            productInfo.Name,
                            quantity.ToString(),
                            $"${productInfo.Price:F2}", // Unit Price
                            $"${itemSubtotal:F2}",    // Sub Total
                            "Remove"                  // Placeholder for the 'Action' column
                        );
                    }
                }

                // Calculate totals
                float tax = subtotal * 0.13f;
                float total = subtotal + tax;

                // Update the summary labels
                subtotalLabelval.Text = $"${subtotal:F2}";
                taxLabelval.Text = $"${tax:F2}";
                totalLabelval.Text = $"${total:F2}";
            }
        }


        private void Checkout()
        {
            float total = GetTotal();
            Console.WriteLine("CHECKOUT - Total: " + total);
            MessageBox.Show($"Checkout complete! Your total is ${total:F2}", "Checkout");
            lock (cartLock) { cart.Clear(); }
            UpdateCartDisplay();
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
                    // Open the circular menu at the object's position
                    List<string> menuItems = new List<string> { "Info", "Share", "Delete" };
                    circularMenu.OpenMenu(new Point((int)(o.X * simulationPanel.Width), (int)(o.Y * simulationPanel.Height)), menuItems);
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
            simulationPanel.Invalidate();
        }



        private void Form_Closing(object sender, CancelEventArgs e)
        {
            client.removeTuioListener(this);
            client.disconnect();
            if (listener != null) listener.Stop();
            Environment.Exit(0);
        }


        // ================== GESTURE LISTENER CALLBACKS ==================

        // This is the main method for tracking the hand
        public void OnSkeletonUpdate(double timestamp, IList<SkeletonLandmark> landmarks)
        {
            // Find the index finger tip landmark from the list of all landmarks
            SkeletonLandmark indexFinger = null;
            foreach (var landmark in landmarks)
            {
                // MediaPipe's index finger tip is landmark #8
                if (landmark.Id == 8)
                {
                    indexFinger = landmark;
                    break;
                }
            }

            if (indexFinger != null)
            {
                // Convert normalized coordinates (0-1) to screen coordinates
                handPoint = new Point((int)(indexFinger.X * simulationPanel.Width), (int)(indexFinger.Y * simulationPanel.Height));

                // Update the circular menu with the new hand position
                if (circularMenu.IsOpen)
                {
                    circularMenu.UpdateCursor(handPoint);
                }
            }
        }

        // The rest of these methods are required by the interface.
        // We can leave them empty for now as they are not needed for the circular menu.

        public void OnGestureRecognized(double timestamp, RecognizedGesture gesture)
        {
            // e.g. could be used for "pinch" or "fist" gestures later
        }

        public void OnEmotionUpdate(string label, float confidence, string difficultyHint)
        {
            // Not needed for the circular menu
        }

        public void OnYoloDetection(IList<YoloObject> detections)
        {
            // Not needed for the circular menu
        }

        public void OnGazeUpdate(float x, float y)
        {
            // Not needed for the circular menu
        }

        public void OnProximityUpdate(string status)
        {
            // Not needed for the circular menu
        }
        private void CircularMenu_OnMenuItemSelected(string selectedItem)
        {
            MessageBox.Show("You selected: " + selectedItem);
            // We will add logic here later to actually do something
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearCartButton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before clearing
            var confirmResult = MessageBox.Show("Are you sure you want to clear the entire cart?",
                                             "Confirm Clear",
                                             MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                lock (cartLock)
                {
                    cart.Clear();
                }
                Console.WriteLine("Cart cleared by user.");
                UpdateCartDisplay(); // Update the UI to show the empty cart
            }
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            Checkout();
        }

        private void subtotalLabelval_Click(object sender, EventArgs e)
        {

        }

        private void taxLabelval_Click(object sender, EventArgs e)
        {

        }

        private void totalLabelval_Click(object sender, EventArgs e)
        {

        }

        private void userIconPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void prevItemButton_Click(object sender, EventArgs e)
        {

        }

        private void activeItemPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void nextItemButton_Click(object sender, EventArgs e)
        {

        }

        private void simulationPanel_Paint(object sender, PaintEventArgs e)
        {
            // This is the code that actually draws the images.
            // It only runs because refresh() called simulationPanel.Invalidate().

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Panel panel = sender as Panel;
            if (panel == null) return;

            // First, clear the panel to prevent smearing from old frames
            g.Clear(panel.BackColor);

            // --- Draw the "Cart Zone" outline (from your old code) ---
            RectangleF cartZoneRectF = new RectangleF(
                cartZoneNormalized.X * panel.Width,
                cartZoneNormalized.Y * panel.Height,
                cartZoneNormalized.Width * panel.Width,
                cartZoneNormalized.Height * panel.Height
            );
            using (SolidBrush zoneBrush = new SolidBrush(Color.FromArgb(40, 0, 180, 0)))
            {
                g.FillRectangle(zoneBrush, cartZoneRectF);
            }
            using (Pen zonePen = new Pen(Color.LightGreen, 2))
            {
                g.DrawRectangle(zonePen, Rectangle.Round(cartZoneRectF));
            }

            // --- Draw the TUIO objects (from your old code) ---
            lock (objectList)
            {
                foreach (TuioObject tuioObject in objectList.Values)
                {
                    float x = tuioObject.X * panel.Width;
                    float y = tuioObject.Y * panel.Height;
                    float angle = tuioObject.Angle * 180.0f / (float)Math.PI;

                    Product product = null;
                    if (catalog.ContainsKey(tuioObject.SymbolID))
                    {
                        product = catalog[tuioObject.SymbolID];
                    }

                    if (product != null && product.Icon != null)
                    {
                        Image icon = product.Icon;
                        int iconSize = 80;

                        var gstate = g.Save();
                        g.TranslateTransform(x, y);
                        g.RotateTransform(angle);
                        g.DrawImage(icon, -iconSize / 2, -iconSize / 2, iconSize, iconSize);
                        g.Restore(gstate);
                    }
                }
            }

            // --- Draw the Circular Menu ---
            if (circularMenu.IsOpen)
            {
                circularMenu.Draw(g);
            }

            // --- Draw the Hand Cursor ---
            using (SolidBrush handBrush = new SolidBrush(Color.FromArgb(150, 255, 0, 0)))
            {
                g.FillEllipse(handBrush, handPoint.X - 10, handPoint.Y - 10, 20, 20);
            }
        }

        private void shoppingCartGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and not the header
            if (e.RowIndex < 0) return;

            // Check if the click was on our button column
            if (shoppingCartGrid.Columns[e.ColumnIndex].Name == "actionColumn")
            {
                // Get the name of the product from the "Item" column of the clicked row
                string productName = shoppingCartGrid.Rows[e.RowIndex].Cells["itemColumn"].Value.ToString();

                // Call our existing RemoveFromCart method
                RemoveFromCart(productName);
            }
        }

        public static void Main(string[] argv)
        {
            int tuioPort = 3333;
            CartDemo app = new CartDemo(tuioPort);
            Application.Run(app);
        }
    }
}