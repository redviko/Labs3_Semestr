using System;
using System.Drawing;
using System.Windows.Forms;

namespace LAB8
{
    internal class TabThree
    {
        private Panel _box;
        private Bitmap _bmp;
        private bool _drawing;
        private Point _lastMouse;

        public TabThree(Panel box)
        {
            this._box = box;
            _bmp = new Bitmap(box.Width, box.Height);
        }

        public Color color { set; get; }

        public void MouseDown(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
            {
                _drawing = true;
                _lastMouse = args.Location;
            }
        }

        public void MouseMove(object sender, MouseEventArgs args)
        {
            if (_drawing)
            {
                using (var g = Graphics.FromImage(_bmp))
                {
                    g.DrawLine(new Pen(color), _lastMouse, args.Location);
                    _box.CreateGraphics().DrawLine(new Pen(color), _lastMouse, args.Location);
                }

                _lastMouse = args.Location;
            }
        }

        public void MouseUp(object sender, MouseEventArgs args)
        {
            if (args.Button == MouseButtons.Left)
            {
                _drawing = false;
                _box.BackgroundImage = _bmp;
            }
        }

        public void OpenFile()
        {
            using (var dialog = new OpenFileDialog {Filter = "IMG |*.jpg;*.jpeg;*.png;"})
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        _bmp = new Bitmap(dialog.FileName);
                        _box.BackgroundImage = _bmp;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось открыть файл!");
                    }
            }
        }

        public void SaveFile()
        {
            using (var dialog = new SaveFileDialog {Filter = "JPEG |*.jpeg"})
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        _bmp.Save(dialog.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удалось сохранить файл!");
                    }
            }
        }

        public void FromBuffer()
        {
            if (!Clipboard.ContainsImage()) return;
            _bmp = new Bitmap(Clipboard.GetImage());
            _box.BackgroundImage = _bmp;
        }

        public void ToBuffer()
        {
            Clipboard.SetImage(_bmp);
        }
    }
}