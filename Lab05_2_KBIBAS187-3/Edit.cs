using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab05_2_KBIBAS187_3
{
    public partial class Edit : Form
    {
        private readonly string _pathString;

        public Edit(string pathString)
        {
            _pathString = pathString;
            InitializeComponent();
            textBox1.Text = Student.Student1[0];
            textBox2.Text = Student.Student1[1];
            textBox3.Text = Student.Student1[2];
            textBox4.Text = Student.Student1[3];
            textBox5.Text = Student.Student1[6];
            maskedTextBox1.Text = Student.Student1[4];
            dateTimePicker1.Value = Student.Student1.BirthDateTime;
            _pathString = pathString;
        }

        public bool IsSuccess { get; set; }
        private bool flag { get; set; }

        private bool EditStudent(ref bool isclosing)
        {
            try
            {
                var flag = false;
                if (textBox1.Text != Student.Student1[0] || textBox2.Text != Student.Student1[1] ||
                    textBox3.Text != Student.Student1[2] || textBox4.Text != Student.Student1[3] ||
                    textBox5.Text != Student.Student1[6] || maskedTextBox1.Text != Student.Student1[4] ||
                    dateTimePicker1.Value != Student.Student1.BirthDateTime)
                {
                    flag = true;
                    if (isclosing)
                    {
                        var dialog = MessageBox.Show("Вы хотите сохранить изменения?", "Закрытие формы",
                            MessageBoxButtons.OKCancel);
                        if (dialog == DialogResult.OK)
                        {
                            Student.Student1[0] = textBox1.Text;
                            Student.Student1[1] = textBox2.Text;
                            Student.Student1[2] = textBox3.Text;
                            Student.Student1[3] = textBox4.Text;
                            Student.Student1[6] = textBox5.Text;
                            Student.Student1[4] = maskedTextBox1.Text;
                            Student.Student1.BirthDateTime = dateTimePicker1.Value;
                            if (File.ReadAllLines(_pathString).Length != 0)
                            {
                                var xDoc = XDocument.Load(_pathString);
                                var studElement = xDoc.Element("Студенты");
                                Student.Student1[1] = textBox2.Text;
                                Student.Student1[2] = textBox3.Text;
                                Student.Student1[3] = textBox4.Text;
                                Student.Student1[6] = textBox5.Text;
                                Student.Student1[4] = maskedTextBox1.Text;
                                Student.Student1.BirthDateTime = dateTimePicker1.Value;
                                foreach (var xElement in xDoc.Elements("Студенты").Elements("Студент"))
                                    if (xElement.FirstAttribute.Value == Student.Student1[0])
                                    {
                                        Student.Student1[0] = textBox1.Text;
                                        xElement.FirstAttribute.Value = Student.Student1[0];
                                        var surnameElement = xElement.Element(Student.AttributesNameStrings[1]);
                                        surnameElement.Value = Student.Student1[1];
                                        var otchestvoElement = xElement.Element(Student.AttributesNameStrings[2]);
                                        otchestvoElement.Value = Student.Student1[2];
                                        var specializationElement = xElement.Element(Student.AttributesNameStrings[3]);
                                        specializationElement.Value = Student.Student1[3];
                                        var coursElement = xElement.Element(Student.AttributesNameStrings[4]);
                                        coursElement.Value = Student.Student1[4];
                                        var birthDateElement = xElement.Element(Student.AttributesNameStrings[5]);
                                        birthDateElement.Value = Student.Student1[5];
                                        var placeofBirthElement = xElement.Element(Student.AttributesNameStrings[6]);
                                        placeofBirthElement.Value = Student.Student1[6];
                                        break;
                                    }

                                xDoc.Save(_pathString);
                                IsSuccess = true;
                                return flag;
                            }

                            MessageBox.Show("Файл пуст");
                            IsSuccess = false;
                            return false;
                        }

                        MessageBox.Show("Вы отменили изменения");
                        IsSuccess = false;
                        return false;
                    }

                    if (File.ReadAllLines(_pathString).Length != 0)
                    {
                        var xDoc = XDocument.Load(_pathString);
                        var studElement = xDoc.Element("Студенты");
                        Student.Student1[1] = textBox2.Text;
                        Student.Student1[2] = textBox3.Text;
                        Student.Student1[3] = textBox4.Text;
                        Student.Student1[6] = textBox5.Text;
                        Student.Student1[4] = maskedTextBox1.Text;
                        Student.Student1.BirthDateTime = dateTimePicker1.Value;
                        foreach (var xElement in xDoc.Elements("Студенты").Elements("Студент"))
                            if (xElement.FirstAttribute.Value == Student.Student1[0])
                            {
                                Student.Student1[0] = textBox1.Text;
                                xElement.FirstAttribute.Value = Student.Student1[0];
                                var surnameElement = xElement.Element(Student.AttributesNameStrings[1]);
                                surnameElement.Value = Student.Student1[1];
                                var otchestvoElement = xElement.Element(Student.AttributesNameStrings[2]);
                                otchestvoElement.Value = Student.Student1[2];
                                var specializationElement = xElement.Element(Student.AttributesNameStrings[3]);
                                specializationElement.Value = Student.Student1[3];
                                var coursElement = xElement.Element(Student.AttributesNameStrings[4]);
                                coursElement.Value = Student.Student1[4];
                                var birthDateElement = xElement.Element(Student.AttributesNameStrings[5]);
                                birthDateElement.Value = Student.Student1[5];
                                var placeofBirthElement = xElement.Element(Student.AttributesNameStrings[6]);
                                placeofBirthElement.Value = Student.Student1[6];
                                break;
                            }

                        xDoc.Save(_pathString);
                        IsSuccess = true;
                        return flag;
                    }

                    MessageBox.Show("Файл пуст");
                    IsSuccess = false;
                    return false;
                }

                MessageBox.Show("Вы ничего не изменили держу в курсе");
                IsSuccess = false;
                return flag;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!flag)
            {
                var isclosing = true;
                EditStudent(ref isclosing);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = !flag;
                var isclosing = false;
                EditStudent(ref isclosing);
                Close();
            }
        }
    }
}

//XElement studsElement = new XElement("Студент");
////Student student = new Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text, int.Parse(textBox7.Text), dateTimePicker1.Value, textBox5.Text);
//XAttribute studElementNameAttribute =
//    new XAttribute(Student.AttributesNameStrings[0], Student.Student1[0]);
//XElement studSurnameElement =
//    new XElement(Student.AttributesNameStrings[1], Student.Student1[1]);
//XElement studOtchestvoElement =
//    new XElement(Student.AttributesNameStrings[2], Student.Student1[2]);
//XElement studSpecializationElement =
//    new XElement(Student.AttributesNameStrings[3], Student.Student1[3]);
//XElement studCoursElement = new XElement(Student.AttributesNameStrings[4], Student.Student1[4]);
//XElement studBirthDatElement =
//    new XElement(Student.AttributesNameStrings[5], Student.Student1[5]);
//XElement studPlaceOfBirthElement =
//    new XElement(Student.AttributesNameStrings[6], Student.Student1[6]);
//studsElement.Add(studElementNameAttribute, studSurnameElement, studOtchestvoElement,
//    studSpecializationElement, studCoursElement, studBirthDatElement, studPlaceOfBirthElement);
//studElement.LastNode.AddAfterSelf(studsElement);