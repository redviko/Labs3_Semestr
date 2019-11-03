using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab04_KBIBAS187_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox2 = new CheckBox();
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(390, 31);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(80, 17);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            Controls.Add(checkBox2);
            checkBox2.CheckStateChanged += CheckBox2_CheckChanged;
            checkBox1 = new CheckBox();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(356, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(80, 17);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            Controls.Add(checkBox1);
            checkBox1.CheckedChanged += CheckBox1_CheckChanged;
        }

        //public Boolean args { get; set; }
        public int Index { get; set; } = 0;

        //public  SystemMenu
        public Font[] Fonts { get; } =
        {
            new Font("Times New Roman", 8), new Font("Trebuchet MS", 8), new Font("Microsoft Tai Le", 8),
            new Font("Regurgitation", 8), new Font("Yu Gothic", 8), new Font("Arial", 8),
            new Font("Microsoft Sans Serif", 8), new Font("Javanese Text", 8)
        };

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedstring = comboBox1.Text;
            foreach (Control control in Controls)
                switch (selectedstring)
                {
                    //Font.Style = FontStyle.Regular;
                    case "Times New Roman":
                        control.Font = Fonts[0];
                        break;
                    case "Trebuchet MS":
                        control.Font = Fonts[1];
                        break;
                    case "Microsoft Tai Le":
                        control.Font = Fonts[2];
                        break;
                    case "Regurgitation":
                        control.Font = Fonts[3];
                        break;
                    case "Yu Gothic":
                        control.Font = Fonts[4];
                        break;
                    case "Arial":
                        control.Font = Fonts[5];
                        break;
                    case "Microsoft Sans Serif":
                        control.Font = Fonts[6];
                        break;
                    case "Javanese Text":
                        control.Font = Fonts[7];
                        break;
                    //case
                }
        }

        private void CheckBox2_CheckChanged(object sender, EventArgs e)
        {
            //CheckBox checkBox = sender as CheckBox;
            ControlBox = !ControlBox;
        }

        private void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox) sender;
            if (checkBox.Checked) Text = "";
            else Text = "Form1";
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0) listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void ToolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Text = "";
            if (e.KeyCode == Keys.Enter)
                if (toolStripTextBox1.TextLength != 0)
                {
                    listBox1.Items.Add(toolStripTextBox1.Text);
                    toolStripTextBox1.Text = "";
                }
        }

        private void ToolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8)) e.Handled = true;
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e) //Проверка на количество чётных и вывод их суммы
        {
            var a = 0;
            var count = 0;
            var sum = 0;
            foreach (var item in listBox1.Items)
            {
                a = int.Parse(item.ToString());
                if (a % 2 == 0)
                {
                    count++;
                    sum += a;
                }
            }

            if (count > 0)
            {
                listBox2.Items.Add($"Сумма:{sum}");
                listBox2.Items.Add($"Чётных {count}");
            }
            else if (listBox1.Items.Count != 0)
            {
                listBox2.Items.Add("Чётных нет, но вы держитесь.");
            }
            else
            {
                listBox2.Items.Add("Может в ListBox что-то добавить?");
            }
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)  //Проверка на чётность среди 5 чисел с конца
        {
            int integer;
            var evencount = false;
            var reseti = false;
            if (listBox1.Items.Count >= 5)
            {
                for (var i = listBox1.Items.Count - 1; i >= listBox1.Items.Count - 5; i--)
                {
                    int.TryParse(listBox1.Items[i].ToString(), out integer);
                    if (integer % 2 == 0 && !evencount) evencount = true;
                    if (evencount && !reseti)
                    {
                        i = listBox1.Items.Count - 1;
                        reseti = true;
                    }

                    if (evencount) listBox2.Items.Add(listBox1.Items[i]);
                }

                if (!evencount) listBox2.Items.Add("Среди 5-ти чисел нет ни одного чётного");
            }
            else
            {
                listBox2.Items.Add("Не хватает чисел.");
            }
        }

        private void ToolStripTextBox2_KeyDown(object sender, KeyEventArgs e) //Для ввода через TextBox строк
        {
            if (e.KeyCode == Keys.Enter)
                if (toolStripTextBox2.TextLength != 0)
                    listBox3.Items.Add(toolStripTextBox2.Text);
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e) //Проверка на последнюю русскую букву
        {
            var str = false;
            foreach (string striItem in listBox3.Items)
                if (striItem.ToUpper()[striItem.Length - 1] >= 'А' && striItem.ToUpper()[striItem.Length - 1] <= 'Я')
                {
                    listBox2.Items.Add(striItem);
                    str = true;
                }

            if (!str) listBox2.Items.Add("Нет таких строк");
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)  //На чётные удваиваю пробел на нечётные убираю
        {
            if (listBox3.Items.Count >= 2)
            {
                for (var i = 0; i < listBox3.Items.Count; i += 2)
                    listBox2.Items.Add(listBox3.Items[i].ToString().Replace(" ", ""));
                for (var i = 1; i < listBox3.Items.Count; i +=2)
                    listBox2.Items.Add(listBox3.Items[i].ToString().Replace(" ", "  "));
               
            }
            else if (listBox3.Items.Count == 1)
            {
                listBox2.Items.Add(listBox3.Items[0].ToString().Replace(" ", ""));
            }
            else
            {
                listBox2.Items.Add("Не из чего выбирать");
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e) //Событие для переключения Радио
        {
            var radio = (RadioButton) sender;
            switch (radio.Text)
            {
                case "Рамка 1":
                    FormBorderStyle = FormBorderStyle.None;
                    break;
                case "Рамка 2":
                    FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                case "Рамка 3":
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    break;
                case "Рамка 4":
                    FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    break;
                case "Рамка 5":
                    FormBorderStyle = FormBorderStyle.Sizable;
                    break;
                case "Рамка 6":
                    FormBorderStyle = FormBorderStyle.SizableToolWindow;
                    break;
            }
        }
    }
}