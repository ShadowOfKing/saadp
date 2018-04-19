namespace Lab2_WForms
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
            this.button1 = new System.Windows.Forms.Button();
            this.input__file = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.input__dataType_struct = new System.Windows.Forms.RadioButton();
            this.input__dataType_number = new System.Windows.Forms.RadioButton();
            this.input__sortType = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(551, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenFile);
            // 
            // input__file
            // 
            this.input__file.Location = new System.Drawing.Point(156, 42);
            this.input__file.Name = "input__file";
            this.input__file.ReadOnly = true;
            this.input__file.Size = new System.Drawing.Size(358, 20);
            this.input__file.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Входной файл";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 222);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(632, 41);
            this.button5.TabIndex = 16;
            this.button5.Text = "Посмотреть статистику сортировки";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OpenOutWindow);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(369, 159);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(275, 43);
            this.button6.TabIndex = 17;
            this.button6.Text = "Отсортировать";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.SortData);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.input__dataType_struct);
            this.groupBox1.Controls.Add(this.input__dataType_number);
            this.groupBox1.Location = new System.Drawing.Point(19, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип данных";
            // 
            // input__dataType_struct
            // 
            this.input__dataType_struct.AutoSize = true;
            this.input__dataType_struct.Location = new System.Drawing.Point(137, 19);
            this.input__dataType_struct.Name = "input__dataType_struct";
            this.input__dataType_struct.Size = new System.Drawing.Size(111, 17);
            this.input__dataType_struct.TabIndex = 1;
            this.input__dataType_struct.TabStop = true;
            this.input__dataType_struct.Text = "Массив структур";
            this.input__dataType_struct.UseVisualStyleBackColor = true;
            // 
            // input__dataType_number
            // 
            this.input__dataType_number.AutoSize = true;
            this.input__dataType_number.Checked = true;
            this.input__dataType_number.Location = new System.Drawing.Point(6, 19);
            this.input__dataType_number.Name = "input__dataType_number";
            this.input__dataType_number.Size = new System.Drawing.Size(96, 17);
            this.input__dataType_number.TabIndex = 0;
            this.input__dataType_number.TabStop = true;
            this.input__dataType_number.Text = "Массив чисел";
            this.input__dataType_number.UseVisualStyleBackColor = true;
            // 
            // input__sortType
            // 
            this.input__sortType.FormattingEnabled = true;
            this.input__sortType.Items.AddRange(new object[] {
            "Простая",
            "Естественная",
            "Многопутёвая сбалансированная"});
            this.input__sortType.Location = new System.Drawing.Point(369, 91);
            this.input__sortType.Name = "input__sortType";
            this.input__sortType.Size = new System.Drawing.Size(275, 49);
            this.input__sortType.TabIndex = 19;
            this.input__sortType.SelectedIndexChanged += new System.EventHandler(this.SelectSortType);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 159);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(281, 43);
            this.button4.TabIndex = 20;
            this.button4.Text = "Очистить статистику";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ClearStatistic);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 282);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.input__sortType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input__file);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Внешние сортировки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox input__file;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton input__dataType_struct;
        private System.Windows.Forms.RadioButton input__dataType_number;
        private System.Windows.Forms.CheckedListBox input__sortType;
        private System.Windows.Forms.Button button4;
    }
}

