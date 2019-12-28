namespace LAB8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOne_Height = new System.Windows.Forms.NumericUpDown();
            this.tabOne_Width = new System.Windows.Forms.NumericUpDown();
            this.tab1_panelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tab1_moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab1_stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOnePanel = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabTwoComboxBrush = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabTwoComboxColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabTwoComboxFigure = new System.Windows.Forms.ComboBox();
            this.tabTwo_Panel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabThree_Panel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tabThreeButColor = new System.Windows.Forms.ToolStripButton();
            this.tab3_open = new System.Windows.Forms.ToolStripButton();
            this.tab3_save = new System.Windows.Forms.ToolStripButton();
            this.tab3_save_buffer = new System.Windows.Forms.ToolStripButton();
            this.tab3_open_buffer = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabFour_Panel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabOne_Height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOne_Width)).BeginInit();
            this.tab1_panelMenuStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 321);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(540, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задание 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tabOne_Height);
            this.splitContainer1.Panel1.Controls.Add(this.tabOne_Width);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.ContextMenuStrip = this.tab1_panelMenuStrip;
            this.splitContainer1.Panel2.Controls.Add(this.tabOnePanel);
            this.splitContainer1.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabOne_Panel_MouseDown);
            this.splitContainer1.Size = new System.Drawing.Size(534, 289);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Высота:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Длинна:";
            // 
            // tabOne_Height
            // 
            this.tabOne_Height.Location = new System.Drawing.Point(377, 2);
            this.tabOne_Height.Name = "tabOne_Height";
            this.tabOne_Height.Size = new System.Drawing.Size(52, 20);
            this.tabOne_Height.TabIndex = 1;
            this.tabOne_Height.ValueChanged += new System.EventHandler(this.TabOne_Height_ValueChanged);
            // 
            // tabOne_Width
            // 
            this.tabOne_Width.Location = new System.Drawing.Point(264, 2);
            this.tabOne_Width.Name = "tabOne_Width";
            this.tabOne_Width.Size = new System.Drawing.Size(53, 20);
            this.tabOne_Width.TabIndex = 0;
            this.tabOne_Width.ValueChanged += new System.EventHandler(this.TabOneWidth_ValueChanged);
            // 
            // tab1_panelMenuStrip
            // 
            this.tab1_panelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tab1_panelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tab1_moveToolStripMenuItem,
            this.tab1_stopToolStripMenuItem});
            this.tab1_panelMenuStrip.Name = "tab1_panelMenuStrip";
            this.tab1_panelMenuStrip.Size = new System.Drawing.Size(289, 48);
            // 
            // tab1_moveToolStripMenuItem
            // 
            this.tab1_moveToolStripMenuItem.Name = "tab1_moveToolStripMenuItem";
            this.tab1_moveToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.tab1_moveToolStripMenuItem.Text = "Включить непрерывное перемещение";
            this.tab1_moveToolStripMenuItem.Click += new System.EventHandler(this.TabOne_MoveToolStripMenuItem_Click);
            // 
            // tab1_stopToolStripMenuItem
            // 
            this.tab1_stopToolStripMenuItem.Name = "tab1_stopToolStripMenuItem";
            this.tab1_stopToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.tab1_stopToolStripMenuItem.Text = "Остановка";
            this.tab1_stopToolStripMenuItem.Click += new System.EventHandler(this.TabOne_StopToolStripMenuItem_Click);
            // 
            // tabOnePanel
            // 
            this.tabOnePanel.BackColor = System.Drawing.Color.Transparent;
            this.tabOnePanel.ContextMenuStrip = this.tab1_panelMenuStrip;
            this.tabOnePanel.Location = new System.Drawing.Point(3, 3);
            this.tabOnePanel.Name = "tabOnePanel";
            this.tabOnePanel.Size = new System.Drawing.Size(531, 260);
            this.tabOnePanel.TabIndex = 0;
            this.tabOnePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabOne_Panel_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(540, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задание 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabTwoComboxBrush);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.tabTwoComboxColor);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.tabTwoComboxFigure);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabTwo_Panel);
            this.splitContainer2.Size = new System.Drawing.Size(534, 289);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabTwoComboxBrush
            // 
            this.tabTwoComboxBrush.FormattingEnabled = true;
            this.tabTwoComboxBrush.Items.AddRange(new object[] {
            "Заливка",
            "Градиент",
            "Штрих",
            "Изображение"});
            this.tabTwoComboxBrush.Location = new System.Drawing.Point(322, 2);
            this.tabTwoComboxBrush.Name = "tabTwoComboxBrush";
            this.tabTwoComboxBrush.Size = new System.Drawing.Size(64, 21);
            this.tabTwoComboxBrush.TabIndex = 5;
            this.tabTwoComboxBrush.SelectedIndexChanged += new System.EventHandler(this.TabTwo_ComboxBrush_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Кисть(Брух)";
            // 
            // tabTwoComboxColor
            // 
            this.tabTwoComboxColor.FormattingEnabled = true;
            this.tabTwoComboxColor.Items.AddRange(new object[] {
            "Зеленый",
            "Синий",
            "Оранжевый"});
            this.tabTwoComboxColor.Location = new System.Drawing.Point(178, 2);
            this.tabTwoComboxColor.Name = "tabTwoComboxColor";
            this.tabTwoComboxColor.Size = new System.Drawing.Size(65, 21);
            this.tabTwoComboxColor.TabIndex = 3;
            this.tabTwoComboxColor.SelectedIndexChanged += new System.EventHandler(this.TabTwo_ComboxColor_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Цвет:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Фигура:";
            // 
            // tabTwoComboxFigure
            // 
            this.tabTwoComboxFigure.FormattingEnabled = true;
            this.tabTwoComboxFigure.Items.AddRange(new object[] {
            "Круг",
            "Эллипс",
            "Сектор",
            "Треугольник",
            "Прямоугольник",
            "Многоугольник"});
            this.tabTwoComboxFigure.Location = new System.Drawing.Point(55, 2);
            this.tabTwoComboxFigure.Name = "tabTwoComboxFigure";
            this.tabTwoComboxFigure.Size = new System.Drawing.Size(78, 21);
            this.tabTwoComboxFigure.TabIndex = 0;
            this.tabTwoComboxFigure.SelectedIndexChanged += new System.EventHandler(this.TabTwo_ComboxFigure_SelectedIndexChanged);
            // 
            // tabTwo_Panel
            // 
            this.tabTwo_Panel.Location = new System.Drawing.Point(0, 4);
            this.tabTwo_Panel.Name = "tabTwo_Panel";
            this.tabTwo_Panel.Size = new System.Drawing.Size(534, 256);
            this.tabTwo_Panel.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tabThree_Panel);
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(540, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Задание 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabThree_Panel
            // 
            this.tabThree_Panel.BackColor = System.Drawing.Color.White;
            this.tabThree_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabThree_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThree_Panel.Location = new System.Drawing.Point(3, 28);
            this.tabThree_Panel.Name = "tabThree_Panel";
            this.tabThree_Panel.Size = new System.Drawing.Size(534, 264);
            this.tabThree_Panel.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tabThreeButColor,
            this.tab3_open,
            this.tab3_save,
            this.tab3_save_buffer,
            this.tab3_open_buffer});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(534, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Цвет:";
            // 
            // tabThreeButColor
            // 
            this.tabThreeButColor.BackColor = System.Drawing.Color.Maroon;
            this.tabThreeButColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tabThreeButColor.Image = ((System.Drawing.Image)(resources.GetObject("tabThreeButColor.Image")));
            this.tabThreeButColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tabThreeButColor.Name = "tabThreeButColor";
            this.tabThreeButColor.Size = new System.Drawing.Size(23, 22);
            this.tabThreeButColor.Text = "tab3_color_btn";
            this.tabThreeButColor.ToolTipText = "Цвет кисти";
            this.tabThreeButColor.BackColorChanged += new System.EventHandler(this.TabThree_ButColor_BackColorChanged);
            this.tabThreeButColor.Click += new System.EventHandler(this.TabThree_ButColor_Click);
            // 
            // tab3_open
            // 
            this.tab3_open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tab3_open.Image = ((System.Drawing.Image)(resources.GetObject("tab3_open.Image")));
            this.tab3_open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tab3_open.Name = "tab3_open";
            this.tab3_open.Size = new System.Drawing.Size(58, 22);
            this.tab3_open.Text = "Открыть";
            this.tab3_open.Click += new System.EventHandler(this.TabThree_Open_Click);
            // 
            // tab3_save
            // 
            this.tab3_save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tab3_save.Image = ((System.Drawing.Image)(resources.GetObject("tab3_save.Image")));
            this.tab3_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tab3_save.Name = "tab3_save";
            this.tab3_save.Size = new System.Drawing.Size(70, 22);
            this.tab3_save.Text = "Сохранить";
            this.tab3_save.Click += new System.EventHandler(this.TabThree_Save_Click);
            // 
            // tab3_save_buffer
            // 
            this.tab3_save_buffer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tab3_save_buffer.Image = ((System.Drawing.Image)(resources.GetObject("tab3_save_buffer.Image")));
            this.tab3_save_buffer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tab3_save_buffer.Name = "tab3_save_buffer";
            this.tab3_save_buffer.Size = new System.Drawing.Size(76, 22);
            this.tab3_save_buffer.Text = "Копировать";
            this.tab3_save_buffer.Click += new System.EventHandler(this.TabThree_SaveBuffer_Click);
            // 
            // tab3_open_buffer
            // 
            this.tab3_open_buffer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tab3_open_buffer.Image = ((System.Drawing.Image)(resources.GetObject("tab3_open_buffer.Image")));
            this.tab3_open_buffer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tab3_open_buffer.Name = "tab3_open_buffer";
            this.tab3_open_buffer.Size = new System.Drawing.Size(59, 22);
            this.tab3_open_buffer.Text = "Вставить";
            this.tab3_open_buffer.Click += new System.EventHandler(this.TabThree_OpenBuffer_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DimGray;
            this.tabPage4.Controls.Add(this.tabFour_Panel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage4.Size = new System.Drawing.Size(540, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Задание 4";
            // 
            // tabFour_Panel
            // 
            this.tabFour_Panel.BackColor = System.Drawing.Color.Transparent;
            this.tabFour_Panel.ContextMenuStrip = this.contextMenuStrip1;
            this.tabFour_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFour_Panel.Location = new System.Drawing.Point(3, 3);
            this.tabFour_Panel.Name = "tabFour_Panel";
            this.tabFour_Panel.Size = new System.Drawing.Size(534, 289);
            this.tabFour_Panel.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.addToolStripMenuItem.Text = "Добавить";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 321);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabOne_Height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabOne_Width)).EndInit();
            this.tab1_panelMenuStrip.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel tabOnePanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown tabOne_Height;
        private System.Windows.Forms.NumericUpDown tabOne_Width;
        private System.Windows.Forms.ContextMenuStrip tab1_panelMenuStrip;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel tabTwo_Panel;
        private System.Windows.Forms.ToolStripMenuItem tab1_moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tab1_stopToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tabTwoComboxFigure;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tabTwoComboxColor;
        private System.Windows.Forms.ComboBox tabTwoComboxBrush;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tabThreeButColor;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel tabThree_Panel;
        private System.Windows.Forms.ToolStripButton tab3_save;
        private System.Windows.Forms.ToolStripButton tab3_save_buffer;
        private System.Windows.Forms.ToolStripButton tab3_open;
        private System.Windows.Forms.ToolStripButton tab3_open_buffer;
        private System.Windows.Forms.Panel tabFour_Panel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
    }
}

