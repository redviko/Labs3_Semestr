using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        private bool ItemsCountCheck()
        {
            if (listBox1.Items.Count != 0) return true;
            return false;
        }

        private bool ReadTextFromPaths(ref List<string> pathStrings, ref bool isempty, ref List<string[]> stringList)
        {
            if (!CheckTheFiles(ref pathStrings)) return false;
            foreach (var pathString in pathStrings)
                if (ReadAllLines(pathString).Length != 0)
                {
                    isempty = false;
                    stringList.Add(ReadAllLines(pathString));
                }
                else
                {
                    stringList.Add(new[] {"0"});
                }

            if (isempty)
            {
                MessageBox.Show("Файлы пусты");
                return false;
            }

            return true;
        } //Функция проверки

        private bool CheckTheFiles(ref List<string> pathStrings) //Ещё одна функция проверки
        {
            var ispath = false;
            var delete = false;
            var flag = false;
            var deleteList = new List<object>();
            for (var i = 0; i < listBox1.SelectedItems.Count; i++)
                if (listBox1.SelectedItems[i].ToString().Contains("\\"))
                {
                    ispath = true;
                    if (Exists(listBox1.SelectedItems[i].ToString()) &&
                        ReadAllLines(listBox1.SelectedItems[i].ToString()).Length != 0)
                    {
                        pathStrings.Add(listBox1.SelectedItems[i].ToString());
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show($"Файл {listBox1.SelectedItems[i]} пуст");
                        delete = true;
                        deleteList.Add(listBox1.SelectedItems[i]);
                    }
                }

            if (!ispath) MessageBox.Show("В листбоксе нет путей к файлам");
            if (delete)
                foreach (var o in deleteList)
                    listBox1.Items.Remove(o);
            return flag;
        }

        private void Button3_Click(object sender, EventArgs e) //Вывод каталога
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            listBox1.Items.Clear();
            var isempty = true;
            foreach (var s in Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.txt"))
            {
                isempty = false;
                listBox1.Items.Add(s);
            }

            if (isempty) MessageBox.Show("Нет .txt файлов в каталоге");
            else MessageBox.Show("В листбок помещены названия файлов с каталога");
        }

        private void ToolStripMenuItem5_Click(object sender, EventArgs e) //Вывод нечётных строк
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Дейстивие отменено");
                return;
            }

            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var isempty = true;
                    var pathStrings = new List<string>();
                    var strinliList = new List<string[]>();
                    if (ReadTextFromPaths(ref pathStrings, ref isempty, ref strinliList))
                    {
                        foreach (var strings in strinliList)
                            for (var i = 0; i < strings.Length; i += 2)
                                AppendAllText(saveFileDialog1.FileName, "\r\n" + strings[i], Encoding.Default);
                        MessageBox.Show("Действие выполнено");
                    }
                }

                MessageBox.Show("Выберите что-то");
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e) //Вывод строки без цифер
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Дейстивие отменено");
                return;
            }

            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var isempty = true;
                    var isdigit = false;
                    var pathStrings = new List<string>();
                    var stringlList = new List<string[]>();
                    if (ReadTextFromPaths(ref pathStrings, ref isempty, ref stringlList))
                        foreach (var strings in stringlList)
                        foreach (var s in strings)
                        {
                            isdigit = false;
                            foreach (var c in s)
                                if (char.IsDigit(c))
                                {
                                    isdigit = true;
                                    break;
                                }

                            if (!isdigit) AppendAllText(saveFileDialog1.FileName, "\r\n" + s, Encoding.Default);
                        }

                    MessageBox.Show("Действие выполнено");
                }
                else
                {
                    MessageBox.Show("Выберите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void
            ListBox1_SelectedIndexChanged(object sender, EventArgs e) //Проверка файлов при выделении их в ListBox
        {
            if (listBox1.SelectedItem != null)
                if (listBox1.SelectedItem.ToString().Contains("\\"))
                    if (!Exists(listBox1.SelectedItem.ToString()))
                    {
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        MessageBox.Show("Этотго файла не существует");
                    }
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e) //Вывод всех не пустых строк
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var pathStrings = new List<string>();
                    var isempty = true;
                    var stingList = new List<string[]>();
                    if (ReadTextFromPaths(ref pathStrings, ref isempty, ref stingList))
                        foreach (var strings in stingList)
                        foreach (var s in strings)
                            if (s.Length != 0)
                                AppendAllText(saveFileDialog1.FileName, "\r\n" + s);
                    MessageBox.Show("Действие выполнено");
                }
                else
                {
                    MessageBox.Show("Выберите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void ToolStripMenuItem8_Click(object sender, EventArgs e) //Количество строк в файле
        {
            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var isepmty = true;
                    var pathStrings = new List<string>();
                    var strinlList = new List<string[]>();
                    if (ReadTextFromPaths(ref pathStrings, ref isepmty, ref strinlList))
                        for (var i = 0; i < pathStrings.Count; i++)
                            MessageBox.Show($"Количество строк в файле{pathStrings[i]}\r\n{strinlList[i].Length}");
                }
                else
                {
                    MessageBox.Show("Выберите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e) //Вывести количество символов в файлах
        {
            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var isempty = true;
                    var pathStrings = new List<string>();
                    var stingList = new List<string[]>();
                    var count = 0;
                    if (ReadTextFromPaths(ref pathStrings, ref isempty, ref stingList))
                        for (var i = 0; i < pathStrings.Count; i++)
                        {
                            for (var j = 0; j < stingList[i].Length; j++) count += stingList[i][j].Length;
                            MessageBox.Show($"В файле {pathStrings[i]} {count} символов");
                        }
                }
                else
                {
                    MessageBox.Show("Выберите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e) //Количество символов в последней строке
        {
            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    var isempty = true;
                    var pathStrings = new List<string>();
                    var stingList = new List<string[]>();
                    if (ReadTextFromPaths(ref pathStrings, ref isempty, ref stingList))
                    {
                        for (var i = 0; i < pathStrings.Count; i++)
                            MessageBox.Show(
                                $"Количество символов в последней строке файла {pathStrings[i]} {stingList[i].Last().Length}");
                        MessageBox.Show("Дело сделано");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Пустой листбокс");
            }
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e) //Вывести в обратном порядке
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            if (listBox1.Items.Count != 0)
            {
                for (var i = listBox1.Items.Count - 1; i >= 0; i--)
                    AppendAllText(saveFileDialog1.FileName, "\r\n" + listBox1.Items[i], Encoding.Default);
                MessageBox.Show("Дело сделано");
            }
            else
            {
                MessageBox.Show("ЛистБокс пустой");
            }
        }

        private void Button1_Click(object sender, EventArgs e) //Вывести содержимое текстового файла в ListBox
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            listBox1.Items.Clear();
            if (ReadAllText(openFileDialog1.FileName).Length != 0)
            {
                foreach (var line in ReadAllLines(openFileDialog1.FileName)) listBox1.Items.Add(line);
                MessageBox.Show("Все строки успешно добавлены");
            }
            else
            {
                MessageBox.Show("Милорд, файл пустой");
            }
        }

        private void ToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Действие отменено");
                return;
            }

            if (ItemsCountCheck())
            {
                if (listBox1.SelectedItems.Count != 0)
                {
                    foreach (string s in listBox1.SelectedItems)
                        AppendAllText(saveFileDialog1.FileName, "\r\n+" + s, Encoding.Default);
                    MessageBox.Show("Действие выполнено");
                }
                else
                {
                    MessageBox.Show("Выведите хоть что-то");
                }
            }
            else
            {
                MessageBox.Show("Листбокс пуст");
            }
        }
    }
}