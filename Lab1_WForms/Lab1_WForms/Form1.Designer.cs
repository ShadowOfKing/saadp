namespace Lab1_WForms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.input__mode_multy = new System.Windows.Forms.RadioButton();
            this.input__mode_single = new System.Windows.Forms.RadioButton();
            this.input__sortes = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.input__file = new System.Windows.Forms.TextBox();
            this.input__folder = new System.Windows.Forms.TextBox();
            this.input__name = new System.Windows.Forms.TextBox();
            this.input__inputs = new System.Windows.Forms.CheckedListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.input__count = new System.Windows.Forms.TextBox();
            this.input__count_to = new System.Windows.Forms.TextBox();
            this.label__count = new System.Windows.Forms.Label();
            this.label__count_to = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.input__mode_multy);
            this.groupBox1.Controls.Add(this.input__mode_single);
            this.groupBox1.Location = new System.Drawing.Point(12, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // input__mode_multy
            // 
            this.input__mode_multy.AutoSize = true;
            this.input__mode_multy.Location = new System.Drawing.Point(7, 43);
            this.input__mode_multy.Name = "input__mode_multy";
            this.input__mode_multy.Size = new System.Drawing.Size(133, 17);
            this.input__mode_multy.TabIndex = 1;
            this.input__mode_multy.TabStop = true;
            this.input__mode_multy.Text = "Проход по диапазону";
            this.input__mode_multy.UseVisualStyleBackColor = true;
            // 
            // input__mode_single
            // 
            this.input__mode_single.AutoSize = true;
            this.input__mode_single.Location = new System.Drawing.Point(7, 20);
            this.input__mode_single.Name = "input__mode_single";
            this.input__mode_single.Size = new System.Drawing.Size(89, 17);
            this.input__mode_single.TabIndex = 0;
            this.input__mode_single.TabStop = true;
            this.input__mode_single.Text = "Один проход";
            this.input__mode_single.UseVisualStyleBackColor = true;
            // 
            // input__sortes
            // 
            this.input__sortes.FormattingEnabled = true;
            this.input__sortes.Items.AddRange(new object[] {
            "Гномья",
            "Пузырёк",
            "Шелла",
            "Слиянием"});
            this.input__sortes.Location = new System.Drawing.Point(524, 204);
            this.input__sortes.Name = "input__sortes";
            this.input__sortes.Size = new System.Drawing.Size(120, 94);
            this.input__sortes.TabIndex = 0;
            this.input__sortes.SelectedIndexChanged += new System.EventHandler(this.SelectSortes);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(551, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Выбрать папку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ChangeFolder);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(551, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Сохранить ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SaveResult);
            // 
            // input__file
            // 
            this.input__file.Location = new System.Drawing.Point(156, 42);
            this.input__file.Name = "input__file";
            this.input__file.ReadOnly = true;
            this.input__file.Size = new System.Drawing.Size(358, 20);
            this.input__file.TabIndex = 4;
            // 
            // input__folder
            // 
            this.input__folder.Location = new System.Drawing.Point(156, 86);
            this.input__folder.Name = "input__folder";
            this.input__folder.ReadOnly = true;
            this.input__folder.Size = new System.Drawing.Size(358, 20);
            this.input__folder.TabIndex = 5;
            // 
            // input__name
            // 
            this.input__name.Location = new System.Drawing.Point(156, 135);
            this.input__name.Name = "input__name";
            this.input__name.Size = new System.Drawing.Size(358, 20);
            this.input__name.TabIndex = 6;
            // 
            // input__inputs
            // 
            this.input__inputs.FormattingEnabled = true;
            this.input__inputs.Items.AddRange(new object[] {
            "Случайный набор",
            "Возрастающий набор",
            "Убывающий набор"});
            this.input__inputs.Location = new System.Drawing.Point(672, 204);
            this.input__inputs.Name = "input__inputs";
            this.input__inputs.Size = new System.Drawing.Size(135, 94);
            this.input__inputs.TabIndex = 7;
            this.input__inputs.SelectedIndexChanged += new System.EventHandler(this.SelectInputs);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(672, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(135, 43);
            this.button4.TabIndex = 8;
            this.button4.Text = "Посмотреть входные данные";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OpenInputWindow);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Выходная папка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Имя выходного файла";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Количество элементов";
            // 
            // input__count
            // 
            this.input__count.Location = new System.Drawing.Point(387, 204);
            this.input__count.Name = "input__count";
            this.input__count.Size = new System.Drawing.Size(127, 20);
            this.input__count.TabIndex = 12;
            // 
            // input__count_to
            // 
            this.input__count_to.Location = new System.Drawing.Point(387, 238);
            this.input__count_to.Name = "input__count_to";
            this.input__count_to.Size = new System.Drawing.Size(127, 20);
            this.input__count_to.TabIndex = 13;
            // 
            // label__count
            // 
            this.label__count.AutoSize = true;
            this.label__count.Location = new System.Drawing.Point(367, 207);
            this.label__count.Name = "label__count";
            this.label__count.Size = new System.Drawing.Size(14, 13);
            this.label__count.TabIndex = 14;
            this.label__count.Text = "С";
            // 
            // label__count_to
            // 
            this.label__count_to.AutoSize = true;
            this.label__count_to.Location = new System.Drawing.Point(367, 243);
            this.label__count_to.Name = "label__count_to";
            this.label__count_to.Size = new System.Drawing.Size(21, 13);
            this.label__count_to.TabIndex = 15;
            this.label__count_to.Text = "По";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(672, 115);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 43);
            this.button5.TabIndex = 16;
            this.button5.Text = "Посмотреть выходные данные";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OpenOutWindow);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 324);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(795, 43);
            this.button6.TabIndex = 17;
            this.button6.Text = "Отсортировать";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 386);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label__count);
            this.Controls.Add(this.input__count_to);
            this.Controls.Add(this.input__count);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.input__inputs);
            this.Controls.Add(this.input__name);
            this.Controls.Add(this.input__folder);
            this.Controls.Add(this.input__file);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input__sortes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label__count_to);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox input__sortes;
        private System.Windows.Forms.RadioButton input__mode_multy;
        private System.Windows.Forms.RadioButton input__mode_single;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox input__file;
        private System.Windows.Forms.TextBox input__folder;
        private System.Windows.Forms.TextBox input__name;
        private System.Windows.Forms.CheckedListBox input__inputs;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox input__count;
        private System.Windows.Forms.TextBox input__count_to;
        private System.Windows.Forms.Label label__count;
        private System.Windows.Forms.Label label__count_to;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

