using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LAB8.Properties;

namespace LAB8
{
    internal class TabTwo
    {
        private Panel Box;
        private Pen pen;
        private Brush brush;
        private Color color;
        private Graphics graphics;

        public TabTwo(Panel box)
        {
            Box = box;
            Figure = "Круг";
            pen = new Pen(Brushes.Black, 4f);
            brush = Brushes.Red;
            box.Paint += Paint;
        }

        public string Figure { get; set; }

        public void SetColor(string color)
        {
            switch (color)
            {
                case "Оранжевый":
                    this.color = Color.Orange;
                    break;
                case "Синий":
                    this.color = Color.Blue;
                    break;
                case "Зеленый":
                    this.color = Color.Green;
                    break;
            }
        }

        public void SetBrushType(string type)
        {
            switch (type)
            {
                case "Заливка":
                    brush = new SolidBrush(color);
                    break;
                case "Градиент":
                    brush = new LinearGradientBrush(Box.ClientRectangle, color, Color.White, 0, false);
                    break;
                case "Штрих":
                    brush = new HatchBrush(HatchStyle.Cross, color);
                    break;
                case "Изображение":
                    brush = new TextureBrush((Image) Resources.ResourceManager.GetObject("Image1"));
                    break;
            }
        }

        private Rectangle GetBounds()
        {
            return new Rectangle(Box.Location.X + 5, Box.Location.Y + 5, Box.Width - 10, Box.Height - 10);
        }

        private void Paint(object sender, EventArgs args)
        {
            graphics = Box.CreateGraphics();
            graphics.Clear(Color.White);
            switch (Figure)
            {
                case "Круг":
                    DrawRound();
                    break;
                case "Эллипс":
                    DrawElips();
                    break;
                case "Сектор":
                    DrawSector();
                    break;
                case "Треугольник":
                    DrawTriangle();
                    break;
                case "Прямоугольник":
                    DrawRectangle();
                    break;
                case "Многоугольник":
                    DrawPolygon();
                    break;
            }
        }

        public void DrawRound()
        {
            var b = GetBounds();
            var size = Math.Min(b.Width, b.Height);
            b.Width = size;
            b.Height = size;
            graphics.FillEllipse(brush, b);
            graphics.DrawEllipse(pen, b);
        }

        public void DrawElips()
        {
            var b = GetBounds();
            graphics.FillEllipse(brush, b);
            graphics.DrawEllipse(pen, b);
        }

        public void DrawSector()
        {
            var b = GetBounds();
            var size = Math.Min(b.Width, b.Height);
            b.Width = size;
            b.Height = size;
            graphics.FillPie(brush, b, 0, 300);
            graphics.DrawPie(pen, b, 0, 300);
        }

        public void DrawTriangle()
        {
            var b = GetBounds();
            var p = new Point[3];
            p[0] = new Point(b.X + b.Width, b.Y + b.Height);
            p[1] = new Point(b.X + b.Width / 2, b.Y);
            p[2] = new Point(b.X, b.Y + b.Height);
            graphics.FillPolygon(brush, p);
            graphics.DrawPolygon(pen, p);
        }

        public void DrawRectangle()
        {
            var b = GetBounds();
            graphics.FillRectangle(brush, b);
            graphics.DrawRectangle(pen, b);
        }

        public void DrawPolygon()
        {
            var b = GetBounds();
            var p = new Point[6];
            p[0] = new Point(b.X, b.Y);
            p[1] = new Point(b.X + b.Width / 2, b.Y);
            p[2] = new Point(b.X + b.Width, b.Y + b.Height / 2);
            p[3] = new Point(b.X + b.Width, b.Y + b.Height);
            p[4] = new Point(b.X + b.Width / 2, b.Y + b.Height);
            p[5] = new Point(b.X, b.Y + b.Height / 2);
            graphics.FillPolygon(brush, p);
            graphics.DrawPolygon(pen, p);
        }
    }
}