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
        public Font[] Fonts { get; } =
        {
            new Font("Times New Roman", 8), new Font("Trebuchet MS", 8), new Font("Microsoft Tai Le", 8),
            new Font("Regurgitation", 8), new Font("Yu Gothic", 8), new Font("Arial", 8),
            new Font("Microsoft Sans Serif", 8), new Font("Javanese Text", 8)
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedstring = comboBox1.Text;
            switch (selectedstring)
            {
                case "Times New Roman":
                    Font = Fonts[0];
                    break;
                case "Trebuchet MS":
                    Font = Fonts[1];
                    break;
                case "Microsoft Tai Le":
                    Font = Fonts[2];
                    break;
                case "Regurgitation":
                    Font = Fonts[3];
                    break;
                case "Yu Gothic":
                    Font = Fonts[4];
                    break;
                case "Arial":
                    Font = Fonts[5];
                    break;
                case "Microsoft Sans Serif":
                    Font = Fonts[6];
                    break;
                case "Javanese Text":
                    Font = Fonts[7];
                    break;
                //case
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
