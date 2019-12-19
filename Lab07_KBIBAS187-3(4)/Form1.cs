using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lab07_KBIBAS187_3_4_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String DraggedText { get; set; }
        public bool flag { get; set; }

        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys key);
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Delete) textBox1.Text = string.Empty;
            else if (e.Shift) listBox1.Items.Clear();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                if (!string.IsNullOrEmpty(textBox1.SelectedText))
                    textBox1.DoDragDrop(textBox1.SelectedText, DragDropEffects.Copy);
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox1.SelectedText))
                    textBox1.DoDragDrop(textBox1.SelectedText, DragDropEffects.Move);
                //textBox1.Text=String.Empty;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add(e.Data.GetData(DataFormats.Text)).ToString();
            textBox1.BackColor = DefaultBackColor;
            if (!Copy)
            {
                textBox1.SelectedText = String.Empty; 
            }
        }

        private void textBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //switch (e.Effect)
            //{
            //    case DragDropEffects.Move:
            //        textBox1.BackColor = Color.Blue;
            //        break;
            //    case DragDropEffects.Copy:
            //        textBox1.BackColor = Color.Red;
            //        break;
            //    default:
            //        textBox1.BackColor = DefaultBackColor;
            //        break;
            //}
        }

        private void listBox1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                listBox1.BackColor = Color.Red;
            }
            else if (e.Effect == DragDropEffects.Copy)
            {
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.D) flag = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            flag = false;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
            listBox1.BackColor = DefaultBackColor;
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (flag) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.Move;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             

               

                switch (label1.Text)
                {
                    case "Сохранить":
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Действие отменено");
                            return;
                        }
                        if (listBox1.Items.Count != 0)
                            foreach (string s in listBox1.Items)
                                File.AppendAllText(saveFileDialog1.FileName, s);
                        else MessageBox.Show("Листбокс пустой");
                        label1.Text = "Читать текст";
                        break;
                    }
                    case "Читать текст":
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Действие отменено");
                            return;
                        }
                        if (File.ReadAllLines(openFileDialog1.FileName).Length != 0)
                        {
                            foreach (var line in File.ReadAllLines(openFileDialog1.FileName)) listBox1.Items.Add(line);
                            label1.Text = "Сохранить";
                        }

                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        private void textBox1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (e.EscapePressed)
            {
                e.Action = DragAction.Cancel;
                textBox1.BackColor = DefaultBackColor;
                
            }
            else
            {
                if (GetKeyState(Keys.LControlKey)<0&&GetKeyState(Keys.D)<0)
                {
                    Copy = true;
                    textBox1.BackColor = Color.Red;
                }
                else
                {
                    Copy = false;
                    textBox1.BackColor=Color.Blue;
                }
            }
        }

        public Boolean Selected { get; set; }
        public Boolean Copy { get; set; }
        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (textBox1.SelectedText.Length > 0)
            {
                //StartInd = textBox1.SelectionStart;
                DraggedText = textBox1.SelectedText;
                Selected = true;
                textBox1.BackColor = DefaultBackColor;
            }
        }
    }
}