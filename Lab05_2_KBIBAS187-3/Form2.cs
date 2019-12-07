using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
namespace Lab05_2_KBIBAS187_3
{
    public partial class Form2 : Form
    {
        private string pathString;
        private Boolean  flag;
        public String pathToNewFile { get; set; }

        public Form2(string xmlPathString, ref bool flag)
        {
            InitializeComponent();
            pathString = xmlPathString;
            this.flag = flag;

        }

        public bool Add(ref Boolean flag)
        {
            try
            {
                if (File.ReadAllLines(pathString).Length != 0)
                {
                    XDocument xDoc = XDocument.Load(pathString);
                    XElement studElement = xDoc.Element("Студенты");
                    XElement studsElement = new XElement("Студент");
                    Student student = new Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text, int.Parse(textBox7.Text), dateTimePicker1.Value, textBox5.Text);
                    XAttribute studElementNameAttribute = new XAttribute(Student.AttributesNameStrings[0], textBox1.Text);
                    XElement studSurnameElement = new XElement(Student.AttributesNameStrings[1], textBox2.Text);
                    XElement studOtchestvoElement = new XElement(Student.AttributesNameStrings[2], textBox3.Text);
                    XElement studSpecializationElement = new XElement(Student.AttributesNameStrings[3], textBox6.Text);
                    XElement studCoursElement = new XElement(Student.AttributesNameStrings[4], textBox7.Text);
                    XElement studBirthDatElement = new XElement(Student.AttributesNameStrings[5], student[5]);
                    XElement studPlaceOfBirthElement = new XElement(Student.AttributesNameStrings[6], textBox5.Text);
                    studsElement.Add(studElementNameAttribute, studSurnameElement, studOtchestvoElement, studSpecializationElement, studCoursElement, studBirthDatElement, studPlaceOfBirthElement);
                    studElement.LastNode.AddAfterSelf(studsElement);
                    SaveFileDialog save = new SaveFileDialog();
                    if (save.ShowDialog() != DialogResult.Cancel)
                    {
                        Text = studElementNameAttribute.Value;
                        pathToNewFile = save.FileName;
                        xDoc.Save(save.FileName);
                        flag = true;
                        return flag;
                    }
                    else
                    {
                        MessageBox.Show("Действие отменено");
                        flag = false;
                        return flag;
                    }
                }

                flag = false;
                return flag;

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                flag = false;
                return flag;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Add(ref flag))
            {
                MessageBox.Show("Дело сделано");
                Close();
            }
            else
            {
                MessageBox.Show("Действие не выполнено");
            }
        }
    }
}
