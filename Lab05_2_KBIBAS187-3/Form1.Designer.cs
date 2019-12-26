namespace Lab05_2_KBIBAS187_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаВXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузкаИзXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКартОчкуWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьКартОчкуPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.действияНадXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доабвитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.действияНадXMLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузкаВXMLToolStripMenuItem,
            this.загрузкаИзXMLToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // загрузкаВXMLToolStripMenuItem
            // 
            this.загрузкаВXMLToolStripMenuItem.Name = "загрузкаВXMLToolStripMenuItem";
            this.загрузкаВXMLToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.загрузкаВXMLToolStripMenuItem.Text = ".txt to .XML";
            this.загрузкаВXMLToolStripMenuItem.Click += new System.EventHandler(this.загрузкаВXMLToolStripMenuItem_Click);
            // 
            // загрузкаИзXMLToolStripMenuItem
            // 
            this.загрузкаИзXMLToolStripMenuItem.Name = "загрузкаИзXMLToolStripMenuItem";
            this.загрузкаИзXMLToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.загрузкаИзXMLToolStripMenuItem.Text = "Загрузить .XML в ListBox";
            this.загрузкаИзXMLToolStripMenuItem.Click += new System.EventHandler(this.загрузкаИзXMLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКартОчкуWordToolStripMenuItem,
            this.создатьКартОчкуPDFToolStripMenuItem,
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem2.Text = "Задания";
            // 
            // создатьКартОчкуWordToolStripMenuItem
            // 
            this.создатьКартОчкуWordToolStripMenuItem.Name = "создатьКартОчкуWordToolStripMenuItem";
            this.создатьКартОчкуWordToolStripMenuItem.Size = new System.Drawing.Size(650, 22);
            this.создатьКартОчкуWordToolStripMenuItem.Text = "Создать картОчку Word";
            this.создатьКартОчкуWordToolStripMenuItem.Click += new System.EventHandler(this.создатьКартОчкуWordToolStripMenuItem_Click);
            // 
            // создатьКартОчкуPDFToolStripMenuItem
            // 
            this.создатьКартОчкуPDFToolStripMenuItem.Name = "создатьКартОчкуPDFToolStripMenuItem";
            this.создатьКартОчкуPDFToolStripMenuItem.Size = new System.Drawing.Size(650, 22);
            this.создатьКартОчкуPDFToolStripMenuItem.Text = "Создать картОчку PDF";
            this.создатьКартОчкуPDFToolStripMenuItem.Click += new System.EventHandler(this.создатьКартОчкуPDFToolStripMenuItem_Click);
            // 
            // определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem
            // 
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem.Name = "определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщения" +
    "ToolStripMenuItem";
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem.Size = new System.Drawing.Size(650, 22);
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem.Text = "Определить общее количество студентов указанного курса. Информацию выдавать в вид" +
    "е сообщения. ";
            this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem.Click += new System.EventHandler(this.определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // действияНадXMLToolStripMenuItem
            // 
            this.действияНадXMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.доабвитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem});
            this.действияНадXMLToolStripMenuItem.Name = "действияНадXMLToolStripMenuItem";
            this.действияНадXMLToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.действияНадXMLToolStripMenuItem.Text = "Действия над XML";
            // 
            // доабвитьToolStripMenuItem
            // 
            this.доабвитьToolStripMenuItem.Name = "доабвитьToolStripMenuItem";
            this.доабвитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.доабвитьToolStripMenuItem.Text = "Доабвить";
            this.доабвитьToolStripMenuItem.Click += new System.EventHandler(this.доабвитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Факультет:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Курс:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата рождения:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Место рождения:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem загрузкаВXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузкаИзXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem создатьКартОчкуWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьКартОчкуPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem определитьОбщееКоличествоСтудентовУказанногоКурсаИнформациюВыдаватьВВидеСообщенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияНадXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доабвитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

