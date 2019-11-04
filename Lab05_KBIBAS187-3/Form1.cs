using System;
using System.IO;
using System.Linq;
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
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            var path = new string[10];
            var digits = false;
            if (listBox1.SelectedItems == null) return;
            for (var i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                path[i] = listBox1.SelectedItems[i].ToString();
                path[i] = path[i].Replace("\\", "/");
                var strings = ReadAllText(path[i]) // Здесь будет код с ListBox
                    .Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < strings.Length; j++)
                {
                    if ((j == j + 2 || j == 0) && !digits)
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
                        foreach (var c in strings[j])
                            if (char.IsDigit(c))
                                digits = true;
                        if (!digits) AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                    }

                    digits = false;
                }
            }

            MessageBox.Show("Файл сохранён");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            var filename = openFileDialog1.FileName;
            var filetext = ReadAllText(filename);
            MessageBox.Show("Файл прочитан");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
            var catalogname = folderBrowserDialog1.SelectedPath;
            foreach (var s in Directory.GetFiles(catalogname)) listBox1.Items.Add(s);
            MessageBox.Show("В листбок помещены названия файлов с каталога");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var pathStrings = new string[10];
            var count = 0;
            for (var i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                pathStrings[i] = listBox1.SelectedItems[i].ToString();
                pathStrings[i] = pathStrings[i].Replace("\\", "/");
                var strings = ReadAllText(pathStrings[i])
                    .Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                count = 0;
                foreach (var s in strings) count += s.Length;
                MessageBox.Show(
                    $"Строк в файле:{pathStrings[i].Length}\nКоличество символов в файле:{count}\nКоличество символов в последней строке{strings[strings.Length - 1].Length}");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            var path = openFileDialog1.FileName;
            path = path.Replace("\\", "/");
            var strings = ReadAllText(path).Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in strings) listBox1.Items.Add(s);
            if (listBox1.SelectedItems != null)
                foreach (string s in listBox1.SelectedItems)    
                    AppendAllText(saveFileDialog1.FileName, s);
            var sortered = strings.OrderBy(a => a.First());
            if (sortered.Count() != 0)
                foreach (var s in sortered)
                    AppendAllText(saveFileDialog1.FileName, s);
            //for (var i = strings.Length - 1; i >= 0; i--)
            //{
            //    AppendAllText(saveFileDialog1.FileName,strings[i]+"\r\n");
            //} 

            //listBox1.Items.Clear();
        }
    }
}