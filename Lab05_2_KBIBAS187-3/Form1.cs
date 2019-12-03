﻿using System;
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
        List<string> xmPathList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckFile(ref OpenFileDialog open) //Проверка .txt файла
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

        private bool CreateXML(ref XDocument xDoc,ref List<Student> students) //Создание .XML
        {
            if (saveFileDialog1.ShowDialog()== DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return false;
            }
            try
            {

                XElement studentsElement = new XElement("Студенты");
                foreach (Student student in students)
                {
                    XElement studElement = new XElement("Студент");
                    XAttribute studElementNameAttribute = new XAttribute(Student.AttributesNameStrings[0], student[0]);
                    XElement studSurnameElement = new XElement(Student.AttributesNameStrings[1], student[1]);
                    XElement studOtchestvoElement = new XElement(Student.AttributesNameStrings[2], student[2]);
                    XElement studSpecializationElement = new XElement(Student.AttributesNameStrings[3], student[3]);
                    XElement studCoursElement = new XElement(Student.AttributesNameStrings[4], student[4]);
                    XElement studBirthDatElement = new XElement(Student.AttributesNameStrings[5], $"{student[5]}");
                    XElement studPlaceOfBirthElement = new XElement(Student.AttributesNameStrings[6], student[6]);
                    studElement.Add(studElementNameAttribute, studSurnameElement, studOtchestvoElement, studSpecializationElement, studCoursElement, studBirthDatElement, studPlaceOfBirthElement);
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

        private bool ReadXML(ref OpenFileDialog open, ref XDocument xDocument)
        {

            try
            {
                xDocument = XDocument.Load(openFileDialog1.FileName);

                foreach (XElement xElement in xDocument.Elements("Студенты").Elements("Студент"))
                {
                    if (xElement.FirstAttribute.Value==listBox1.SelectedItem.ToString())
                    {
                        XElement specializationElement = xElement.Element(Student.AttributesNameStrings[3]);
                        XElement coursElement = xElement.Element(Student.AttributesNameStrings[4]);
                        XElement birthDateElement = xElement.Element(Student.AttributesNameStrings[5]);
                        XElement placeofBirthElement = xElement.Element(Student.AttributesNameStrings[6]);
                        if (specializationElement != null && coursElement != null && birthDateElement != null && placeofBirthElement != null)
                        {
                            label2.Text = specializationElement.Value;
                            label4.Text = coursElement.Value;
                            label6.Text = birthDateElement.Value;
                            label8.Text = placeofBirthElement.Value;
                            return true;
                        }
                    }
                }
                MessageBox.Show("Что-то пошло не так, но это не Exception");
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex != -1)
                {
                    label2.Text=String.Empty;
                    label4.Text= String.Empty;
                    label6.Text=String.Empty;
                    label8.Text= String.Empty;
                    openFileDialog1.FileName = xmPathList[listBox1.SelectedIndex];
                    if (CheckFile(ref openFileDialog1))
                    {
                        XDocument xDocument = new XDocument();
                        ReadXML(ref openFileDialog1, ref xDocument);
                    }
                    else
                    {
                        xmPathList.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.Remove(listBox1.SelectedItem);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка : {exception.Message}");
            }
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
                    XDocument xDocument= new XDocument();
                    //string text = ReadAllText(openFileDialog1.FileName);
                    String[] lines = ReadAllLines(openFileDialog1.FileName);
                    List<string[]> strings=new List<string[]>();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        strings.Add(lines[i].Split(new []{' ','.'}, StringSplitOptions.RemoveEmptyEntries));
                    }
                    List<DateTime> dateTimes=new List<DateTime>();
                    foreach (string[] s in strings)
                    {
                        dateTimes.Add(new DateTime(int.Parse(s[7]),int.Parse(s[6]),int.Parse(s[5])));
                    }

                    List<Student> students= new List<Student>();
                    foreach (string[] s in strings)
                    {
                        Student student= new Student();
                        foreach (DateTime dateTime in dateTimes)
                        {
                            student[0] = s[0];
                            student[1] = s[1];
                            student[2] = s[2];
                            student[3] = s[3];
                            student[4] = s[4];
                            student[5] = $"{dateTime.Day}.{dateTime.Month}.{dateTime.Year}";
                            student[6] = s[8];
                            students.Add(student);
                            break;
                        }
                    }

                    if (CreateXML(ref xDocument, ref students))
                    {
                        MessageBox.Show("Действие выполнено успешно");
                    }
                    ////String[] dateStrings = strings[5].Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    ////DateTime date = new DateTime(int.Parse(dateStrings[2]), int.Parse(dateStrings[1]), int.Parse(dateStrings[0]));
                    ////Student student = new Student(strings[0], strings[1], strings[2], strings[3], int.Parse(strings[4]), date, strings[6]);
                    //if (CreateXML(ref xDocument, ref student))
                    //{
                    //    MessageBox.Show("Файл .XML создан");
                    //}
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

        private void загрузкаИзXMLToolStripMenuItem_Click(object sender, EventArgs e)
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
                    bool issuccess = false;
                    XDocument xDoc = XDocument.Load(openFileDialog1.FileName);
                    foreach (XElement xElement in xDoc.Elements("Студенты").Elements("Студент"))
                    {
                        XAttribute xAttribute = xElement.Attribute(Student.AttributesNameStrings[0]);
                        if (xAttribute != null)
                        {
                            issuccess = true;
                            listBox1.Items.Add(xAttribute.Value);
                            xmPathList.Add(openFileDialog1.FileName);
                            listBox1.SelectedIndex = listBox1.Items.IndexOf(xAttribute.Value);
                        }
                    }

                    if (!issuccess)
                    {
                        MessageBox.Show("Не найдено подходящих элементов в .XML файле");
                    }
                    else
                    {
                        MessageBox.Show("Дело сделано");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }
    }
}
