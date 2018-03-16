using System.Drawing;

namespace Lab3_Wforms
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.input_table = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.output_time = new System.Windows.Forms.TextBox();
            this.output_target = new System.Windows.Forms.TextBox();
            this.output_number = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.input_trains = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_table)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 202);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.input_table);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(667, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Список поездов";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // input_table
            // 
            this.input_table.AllowUserToAddRows = false;
            this.input_table.AllowUserToDeleteRows = false;
            this.input_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.input_table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.input_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.input_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Target,
            this.Time});
            this.input_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_table.Location = new System.Drawing.Point(0, 0);
            this.input_table.Name = "input_table";
            this.input_table.Size = new System.Drawing.Size(667, 176);
            this.input_table.TabIndex = 0;
            this.input_table.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeTable);
            this.input_table.BackgroundColor = Color.White;
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Number.HeaderText = "Номер поезда";
            this.Number.Name = "Number";
            // 
            // Target
            // 
            this.Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Target.HeaderText = "Пункт назначения";
            this.Target.Name = "Target";
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Time.HeaderText = "Время отправления";
            this.Time.Name = "Time";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.output_time);
            this.tabPage2.Controls.Add(this.output_target);
            this.tabPage2.Controls.Add(this.output_number);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.input_trains);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(667, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Поиск поезда";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // output_time
            // 
            this.output_time.Location = new System.Drawing.Point(382, 131);
            this.output_time.Name = "output_time";
            this.output_time.ReadOnly = true;
            this.output_time.Size = new System.Drawing.Size(254, 20);
            this.output_time.TabIndex = 9;
            // 
            // output_target
            // 
            this.output_target.Location = new System.Drawing.Point(382, 92);
            this.output_target.Name = "output_target";
            this.output_target.ReadOnly = true;
            this.output_target.Size = new System.Drawing.Size(254, 20);
            this.output_target.TabIndex = 8;
            // 
            // output_number
            // 
            this.output_number.Location = new System.Drawing.Point(382, 49);
            this.output_number.Name = "output_number";
            this.output_number.ReadOnly = true;
            this.output_number.Size = new System.Drawing.Size(254, 20);
            this.output_number.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Время отправки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пункт назначения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер поезда";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список поездов";
            // 
            // input_trains
            // 
            this.input_trains.FormattingEnabled = true;
            this.input_trains.Location = new System.Drawing.Point(18, 49);
            this.input_trains.Name = "input_trains";
            this.input_trains.Size = new System.Drawing.Size(183, 95);
            this.input_trains.TabIndex = 2;
            this.input_trains.SelectedIndexChanged += new System.EventHandler(this.SelectTrain);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 202);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.input_table)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView input_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TextBox output_time;
        private System.Windows.Forms.TextBox output_target;
        private System.Windows.Forms.TextBox output_number;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox input_trains;
    }
}

