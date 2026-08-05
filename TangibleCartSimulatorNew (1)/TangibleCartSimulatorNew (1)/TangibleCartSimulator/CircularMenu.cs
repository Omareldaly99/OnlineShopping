using System;
using System.Collections.Generic;
using System.Drawing;

namespace TangibleCartSimulator
{
    public class CircularMenu
    {

        // Configuration
        private readonly int DwellTimeMs = 1500;
        private readonly Font MenuFont = new Font("Arial", 14.0f, FontStyle.Bold);
        private readonly SolidBrush TextBrush = new SolidBrush(Color.White);
        private readonly SolidBrush HoverBrush = new SolidBrush(Color.FromArgb(100, 0, 150, 255));
        private readonly Pen CirclePen = new Pen(Color.FromArgb(150, 150, 150), 2);
        private readonly Pen HoverPen = new Pen(Color.FromArgb(0, 150, 255), 4);

        // State
        public bool IsOpen { get; private set; }
        private List<string> menuItems = new List<string>();
        private Point centerPoint;
        private int radius = 150;
        private int itemRadius = 40;

        // Hover & Dwell Logic
        private int hoveredIndex = -1;
        private DateTime hoverStartTime;
        public event Action<string> OnMenuItemSelected;

        public void OpenMenu(Point center, List<string> items)
        {
            this.centerPoint = center;
            this.menuItems = items;
            this.IsOpen = true;
            this.hoveredIndex = -1;
        }

        public void CloseMenu()
        {
            this.IsOpen = false;
        }

        public void UpdateCursor(Point cursorPoint)
        {
            if (!IsOpen) return;

            int oldIndex = hoveredIndex;
            hoveredIndex = -1;

            for (int i = 0; i < menuItems.Count; i++)
            {
                Point itemCenter = GetItemPosition(i);
                double distance = Math.Sqrt(Math.Pow(cursorPoint.X - itemCenter.X, 2) + Math.Pow(cursorPoint.Y - itemCenter.Y, 2));
                if (distance < itemRadius)
                {
                    hoveredIndex = i;
                    break;
                }
            }

            if (hoveredIndex != oldIndex)
            {
                if (hoveredIndex != -1)
                {
                    hoverStartTime = DateTime.Now;
                }
            }
            else
            {
                if (hoveredIndex != -1)
                {
                    if ((DateTime.Now - hoverStartTime).TotalMilliseconds >= DwellTimeMs)
                    {
                        OnMenuItemSelected?.Invoke(menuItems[hoveredIndex]);
                        CloseMenu();
                    }
                }
            }
        }

        public void Draw(Graphics g)
        {
            if (!IsOpen) return;

            for (int i = 0; i < menuItems.Count; i++)
            {
                Point itemCenter = GetItemPosition(i);
                Rectangle itemBounds = new Rectangle(itemCenter.X - itemRadius, itemCenter.Y - itemRadius, itemRadius * 2, itemRadius * 2);

                // Draw hover effect
                if (i == hoveredIndex)
                {
                    g.FillEllipse(HoverBrush, itemBounds);
                    g.DrawEllipse(HoverPen, itemBounds);

                    // Draw dwell progress
                    double elapsed = (DateTime.Now - hoverStartTime).TotalMilliseconds;
                    float sweepAngle = (float)(360 * (elapsed / DwellTimeMs));
                    if (sweepAngle > 0)
                    {
                        g.DrawArc(new Pen(Color.White, 5), itemBounds, -90, sweepAngle);
                    }
                }
                else
                {
                    g.DrawEllipse(CirclePen, itemBounds);
                }

                // Draw text
                SizeF textSize = g.MeasureString(menuItems[i], MenuFont);
                PointF textPos = new PointF(itemCenter.X - textSize.Width / 2, itemCenter.Y - textSize.Height / 2);
                g.DrawString(menuItems[i], MenuFont, TextBrush, textPos);
            }
        }

        private Point GetItemPosition(int index)
        {
            float angle = (float)(index * (2 * Math.PI) / menuItems.Count);
            int x = centerPoint.X + (int)(radius * Math.Cos(angle));
            int y = centerPoint.Y + (int)(radius * Math.Sin(angle));
            return new Point(x, y);
        }
    }
}



