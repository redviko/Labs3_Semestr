using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.IO.File;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Lab05_2_KBIBAS187_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<string> XmPathList { get; set; } = new List<string>();

        private bool StudentsFrom1Course() //Определить количество студентов с одного курса
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    var count = 0;
                    for (listBox1.SelectedIndex = 0;; listBox1.SelectedIndex++)
                    {
                        if (listBox1.Items.Count - 1 == listBox1.SelectedIndex)
                        {
                            count++;
                            break;
                        }

                        count++;
                    }
                    //foreach (string item in listBox1.Items)
                    //{
                    //    if (label4.Text == course.ToString())
                    //    {
                    //        count++;
                    //    }
                    //    listBox1.SelectedIndex++;
                    //}

                    if (count != 0)
                    {
                        MessageBox.Show($"Количество стдуентов в одного курса = {count}");
                        return true;
                    }

                    MessageBox.Show("Нет людей с одного курса");
                    return false;
                }

                MessageBox.Show("Листбокс пуст");
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }
        }

        private bool CheckFile(ref OpenFileDialog open) //Проверка .txt файла
        {
            if (!Exists(open.FileName))
            {
                MessageBox.Show("Ошибка, файла не существует");
                return false;
            }

            if (ReadAllLines(open.FileName).Length == 0)
            {
                MessageBox.Show("Файл пустой палучаеца");
                return false;
            }

            return true;
        }

        private bool CreateXML(ref XDocument xDoc, ref List<Student> students) //Создание .XML
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return false;
            }

            try
            {
                var studentsElement = new XElement("Студенты");
                foreach (var student in students)
                {
                    var studElement = new XElement("Студент");
                    var studElementNameAttribute = new XAttribute(Student.AttributesNameStrings[0], student[0]);
                    var studSurnameElement = new XElement(Student.AttributesNameStrings[1], student[1]);
                    var studOtchestvoElement = new XElement(Student.AttributesNameStrings[2], student[2]);
                    var studSpecializationElement = new XElement(Student.AttributesNameStrings[3], student[3]);
                    var studCoursElement = new XElement(Student.AttributesNameStrings[4], student[4]);
                    var studBirthDatElement = new XElement(Student.AttributesNameStrings[5], $"{student[5]}");
                    var studPlaceOfBirthElement = new XElement(Student.AttributesNameStrings[6], student[6]);
                    studElement.Add(studElementNameAttribute, studSurnameElement, studOtchestvoElement,
                        studSpecializationElement, studCoursElement, studBirthDatElement, studPlaceOfBirthElement);
                    studentsElement.Add(studElement);
                }

                xDoc.Add(studentsElement);
                xDoc.Save(saveFileDialog1.FileName);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка : {e.Message}");
                return false;
            }
        }

        private bool ReadXML(ref XDocument xDocument, ref Student student) //Чтение .XML
        {
            try
            {
                xDocument = XDocument.Load(openFileDialog1.FileName);
                foreach (var xElement in xDocument.Elements("Студенты").Elements("Студент"))
                    if (xElement.FirstAttribute.Value == listBox1.SelectedItem.ToString())
                    {
                        var surnameElement = xElement.Element(Student.AttributesNameStrings[1]);
                        var otchestvoElement = xElement.Element(Student.AttributesNameStrings[2]);
                        var specializationElement = xElement.Element(Student.AttributesNameStrings[3]);
                        var coursElement = xElement.Element(Student.AttributesNameStrings[4]);
                        var birthDateElement = xElement.Element(Student.AttributesNameStrings[5]);
                        var placeofBirthElement = xElement.Element(Student.AttributesNameStrings[6]);
                        if (specializationElement != null && coursElement != null && birthDateElement != null &&
                            placeofBirthElement != null)
                        {
                            label2.Text = specializationElement.Value;
                            label4.Text = coursElement.Value;
                            label6.Text = birthDateElement.Value;
                            label8.Text = placeofBirthElement.Value;
                            var studak = new Student(xElement.FirstAttribute.Value, surnameElement.Value,
                                otchestvoElement.Value, specializationElement.Value, int.Parse(coursElement.Value),
                                DateTime.Parse(birthDateElement.Value), placeofBirthElement.Value);
                            student = studak;
                            return true;
                        }

                        MessageBox.Show("Какого-то элемента явно не хватает");
                        return false;
                    }

                MessageBox.Show("Что-то пошло не так, но это не Exception");
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }
        } //Перегруженный метод для возвращения объекта

        private bool ReadXML(ref XDocument xDocument)
        {
            try
            {
                xDocument = XDocument.Load(openFileDialog1.FileName);
                var xaElement = xDocument.Element("Студенты");
                foreach (var xElement in xDocument.Elements("Студенты").Elements("Студент"))
                    if (xElement.FirstAttribute.Value == listBox1.SelectedItem.ToString())
                    {
                        var specializationElement = xElement.Element(Student.AttributesNameStrings[3]);
                        var coursElement = xElement.Element(Student.AttributesNameStrings[4]);
                        var birthDateElement = xElement.Element(Student.AttributesNameStrings[5]);
                        var placeofBirthElement = xElement.Element(Student.AttributesNameStrings[6]);
                        if (specializationElement != null && coursElement != null && birthDateElement != null &&
                            placeofBirthElement != null)
                        {
                            label2.Text = specializationElement.Value;
                            label4.Text = coursElement.Value;
                            label6.Text = birthDateElement.Value;
                            label8.Text = placeofBirthElement.Value;
                            return true;
                        }

                        MessageBox.Show("Какого-то элемента явно не хватает");
                        return false;
                    }

                MessageBox.Show("Что-то пошло не так, но это не Exception");
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }
        } //Изначальный метод для считывания XML

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Перечитывание .XML файла при изменении индекса
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    label2.Text = string.Empty;
                    label4.Text = string.Empty;
                    label6.Text = string.Empty;
                    label8.Text = string.Empty;
                    openFileDialog1.FileName = XmPathList[listBox1.SelectedIndex];
                    if (CheckFile(ref openFileDialog1))
                    {
                        var xDocument = new XDocument();
                        ReadXML(ref xDocument);
                    }
                    else
                    {
                        XmPathList.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка : {exception.Message}");
            }
        }

        private void загрузкаВXMLToolStripMenuItem_Click(object sender, EventArgs e) //Из .txt в .xml
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
                    var xDocument = new XDocument();
                    //string text = ReadAllText(openFileDialog1.FileName);
                    var lines = ReadAllLines(openFileDialog1.FileName);
                    var strings = new List<string[]>();
                    for (var i = 0; i < lines.Length; i++)
                        strings.Add(lines[i].Split(new[] {' ', '.'}, StringSplitOptions.RemoveEmptyEntries));
                    var dateTimes = new List<DateTime>();
                    foreach (var s in strings)
                        dateTimes.Add(new DateTime(int.Parse(s[7]), int.Parse(s[6]), int.Parse(s[5])));
                    var students = new List<Student>();
                    for (var i = 0; i < strings.Count; i++)
                    {
                        var student = new Student();
                        student[0] = strings[i][0];
                        student[1] = strings[i][1];
                        student[2] = strings[i][2];
                        student[3] = strings[i][3];
                        student[4] = strings[i][4];
                        student[5] = $"{dateTimes[i].Day}.{dateTimes[i].Month}.{dateTimes[i].Year}";
                        student[6] = strings[i][8];
                        students.Add(student);
                    }
                    //foreach (string[] s in strings)
                    //{
                    //    Student student= new Student();
                    //    foreach (DateTime dateTime in dateTimes)
                    //    {

                    //        break;
                    //    }
                    //}
                    if (CreateXML(ref xDocument, ref students)) MessageBox.Show("Действие выполнено успешно");
                    ////String[] dateStrings = strings[5].Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    ////DateTime date = new DateTime(int.Parse(dateStrings[2]), int.Parse(dateStrings[1]), int.Parse(dateStrings[0]));
                    ////Student student = new Student(strings[0], strings[1], strings[2], strings[3], int.Parse(strings[4]), date, strings[6]);
                    //if (CreateXML(ref xDocument, ref student))
                    //{
                    //    MessageBox.Show("Файл .XML создан");
                    //}
                }
            }
            catch (Exception errorException)
            {
                MessageBox.Show($"Ошибка: {errorException.Message}");
            }
        }

        private void загрузкаИзXMLToolStripMenuItem_Click(object sender, EventArgs e) //Изначальная загрузка .XML с которым будем работать
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            try
            {
                if (CheckFile(ref openFileDialog1))
                {
                    listBox1.Items.Clear();
                    XmPathList.Clear();
                    var issuccess = false;
                    var xDoc = XDocument.Load(openFileDialog1.FileName);
                    foreach (var xElement in xDoc.Elements("Студенты").Elements("Студент"))
                    {
                        var xAttribute = xElement.Attribute(Student.AttributesNameStrings[0]);
                        if (xAttribute != null)
                        {
                            issuccess = true;
                            listBox1.Items.Add(xAttribute.Value);
                            XmPathList.Add(openFileDialog1.FileName);
                            listBox1.SelectedIndex = listBox1.Items.IndexOf(xAttribute.Value);
                        }
                    }

                    if (!issuccess) MessageBox.Show("Не найдено подходящих элементов в .XML файле");
                    else MessageBox.Show("Дело сделано");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        private void
            определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem_Click(
                object sender, EventArgs e) //Посчтитаь количество стдуентов с одного курса
        {
            try
            {
                var course = 0;
                if (int.TryParse(toolStripTextBox1.Text, out course))
                {
                    if (StudentsFrom1Course()) MessageBox.Show("Дело сделано!");
                }
                else
                {
                    MessageBox.Show("Не удалось преобразовать в Int");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        private void доабвитьToolStripMenuItem_Click(object sender, EventArgs e) //Добавить в .XML
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    var flag = false;
                    var form1 = this;
                    using (var form2 = new Form2(XmPathList[listBox1.SelectedIndex], ref flag) {Owner = this})
                    {
                        form2.ShowDialog();
                        if (form2.Text != "Form2")
                        {
                            listBox1.Items.Add(form2.Text);
                            XmPathList.Add(form2.pathToNewFile);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не выбран файл в который будем добавлять записи");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка : {exception.Message}");
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) // Удаление записи из .XML
        {
            try
            {
                var isright = false;
                if (listBox1.Items.Count != 0)
                {
                    if (listBox1.SelectedItems.Count != 0)
                    {
                        var xDoc = XDocument.Load(XmPathList[listBox1.SelectedIndex]);
                        foreach (var xElement in xDoc.Elements("Студенты").Elements("Студент"))
                            if (xElement.FirstAttribute.Value == listBox1.SelectedItem.ToString())
                            {
                                xElement.Remove();
                                isright = true;
                                xDoc.Save(XmPathList[listBox1.SelectedIndex]);
                                listBox1.Items.Remove(listBox1.SelectedItem);
                                break;
                            }

                        if (!isright) MessageBox.Show("Странно, но почему то такой записи в .XML не нашлось");
                        else MessageBox.Show("Действие успешно выполнено!");
                    }
                    else
                    {
                        MessageBox.Show("Выберите хоть что-то");
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей в листбоксе");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e) //Редакитование
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    if (listBox1.SelectedItem != null)
                    {
                        var xDoc = new XDocument();
                        var student = new Student();
                        ReadXML(ref xDoc, ref student);
                        Student.Student1 = student;
                        var pos = listBox1.SelectedIndex;
                        using (var edit = new Edit(XmPathList[listBox1.SelectedIndex]))
                        {
                            edit.Owner = this;
                            edit.ShowDialog();
                            if (edit.IsSuccess)
                            {
                                listBox1.Items.RemoveAt(pos);
                                listBox1.Items.Add(Student.Student1[0]);
                            }
                            else
                            {
                                MessageBox.Show("Не было произведено изменений в файле");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите хоть что-то");
                    }
                }
                else
                {
                    MessageBox.Show("Листбокс пустой");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка {exception.Message}");
            }
        }

        private void создатьКартОчкуWordToolStripMenuItem_Click(object sender, EventArgs e) //Создание карточки Word
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    if (listBox1.SelectedItems.Count != 0)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Действие отменено");
                            return;
                        }

                        var wordApplication = new Application();
                        var student = new Student();
                        var xDoc = new XDocument();
                        ReadXML(ref xDoc, ref student);
                        wordApplication.Visible = false;
                        var document = wordApplication.Documents.Add();
                        wordApplication.Documents.Application.Caption = "Карточка";
                        document.Content.SetRange(0, 0);
                        document.Content.Text = student.ToString();
                        document.SaveAs(saveFileDialog1.FileName);
                        MessageBox.Show("Карточка была создана");
                        wordApplication?.Quit();
                        wordApplication = null;
                    }
                    else
                    {
                        MessageBox.Show("Выберите хоть что-то");
                    }
                }
                else
                {
                    MessageBox.Show("В листбоксе нет объектов");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }

        [Obsolete]
        private void создатьКартОчкуPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count != 0)
                {
                    if (listBox1.SelectedItems.Count != 0)
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        {
                            MessageBox.Show("Действие отменено");
                            return;
                        }
                        PdfDocument document = new PdfDocument();
                        PdfPage page = document.AddPage();
                        XGraphics graphics = XGraphics.FromPdfPage(page);
                        Student student = new Student();
                        XDocument xDocument = new XDocument();
                        ReadXML(ref xDocument, ref student);
                        XFont font = new XFont("Times New Roman", 14, XFontStyle.Bold);
                        int line = 30;
                        foreach (string s in student.ToString().Split(new[] { '\n' }))
                        {
                            graphics.DrawString(s, font, XBrushes.Black, new XRect(0, line, page.Width, page.Height), XStringFormat.TopCenter);
                            line += 14;
                        }
                        document.Save(saveFileDialog1.FileName);
                        MessageBox.Show("Карточка создана");
                    }
                    else
                    {
                        MessageBox.Show("Выберите хоть что-то");
                    }
                }
                else
                {
                    MessageBox.Show("Листбокс пуст");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка:{exception.Message}");
            }
        }
    }
}