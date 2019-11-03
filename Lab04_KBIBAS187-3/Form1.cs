using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_KBIBAS187_3
{
    public partial class Form1 : Form
    {
        //public Boolean args { get; set; }
        public Int32 Index { get; set; } = 0;
        //public  SystemMenu
        public Font[] Fonts { get; } =
        {
            new Font("Times New Roman", 8), new Font("Trebuchet MS", 8), new Font("Microsoft Tai Le", 8),
            new Font("Regurgitation", 8), new Font("Yu Gothic", 8), new Font("Arial", 8),
            new Font("Microsoft Sans Serif", 8), new Font("Javanese Text", 8)
        };
        public Form1()
        {
            InitializeComponent();
            checkBox2=new CheckBox();
            checkBox2.AutoSize = true;
            checkBox2.Location=new Point(390,31);
            checkBox2.Name = "checkBox2";
            checkBox2.Size=new Size(80,17);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            Controls.Add(checkBox2);
            checkBox2.CheckStateChanged += CheckBox2_CheckChanged;
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(356, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.Controls.Add(this.checkBox1);
            checkBox1.CheckedChanged += CheckBox1_CheckChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedstring = comboBox1.Text;
            foreach (Control control in Controls)
            {
                switch (selectedstring)
                {
                    //Font.Style = FontStyle.Regular;
                    case "Times New Roman":
                        control.Font = Fonts[0];
                        break;
                    case "Trebuchet MS":
                        control.Font = Fonts[1];
                        break;
                    case "Microsoft Tai Le":
                        control.Font = Fonts[2];
                        break;
                    case "Regurgitation":
                        control.Font = Fonts[3];
                        break;
                    case "Yu Gothic":
                        control.Font = Fonts[4];
                        break;
                    case "Arial":
                        control.Font = Fonts[5];
                        break;
                    case "Microsoft Sans Serif":
                        control.Font = Fonts[6];
                        break;
                    case "Javanese Text":
                        control.Font = Fonts[7];
                        break;
                    //case
                }
            }
        }

        private void CheckBox2_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox=sender as CheckBox;
            if (checkBox.Checked)
            {
                ControlBox = !ControlBox;
            }
            else
            {
                ControlBox = !ControlBox;
            }
        }
        private void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            if (checkBox.Checked)
            {
                Text = "";
                //ControlBox = !ControlBox;
            }
            else
            {
                //ControlBox = !ControlBox;
                Text = "Form1";
            }
        }
    }
}
