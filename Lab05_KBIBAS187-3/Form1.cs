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
            Boolean digits = false;
            //Int32[] indexes = 0;
            //string path = listBox1.SelectedItem.ToString().Replace("\\\\","\\");
            String[] strings = ReadAllText(File.ReadAllText(path)) // Здесь будет код с ListBox
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strings.Length; i++)
            {
                if (i == (i) + 2 || i == 0)
                {
                    WriteAllText(saveFileDialog1.FileName, strings[i]);

                }
                if (strings[i].Length > 0)
                {
                    using (TextWriter writer = File.CreateText(saveFileDialog1.FileName))
                    {
                        writer.WriteLine(strings[i]);
                    }
                }

                foreach (char c in strings[i])
                {
                    if (Char.IsDigit(c))
                    {
                        digits = true;
                    }
                }

                if (!digits)
                {
                    using (TextWriter writer= CreateText(saveFileDialog1.FileName))
                    {
                        writer.WriteLine(strings[i]);
                    }
                }
            }
            //foreach (string s in strings)
            //{
                
            //    foreach (char c in s)
            //    {
            //        if (Char.IsDigit(c))
            //        {
            //            digits = true;
            //        }
            //    }

            //    if (!digits)
            //    {
            //        using (TextWriter writer = File.CreateText(saveFileDialog1.FileName))
            //        {
            //            writer.WriteLine(s);
            //        }
            //        //File.OpenWrite(saveFileDialog1.FileName);
            //    }
            //}

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
    }
}