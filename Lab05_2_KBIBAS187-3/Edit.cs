using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_2_KBIBAS187_3
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            textBox1.Text = Student.Student1[0];
            textBox2.Text = Student.Student1[1];
            textBox3.Text = Student.Student1[2];
            textBox4.Text = Student.Student1[3];
            textBox5.Text = Student.Student1[6];
            maskedTextBox1.Text = Student.Student1[4];
            dateTimePicker1.Value = Student.Student1.BirthDateTime;
        }

        private Boolean EditStudent()
        {

        }
        private void Edit_Load(object sender, EventArgs e)
        {

        }
    }
}
