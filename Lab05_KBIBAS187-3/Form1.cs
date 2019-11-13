﻿using System;
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

        private void Button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            Boolean isempty = true;
            foreach (string s in Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.txt"))
            {
                isempty = false;
                listBox1.Items.Add(s);
            }

            if (isempty)
            {
                MessageBox.Show("Нет .txt файлов в каталоге");
            }
            else
            {
                MessageBox.Show($"В листбок помещены названия файлов с каталога");
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Int32[] indexes = 0;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            string[] path = new string[listBox1.SelectedItems.Count];
            Boolean digits = false;
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите что-то");
                return;
            }

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                path[i] = listBox1.SelectedItems[i].ToString();
                path[i] = path[i].Replace("\\", "/");
                String[] strings = ReadAllText(path[i]) // Разделил строки по признаку переноса
                    .Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < strings.Length; j++)
                {
                    if ((j == (j) + 2 || j == 0) && !digits) //Абсолютная хуета(
                    {
                        AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                        digits = !digits;
                    }

                    if (strings[j].Length > 0 && !digits) //Запись всех строк, кроме пустых
                    {
                        AppendAllText(saveFileDialog1.FileName, strings[j] + "\r\n");
                        digits = !digits;
                    }


                    if (!digits) //Вывод строки в которой нет чисел( с проверкой)
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

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string[] pathStrings = new string[listBox1.SelectedItems.Count];
            Int32 count = 0;
            for (var i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                pathStrings[i] = listBox1.SelectedItems[i].ToString();
                pathStrings[i] = pathStrings[i].Replace("\\", "/");
                String[] strings = ReadAllText(pathStrings[i])
                    .Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                count = 0;
                foreach (var s in strings)
                {
                    count += s.Length;
                }

                MessageBox.Show(
                    $"Строк в файле:{pathStrings[i].Length}\nКоличество символов в файле:{count}\nКоличество символов в последней строке{strings[strings.Length - 1].Length}");
            }
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show($"Действие отменено");
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            string path = openFileDialog1.FileName;
            path = path.Replace("\\", "/");
            if (ReadAllText(path).Length != 0)
            {
                string[] strings = ReadAllText(path).Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in strings)
                {
                    listBox1.Items.Add(s);
                }

                if (listBox1.SelectedItems != null)
                    foreach (string s in listBox1.SelectedItems)
                    {
                        AppendAllText(saveFileDialog1.FileName, s);
                    }

                var sortered = strings.OrderBy(a => a.First());
                if (sortered.Count() != 0)
                {
                    foreach (string s in sortered)
                    {
                        AppendAllText(saveFileDialog1.FileName, s + "\r\n");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ахахап,неловко получилось.");
            }
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e) //Вывод нечётных строк
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Дейстивие отменено");
                return;
            }

            if (listBox1.SelectedItems.Count != 0)
            {
                Boolean isempty = true;
                string[] pathStrings = new string[listBox1.SelectedItems.Count];
                for (var i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    if (Exists(listBox1.SelectedItems[i].ToString()))
                    {
                        pathStrings[i] = listBox1.SelectedItems[i].ToString();
                    }
                }
                
                if (pathStrings.Length==0)
                {
                    MessageBox.Show("Ой, а вы файлы удалили, ну спасибо. Только не форматируйте мне диск пожалуйста");
                    return;
                }
                foreach (string pathString in pathStrings)
                {
                    string[] strings = ReadAllText(pathString.Replace("\\", "/"))
                        .Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                    if (strings.Length != 0)
                    {
                        isempty = false;
                        for (var i = 0; i < strings.Length; i += 2)
                        {
                            AppendAllText(saveFileDialog1.FileName, strings[i]+"\r\n");
                        }
                    }
                }

                if (isempty)
                {
                    MessageBox.Show("Файлы пусты");
                }
                else
                {
                    MessageBox.Show("Добавление строк прошло успешно");
                }
            }

            MessageBox.Show("Выберите что-то");
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e) //Вывод строки без цифер
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Дейстивие отменено");
                return;
            }

            if (listBox1.SelectedItems.Count != 0)
            {
                Boolean isempty = true;
                Boolean isdigit = false;
                string[] pathStrings = new string[listBox1.SelectedItems.Count];
                for (var i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    if (File.Exists(listBox1.SelectedItems[i].ToString()))
                    {
                        pathStrings[i] = listBox1.SelectedItems[i].ToString();
                    }
                }

                if (pathStrings.Length==0)
                {
                    MessageBox.Show("Файлы которые вы выбрали вы сами и удалили, вы такой молодец. Спасибо за удаленные файлы, только не удаляйте мой рабочий стол, спасибо.");
                    return;
                }
                foreach (string pathString in pathStrings)
                {
                    string[] strings = ReadAllText(pathString,Encoding.Default)
                        .Split(new[] {'\r', '\n',' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (strings.Length != 0)
                    {
                        isempty = false;
                        foreach (string s in strings)
                        {
                            isdigit = false;
                            foreach (char c in s)
                            {
                                if (Char.IsDigit(c))
                                {
                                    isdigit = true;
                                    break;
                                }
                            }

                            if (!isdigit)
                            {
                                AppendAllText(saveFileDialog1.FileName,s+"\r\n");
                            }
                        }
                    }
                }

                if (isdigit)
                {
                    MessageBox.Show("Нет строк которых не было бы цифр");
                }
                if (isempty)
                {
                    MessageBox.Show("Файлы пусты");
                }
                else
                {
                    MessageBox.Show("Добавление строк прошло успешно");
                }
            }
        }
    }
}