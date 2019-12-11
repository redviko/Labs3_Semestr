using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab07_KBIBAS187_3_4_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Boolean flag { get; set; } = false;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (ModifierKeys)
            {
                case Keys.Shift when e.KeyCode == Keys.Delete:
                    textBox1.Text = String.Empty;
                    break;
                case Keys.Shift:
                    listBox1.Items.Clear();
                    break;
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.DoDragDrop(textBox1.Text, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add(e.Data.GetData(DataFormats.Text)).ToString();
            textBox1.BackColor = DefaultBackColor;
        }

        private void textBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect== DragDropEffects.Copy)
            {
                textBox1.BackColor= Color.Blue;
            }
            else
            {
                textBox1.BackColor = DefaultBackColor;
            }
        }

        private void listBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                listBox1.BackColor = Color.Red;
            }
            else
            {
                listBox1.BackColor = DefaultBackColor;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys== Keys.Control&&e.KeyCode== Keys.D)
            {
                flag = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            flag = false;
        }
    }
}
