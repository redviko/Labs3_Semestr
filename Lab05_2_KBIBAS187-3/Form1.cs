using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.IO.File;
using System.Xml.Linq;

namespace Lab05_2_KBIBAS187_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckFile(ref OpenFileDialog open)
        {
            if (!Exists(open.FileName))
            {
                MessageBox.Show("Ошибка, файла не существует");
                return false;
            }
            else if (ReadAllLines(open.FileName).Length==0)
            {
                MessageBox.Show("Файл пустой палучаеца");
                return false;
            }
            else
            {
                return true;
            }
                
        }

        private bool CreateXML(ref XDocument xDoc,ref Student student)
        {
            XElement studElement=new XElement("Студент");
            XAttribute studNameAttribute= new XAttribute("Имя", student.Name);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void загрузкаВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show("Действие отменено");
                    return;
                }
                if (CheckFile(ref openFileDialog1))
                {
                    XDocument xDocument;
                    //string text = ReadAllText(openFileDialog1.FileName);
                    String[] strings = ReadAllText(openFileDialog1.FileName).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    String[] dateStrings = strings[5].Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    DateTime date = new DateTime(int.Parse(dateStrings[2]), int.Parse(dateStrings[1]), int.Parse(dateStrings[0]));
                    Student student = new Student(strings[0], strings[1], strings[2], strings[3], int.Parse(strings[4]), date, strings[6]);
                }
                else
                {
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show($"Ошибка: {errorException.Message}");
            }
        }
    }
}
