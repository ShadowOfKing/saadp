namespace Lab2_Wforms
{
    partial class OutputForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.output_graphs = new System.Windows.Forms.TabPage();
            this.output_data_result = new System.Windows.Forms.DataGridView();
            this.sortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortElemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortElemCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.output_data_result)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.output_graphs);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.output_data_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(957, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // output_graphs
            // 
            this.output_graphs.Location = new System.Drawing.Point(4, 22);
            this.output_graphs.Name = "output_graphs";
            this.output_graphs.Padding = new System.Windows.Forms.Padding(3);
            this.output_graphs.Size = new System.Drawing.Size(957, 388);
            this.output_graphs.TabIndex = 1;
            this.output_graphs.Text = "Графики";
            this.output_graphs.UseVisualStyleBackColor = true;
            // 
            // output_data_result
            // 
            this.output_data_result.AllowUserToAddRows = false;
            this.output_data_result.AllowUserToDeleteRows = false;
            this.output_data_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.output_data_result.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.output_data_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.output_data_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sortType,
            this.sortElemType,
            this.sortElemCount,
            this.sortTime});
            this.output_data_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output_data_result.Location = new System.Drawing.Point(3, 3);
            this.output_data_result.Name = "output_data_result";
            this.output_data_result.ReadOnly = true;
            this.output_data_result.Size = new System.Drawing.Size(951, 382);
            this.output_data_result.TabIndex = 0;
            // 
            // sortType
            // 
            this.sortType.HeaderText = "Тип сортировки";
            this.sortType.Name = "sortType";
            this.sortType.ReadOnly = true;
            // 
            // sortElemType
            // 
            this.sortElemType.HeaderText = "Тип элементов";
            this.sortElemType.Name = "sortElemType";
            this.sortElemType.ReadOnly = true;
            // 
            // sortElemCount
            // 
            this.sortElemCount.HeaderText = "Количество элементов";
            this.sortElemCount.Name = "sortElemCount";
            this.sortElemCount.ReadOnly = true;
            // 
            // sortTime
            // 
            this.sortTime.HeaderText = "Время сортировки (сек)";
            this.sortTime.Name = "sortTime";
            this.sortTime.ReadOnly = true;
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 489);
            this.Controls.Add(this.tabControl1);
            this.Name = "OutputForm";
            this.Text = "OutputForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.output_data_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView output_data_result;
        private System.Windows.Forms.TabPage output_graphs;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortElemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortElemCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortTime;
    }
}