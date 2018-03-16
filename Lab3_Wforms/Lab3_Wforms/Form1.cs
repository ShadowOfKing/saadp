using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Wforms
{
    public class Train
    {
        public string Number;
        public string Target;
        public string Time;
    }

    public partial class Form1 : Form
    {
        List<Train> trains;
        public Form1()
        {
            InitializeComponent();
            this.input_table.Rows.Clear();
            foreach (DataGridViewColumn column in this.input_table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            trains = new List<Train>();
            for (var i = 0; i < 5; i++)
            {
                this.input_table.Rows.Add();
                trains.Add(new Train());
            }
        }

        private void SelectTrain(object sender, EventArgs e)
        {
            var list = (ListBox)sender;
            if (list.SelectedItem != null)
            {
                this.output_number.Show();
                this.output_target.Show();
                this.output_time.Show();
                this.label2.Show();
                this.label3.Show();
                this.label4.Show();
                for (var i = 0; i < trains.Count; i++)
                {
                    if (trains[i].Number == list.SelectedItem.ToString())
                    {
                        var train = trains[i];
                        this.output_number.Text = train.Number.ToString();
                        this.output_target.Text = train.Target;
                        this.output_time.Text = train.Time;
                        return;
                    }
                }
            }
            else
            {
                this.output_number.Text = "";
                this.output_target.Text = "";
                this.output_time.Text = "";
                this.output_number.Hide();
                this.output_target.Hide();
                this.output_time.Hide();
                this.label2.Hide();
                this.label3.Hide();
                this.label4.Hide();
            }
        }

        private void ChangeTable(object sender, DataGridViewCellEventArgs e)
        {
            var table = (DataGridView)sender;
            this.input_trains.Items.Clear();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var train = trains[i];
                if (row.Cells[1].Value != null)
                {
                    train.Target = row.Cells[1].Value.ToString();
                } else
                {
                    train.Target = "";
                }
                if (row.Cells[2].Value != null)
                {
                    train.Time = row.Cells[2].Value.ToString();
                } else
                {
                    train.Time = "";
                }
                if (row.Cells[0].Value != null)
                {
                    train.Number = row.Cells[0].Value.ToString();
                } else
                {
                    train.Number = "";
                }
            }
            this.input_table.Rows.Clear();
            if (trains != null && trains.Count > 0)
            {
                trains.Sort((A, B) => {
                    return (!string.IsNullOrWhiteSpace(A.Number) && !string.IsNullOrWhiteSpace(B.Number)
                            ? string.Compare(A.Number, B.Number) : 1);
                });
                for (var i = 0; i < trains.Count; i++)
                {
                    var train = trains[i];
                    this.input_table.Rows.Add(train.Number, train.Target, train.Time);
                    if (!string.IsNullOrWhiteSpace(train.Number)) {
                        this.input_trains.Items.Add(train.Number);
                    }
                }
                SelectTrain(this.input_trains, e);
            }
        }
    }
}
