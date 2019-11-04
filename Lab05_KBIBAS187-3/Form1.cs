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
            String[] strings = File.ReadAllText(saveFileDialog1.FileName)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            MessageBox.Show($"Файл сохранён");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
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