using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_KBIBAS187_3_Slonchak
{
    public partial class Form1 : Form
    {
        public Boolean ThreeAndfour { get; set; }
        public  Int32 Case { get; set; }
        public Int32 Case2 { get; set; }
        public  Boolean IsEnterControl { get; set; }
        public Boolean IsAltX { get; set; }
        public Boolean IsAltI { get; set; }
        public Int32 I { get; set; } = 0;
        public Font[] Fonts = new[] {new Font("Times new Roman", 8, FontStyle.Regular),new Font("Courier New", 8, FontStyle.Regular),new Font("Segoe UI", 8, FontStyle.Regular)};
        public Form1()
        {
            InitializeComponent();
            Case = 1;
            Case2=1;
        }

        private void Reset()
        {
            Controls.Clear();
            DoubleClick -= Form1_DoubleClick;
            KeyDown -= Form1_KeyDown;
            KeyUp -= Form1_KeyUp;
            MouseClick -= Form1_MouseClick;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!ThreeAndfour)
            {
                button2.Visible = !button2.Visible;
                ThreeAndfour = !ThreeAndfour;
                button3.Visible = true;
            }
            else
            {
                button3.Visible = !button3.Visible;
                ThreeAndfour = !ThreeAndfour;
                button2.Visible = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Location=new Point(button1.Location.X,button1.Location.Y-10);
        }

        private void Loc(Int32 X,Int32 Y)
        {
            X = Math.Max(0, X);
            Y = Math.Max(0, Y);
            X = Math.Min(X, Screen.PrimaryScreen.WorkingArea.Width - Size.Width);
            Y = Math.Min(Y, Screen.PrimaryScreen.WorkingArea.Height - Size.Height);
            Size= new Size(X,Y);
            //button1.Location=new Point(X,Y);
        }

        private void Button1_LocationChanged(object sender, EventArgs e)
        {
            if (button1.Location.X>ClientSize.Width)
            {
                button1.Location=new Point(this.ClientSize.Width-10,button1.Location.Y);
            }
            else if (button1.Location.Y>ClientSize.Height)
            {
                button1.Location=new Point(button1.Location.X,ClientSize.Height-10);
            }
            else if (button1.Location.Y<0)
            {
                button1.Location=new Point(button1.Location.X,button1.Location.Y+10);
            }
            else if (button1.Location.X<0)
            {
                button1.Location=new Point(button1.Location.X+10,button1.Location.Y);
            }
            //Loc(button1.Location.X, button1.Location.Y);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys==Keys.Shift))
            {
                Font = new Font(Font.FontFamily, Font.Size - 1, FontStyle.Regular);
            }
            else if (ModifierKeys==Keys.Control)
            {
                Font = Fonts[I];
                I++;
                I %= 3;
            }
            else
            {
                Font = new Font(Font.FontFamily, Font.Size + 1, FontStyle.Regular);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsAltI)
            {
                Reset();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            switch (Case2)
            {
                case 1:
                    FormBorderStyle = FormBorderStyle.None;
                    Case2++;
                    break;
                case 2:
                    FormBorderStyle = FormBorderStyle.Fixed3D;
                    Case2++;
                    break;
                case 3:
                    FormBorderStyle = FormBorderStyle.FixedDialog;
                    Case2++;
                    break;
                case 4:
                    FormBorderStyle = FormBorderStyle.Sizable;
                    Case2++;
                    break;
                case 5:
                    FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    Case2 = 1;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.X)
            {
                IsAltX = true;
            }

            if (e.Alt && e.KeyCode == Keys.I)
            {
                IsAltI = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt&&e.KeyCode==Keys.X)
            {
                IsAltX = false;
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                IsEnterControl = false;
            }
            if (e.Alt&&e.KeyCode==Keys.I)
            {
                IsAltI = false;
            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (IsAltX)
            {
                Close();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            Button button= sender as Button;
            string str = "";
            switch (button.Name)
            {
                case "button1": str = "переключает видимость 2-й и 3-й (видна только одна из кнопок поочереди; "; break;
                case "button2": str = "Сдвигает первую кнопку на 10 пикселей вверх"; break;
                case "button3": str = "a. 1-увеличивает, 2-уменьшает, 3-переключает по кругу (из 3-х) шрифты на форме"; break;
                case "button4": str = "перебирает тип рамки (по кругу из 5-ти)."; break;
            }
            toolStripStatusLabel1.Text = $"Кнопка: {button.Name} делает: {str}";
        }

        private void Button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                Button3_Click(sender, e);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Loc(Size.Width,Size.Height);
        }
    }
}
