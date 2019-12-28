using System;
using System.Drawing;
using System.Windows.Forms;

namespace LAB8
{
    public partial class Form1 : Form
    {
        private TabFour _tabFour;
        private TabOne _tabOne;
        private TabThree _tabThree;
        private TabTwo _tabTwo;
        private Timer _timerTabOneMoveTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void TabOne_MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timerTabOneMoveTime.Start();
        }

        private void TabOne_StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timerTabOneMoveTime.Stop();
        }

        private void TabThree_ButColor_BackColorChanged(object sender, EventArgs e)
        {
            _tabThree.color = tabThreeButColor.BackColor;
        }

        private void TabThree_Save_Click(object sender, EventArgs e)
        {
            _tabThree.SaveFile();
        }

        private void TabThree_Open_Click(object sender, EventArgs e) //Открытие
        {
            _tabThree.OpenFile();
        }

        private void TabThree_SaveBuffer_Click(object sender, EventArgs e) //Буфер
        {
            _tabThree.ToBuffer();
        }

        private void TabThree_OpenBuffer_Click(object sender, EventArgs e) //Из буффера
        {
            _tabThree.FromBuffer();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tabFour.Add();
        }

        private void Form1_Load(object sender, EventArgs e) //Загрузка формы
        {
            _tabOne = new TabOne(tabOnePanel);
            _timerTabOneMoveTime = new Timer {Interval = 500};
            _timerTabOneMoveTime.Tick += TabOne_Move;
            UpdateTabOneSize();
            _tabTwo = new TabTwo(tabTwo_Panel);
            tabTwoComboxFigure.SelectedIndex = 0;
            tabTwoComboxColor.SelectedIndex = 0;
            tabTwoComboxBrush.SelectedIndex = 0;
            _tabThree = new TabThree(tabThree_Panel);
            tabThree_Panel.MouseDown += _tabThree.MouseDown;
            tabThree_Panel.MouseMove += _tabThree.MouseMove;
            tabThree_Panel.MouseUp += _tabThree.MouseUp;
            _tabThree.color = tabThreeButColor.BackColor;
            _tabFour = new TabFour(tabFour_Panel);
        }

        private void TabOneWidth_ValueChanged(object sender, EventArgs e) //Изменение вкладки в ширину
        {
            tabOnePanel.Width = Math.Min((int) tabOne_Width.Value,
                splitContainer1.Panel2.ClientSize.Width - tabOnePanel.Location.X);
            tabOnePanel.Refresh();
        }

        private void TabOne_Height_ValueChanged(object sender, EventArgs e) //В высоту
        {
            tabOnePanel.Height = (int) tabOne_Height.Value;
            tabOnePanel.Refresh();
        }

        private void TabOne_Move(object sender, EventArgs args) //Движение
        {
            _tabOne.Move();
            UpdateTabOneSize();
        }

        private void UpdateTabOneSize() //Обновления размеров панели
        {
            tabOne_Width.Maximum = splitContainer1.Panel2.ClientSize.Width - tabOnePanel.Location.X;
            tabOne_Width.Value = tabOnePanel.Width;
            tabOne_Height.Maximum = splitContainer1.Panel2.ClientRectangle.Height;
            tabOne_Height.Value = tabOnePanel.Height;
            tabOnePanel.Refresh();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e) //Изменение формы
        {
            UpdateTabOneSize();
            UpdateTabFourSize();
            tabTwo_Panel.Refresh();
        }

        private void TabOne_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) TabOne_Move(null, null);
        }

        private void TabTwo_ComboxFigure_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tabTwo.Figure = tabTwoComboxFigure.SelectedItem as string;
            tabTwo_Panel.Refresh();
        }

        private void TabTwo_ComboxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tabTwo.SetColor(tabTwoComboxColor.SelectedItem as string);
            _tabTwo.SetBrushType(tabTwoComboxBrush.SelectedItem as string);
            tabTwo_Panel.Refresh();
        }

        private void TabTwo_ComboxBrush_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tabTwo.SetBrushType(tabTwoComboxBrush.SelectedItem as string);
            tabTwo_Panel.Refresh();
        }

        private void TabThree_ButColor_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog {Color = tabThreeButColor.BackColor})
            {
                if (dialog.ShowDialog() == DialogResult.OK) tabThreeButColor.BackColor = dialog.Color;
            }
        }

        private void UpdateTabFourSize()
        {
            tabFour_Panel.Size = tabControl1.TabPages[3].ClientSize;
            _tabFour.UpdateBounds();
            tabFour_Panel.CreateGraphics().Clear(Color.White);
            tabFour_Panel.Refresh();
        }
    }
}