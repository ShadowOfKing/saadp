namespace Lab1_WForms
{
    partial class FormOutput
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
            this.button1 = new System.Windows.Forms.Button();
            this.output__table = new System.Windows.Forms.DataGridView();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iterations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Swaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assigments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.output_tabs = new System.Windows.Forms.TabControl();
            this.output__tab_table = new System.Windows.Forms.TabPage();
            this.output__tab_time = new System.Windows.Forms.TabPage();
            this.output__tab_iterations = new System.Windows.Forms.TabPage();
            this.output__tab_swaps = new System.Windows.Forms.TabPage();
            this.output__tab_assigments = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.output__table)).BeginInit();
            this.output_tabs.SuspendLayout();
            this.output__tab_table.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(28, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(964, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseInputForm);
            // 
            // output__table
            // 
            this.output__table.AllowUserToAddRows = false;
            this.output__table.AllowUserToDeleteRows = false;
            this.output__table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.output__table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.output__table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sort,
            this.Count,
            this.Type,
            this.Time,
            this.Iterations,
            this.Swaps,
            this.Assigments});
            this.output__table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output__table.Location = new System.Drawing.Point(3, 3);
            this.output__table.Name = "output__table";
            this.output__table.ReadOnly = true;
            this.output__table.RowHeadersWidth = 50;
            this.output__table.Size = new System.Drawing.Size(1000, 349);
            this.output__table.TabIndex = 1;
            // 
            // Sort
            // 
            this.Sort.HeaderText = "Сортировка";
            this.Sort.Name = "Sort";
            this.Sort.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество элементов";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип данных";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Время";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // Iterations
            // 
            this.Iterations.HeaderText = "Итерации";
            this.Iterations.Name = "Iterations";
            this.Iterations.ReadOnly = true;
            // 
            // Swaps
            // 
            this.Swaps.HeaderText = "Обмены";
            this.Swaps.Name = "Swaps";
            this.Swaps.ReadOnly = true;
            // 
            // Assigments
            // 
            this.Assigments.HeaderText = "Присваивания";
            this.Assigments.Name = "Assigments";
            this.Assigments.ReadOnly = true;
            // 
            // output_tabs
            // 
            this.output_tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_tabs.Controls.Add(this.output__tab_table);
            this.output_tabs.Controls.Add(this.output__tab_time);
            this.output_tabs.Controls.Add(this.output__tab_iterations);
            this.output_tabs.Controls.Add(this.output__tab_swaps);
            this.output_tabs.Controls.Add(this.output__tab_assigments);
            this.output_tabs.Location = new System.Drawing.Point(0, 0);
            this.output_tabs.Name = "output_tabs";
            this.output_tabs.SelectedIndex = 0;
            this.output_tabs.Size = new System.Drawing.Size(1014, 381);
            this.output_tabs.TabIndex = 2;
            // 
            // output__tab_table
            // 
            this.output__tab_table.Controls.Add(this.output__table);
            this.output__tab_table.Location = new System.Drawing.Point(4, 22);
            this.output__tab_table.Name = "output__tab_table";
            this.output__tab_table.Padding = new System.Windows.Forms.Padding(3);
            this.output__tab_table.Size = new System.Drawing.Size(1006, 355);
            this.output__tab_table.TabIndex = 0;
            this.output__tab_table.Text = "Общая таблица";
            this.output__tab_table.UseVisualStyleBackColor = true;
            // 
            // output__tab_time
            // 
            this.output__tab_time.Location = new System.Drawing.Point(4, 22);
            this.output__tab_time.Name = "output__tab_time";
            this.output__tab_time.Padding = new System.Windows.Forms.Padding(3);
            this.output__tab_time.Size = new System.Drawing.Size(1006, 355);
            this.output__tab_time.TabIndex = 0;
            this.output__tab_time.Text = "Время";
            this.output__tab_time.UseVisualStyleBackColor = true;
            // 
            // output__tab_iterations
            // 
            this.output__tab_iterations.Location = new System.Drawing.Point(4, 22);
            this.output__tab_iterations.Name = "output__tab_iterations";
            this.output__tab_iterations.Padding = new System.Windows.Forms.Padding(3);
            this.output__tab_iterations.Size = new System.Drawing.Size(1006, 355);
            this.output__tab_iterations.TabIndex = 1;
            this.output__tab_iterations.Text = "Итерации";
            this.output__tab_iterations.UseVisualStyleBackColor = true;
            // 
            // output__tab_swaps
            // 
            this.output__tab_swaps.Location = new System.Drawing.Point(4, 22);
            this.output__tab_swaps.Name = "output__tab_swaps";
            this.output__tab_swaps.Padding = new System.Windows.Forms.Padding(3);
            this.output__tab_swaps.Size = new System.Drawing.Size(1006, 355);
            this.output__tab_swaps.TabIndex = 2;
            this.output__tab_swaps.Text = "Обмены";
            this.output__tab_swaps.UseVisualStyleBackColor = true;
            // 
            // output__tab_assigments
            // 
            this.output__tab_assigments.Location = new System.Drawing.Point(4, 22);
            this.output__tab_assigments.Name = "output__tab_assigments";
            this.output__tab_assigments.Padding = new System.Windows.Forms.Padding(3);
            this.output__tab_assigments.Size = new System.Drawing.Size(1006, 355);
            this.output__tab_assigments.TabIndex = 3;
            this.output__tab_assigments.Text = "Присваивания";
            this.output__tab_assigments.UseVisualStyleBackColor = true;
            // 
            // FormOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 435);
            this.Controls.Add(this.output_tabs);
            this.Controls.Add(this.button1);
            this.Name = "FormOutput";
            this.Text = "FormOutput";
            ((System.ComponentModel.ISupportInitialize)(this.output__table)).EndInit();
            this.output_tabs.ResumeLayout(false);
            this.output__tab_table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView output__table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iterations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Swaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assigments;
        private System.Windows.Forms.TabControl output_tabs;
        private System.Windows.Forms.TabPage output__tab_table;
        private System.Windows.Forms.TabPage output__tab_time;
        private System.Windows.Forms.TabPage output__tab_iterations;
        private System.Windows.Forms.TabPage output__tab_swaps;
        private System.Windows.Forms.TabPage output__tab_assigments;
    }
}