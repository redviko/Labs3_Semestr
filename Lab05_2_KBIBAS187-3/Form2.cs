using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab05_2_KBIBAS187_3
{
    public partial class Form2 : Form
    {
        private bool flag; //Бесполезный код по-факту.
        private readonly string pathString; //Переменная под путь

        public Form2(string xmlPathString, ref bool flag) // Передача данных с первой формы путём изменеия конструтора
        {
            InitializeComponent();
            pathString = xmlPathString;
            this.flag = flag;
        }

        public string
            pathToNewFile
        {
            get;
            set;
        } // Переменная для передачи нового пути, если он был изменен в процессе сохранения .XML файла

        public bool Add(ref bool flag)
        {
            try
            {
                if (File.ReadAllLines(pathString).Length != 0)
                {
                    var xDoc = XDocument.Load(pathString);
                    var studElement = xDoc.Element("Студенты");
                    var studsElement = new XElement("Студент");
                    var student = new Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text,
                        int.Parse(maskedTextBox1.Text), dateTimePicker1.Value, textBox5.Text);
                    var studElementNameAttribute = new XAttribute(Student.AttributesNameStrings[0], textBox1.Text);
                    var studSurnameElement = new XElement(Student.AttributesNameStrings[1], textBox2.Text);
                    var studOtchestvoElement = new XElement(Student.AttributesNameStrings[2], textBox3.Text);
                    var studSpecializationElement = new XElement(Student.AttributesNameStrings[3], textBox6.Text);
                    var studCoursElement = new XElement(Student.AttributesNameStrings[4], maskedTextBox1.Text);
                    var studBirthDatElement = new XElement(Student.AttributesNameStrings[5], student[5]);
                    var studPlaceOfBirthElement = new XElement(Student.AttributesNameStrings[6], textBox5.Text);
                    studsElement.Add(studElementNameAttribute, studSurnameElement, studOtchestvoElement,
                        studSpecializationElement, studCoursElement, studBirthDatElement, studPlaceOfBirthElement);
                    studElement.LastNode.AddAfterSelf(studsElement);
                    var save = new SaveFileDialog();
                    if (save.ShowDialog() != DialogResult.Cancel)
                    {
                        Text = studElementNameAttribute.Value;
                        pathToNewFile = save.FileName;
                        xDoc.Save(save.FileName);
                        flag = true;
                        return flag;
                    }

                    MessageBox.Show("Действие отменено");
                    flag = false;
                    return flag;
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