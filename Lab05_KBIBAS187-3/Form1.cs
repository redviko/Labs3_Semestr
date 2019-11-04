using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.IO.File;

namespace Lab05_KBIBAS187_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Int32[] indexes = 0;
            if (saveFileDialog1.ShowDialog()== DialogResult.Cancel)
            {
                return;
            }
            string[] path=new string[10];
            Boolean digits = false;
            if (listBox1.SelectedItems==null)
            {
                return;
            }
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                path[i] = listBox1.SelectedItems[i].ToString();
                path[i]=path[i].Replace("\\", "/");
                String[] strings = ReadAllText(path[i]) // Здесь будет код с ListBox
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < strings.Length; j++)
                {
                    if ((j == (j) + 2 || j == 0) && !digits)
                    {
                        AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                        digits = !digits;
                    }
                    if (strings[j].Length > 0 && !digits)
                    {
                        AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                        digits = !digits;
                    }


                    if (!digits)
                    {
                        foreach (char c in strings[j])
                        {
                            if (Char.IsDigit(c))
                            {
                                digits = true;
                            }
                        }
                        if (!digits)
                        {
                            AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                        }
                    }

                    digits = false;
                }
            }

            
            MessageBox.Show($"Файл сохранён");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string filename = openFileDialog1.FileName;
            string filetext = ReadAllText(filename);
            MessageBox.Show($"Файл прочитан");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string catalogname = folderBrowserDialog1.SelectedPath;
            foreach (string s in Directory.GetFiles(catalogname))
            {
                listBox1.Items.Add(s);
            }
            MessageBox.Show($"В листбок помещены названия файлов с каталога");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string[] pathStrings=new string[10];
            Int32 count = 0;
            for (var i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                pathStrings[i] = listBox1.SelectedItems[i].ToString();
                pathStrings[i] = pathStrings[i].Replace("\\", "/");
                String[] strings = ReadAllText(pathStrings[i]).Split(new []{'\r','\n'},StringSplitOptions.RemoveEmptyEntries);
                count = 0;
                foreach (var s in strings)
                {
                    count += s.Length;
                }

                MessageBox.Show($"Строк в файле:{pathStrings[i].Length}\nКоличество символов в файле:{count}\nКоличество символов в последней строке{strings[strings.Length-1].Length}");
            }
        }
    }
}