using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LAB8
{
    internal class TabFour
    {
        private Panel _box;
        private Timer _timer;
        private Graphics _graphics;

        public TabFour(Panel box)
        {
            this._box = box;
            this._box.Paint += Paint;
            for (var i = 0; i < 3; i++) Add();
            _timer = new Timer {Interval = 100};
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        public void Add()
        {
            new Square(_box.ClientRectangle);
            Square.UpdateBounds(_box.ClientRectangle);
        }

        public void TimerTick(object sender, EventArgs args)
        {
            _graphics = _box.CreateGraphics();
            Square.DrawAll(_graphics);
            UpdateBounds();
        }

        public void Paint(object sender, PaintEventArgs args)
        {
            //Square.DrawAll(args.Graphics);
        }

        public void UpdateBounds()
        {
            Square.UpdateBounds(_box.ClientRectangle);
        }
    }

    internal class Square
    {
        private static readonly List<Square> elements = new List<Square>();
        private static readonly Random rnd = new Random();
        private int dX, dY;

        public Square(Rectangle bounds)
        {
            Bounds = bounds;
            elements.Add(this);
            X = rnd.Next(bounds.X, bounds.X + bounds.Width);
            Y = rnd.Next(bounds.Y, bounds.Y + bounds.Height);
            dY = rnd.Next(-7, 6);
            dX = rnd.Next(-7, 6);
            if (dY == 0) dY = 7;
            if (dX == 0) dX = 7;
            Width = 100;
            Height = 85;
            pen = new Pen(Brushes.BlueViolet, 3f);
        }

        private Rectangle Bounds { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public Pen pen { get; private set; }

        public static void DrawAll(Graphics g)
        {
            g.Clear(Color.White);
            foreach (var elem in elements)
            {
                elem.Move();
                g.DrawRectangle(elem.pen, elem.GetRectangle());
            }
        }

        public static void UpdateBounds(Rectangle bounds)
        {
            foreach (var elem in elements) elem.Bounds = bounds;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        public bool CheckIntersect()
        {
            foreach (var elem in elements)
                if (elem != this && elem.GetRectangle().IntersectsWith(GetRectangle()))
                    return true;
            return false;
        }

        public void Move()
        {
            if (X + dX + Width >= Bounds.X + Bounds.Width) dX = -Math.Abs(dX);
            else if (X + dX < 0) dX = Math.Abs(dX);
            if (Y + dY + Height >= Bounds.Y + Bounds.Height) dY = -Math.Abs(dY);
            else if (Y + dY < 0) dY = Math.Abs(dY);
            X += dX;
            Y += dY;
            X = Math.Max(0, Math.Min(Bounds.X + Bounds.Width - Width, X));
            Y = Math.Max(0, Math.Min(Bounds.Y + Bounds.Height - Height, Y));
            if (CheckIntersect()) pen = new Pen(Brushes.Aquamarine);
            else pen = new Pen(Brushes.BlueViolet, 3f);
        }
    }
}