using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LAB8
{
    public class Bounds
    {
        public Bounds(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        public int X { get; }
        public int Y { get; }
        public int W { get; }
        public int H { get; }
        public Point Begin => new Point(X, Y);
        public Point End => new Point(X + W, Y + H);
        public Point LeftBottom => new Point(X, Y + H);
        public Point RightTop => new Point(X + W, Y);
    }

    internal class TabOne
    {
        private Panel Box;
        private double _kX;
        private double _kY;
        private Pen _penOne;
        private Pen _penTwo;
        private int _dirX;
        private Graphics _graphics;

        public TabOne(Panel box)
        {
            Box = box;
            _kX = 0.2;
            _kY = 0.2;
            _dirX = 5;
            _penOne = new Pen(Brushes.Black, 2f);
            _penTwo = new Pen(Brushes.Black, 2f) {DashStyle = DashStyle.Dot};
            box.Paint += Paint;
        }

        public Bounds GetBounds()
        {
            return new Bounds(0, 0, Math.Max(0, Box.Size.Width - 8), Math.Max(0, Box.Size.Height - 8));
        }

        public void DrawSurface()
        {
            var b = GetBounds();
            var dX = b.X + (int) (b.W * _kX);
            var dY = b.Y + (int) (b.H * _kY);
            var p1 = new Point[4];
            p1[0] = new Point(b.X + dX, b.Y);
            p1[1] = new Point(b.RightTop.X, b.Y);
            p1[2] = new Point(b.RightTop.X - dX, b.Y + dY);
            p1[3] = new Point(b.X, b.Y + dY);
            var vY = (int) (b.H * (1 - _kY));
            var p2 = new Point[4];
            for (var i = 0; i < 4; i++)
            {
                p2[i].Y = p1[i].Y + vY;
                p2[i].X = p1[i].X;
            }

            var p_s = new Point[4];
            p_s[0] = p2[1];
            p_s[1] = p2[2];
            p_s[2] = p1[3];
            p_s[3] = p1[0];
            _graphics.FillPolygon(Brushes.Aquamarine, p_s);
            _graphics.DrawLine(_penOne, p1[0], p1[1]);
            _graphics.DrawLine(_penOne, p1[1], p1[2]);
            _graphics.DrawLine(_penOne, p1[2], p1[3]);
            _graphics.DrawLine(_penOne, p1[3], p1[0]);
            _graphics.DrawLine(_penTwo, p2[0], p2[1]);
            _graphics.DrawLine(_penOne, p2[1], p2[2]);
            _graphics.DrawLine(_penOne, p2[2], p2[3]);
            _graphics.DrawLine(_penTwo, p2[3], p2[0]);
            _graphics.DrawLine(_penOne, p1[1], p2[1]);
            _graphics.DrawLine(_penOne, p1[2], p2[2]);
            _graphics.DrawLine(_penOne, p1[3], p2[3]);
            _graphics.DrawLine(_penTwo, p1[0], p2[0]);
        }

        public void Paint(object sender, EventArgs args) //Привязка графики
        {
            _graphics = Box.CreateGraphics();
            DrawSurface();
        }

        public void Move()
        {
            if (Box.Location.X + _dirX < 0) _dirX = Math.Abs(_dirX);
            else if (Box.Location.X + _dirX + Box.Width >= Box.Parent.ClientSize.Width) _dirX = -Math.Abs(_dirX);
            Box.Location = new Point(Box.Location.X + _dirX, Box.Location.Y);
        }
    }
}