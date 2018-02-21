using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1;

namespace Lab1_WForms
{
    public partial class Form1 : Form
    {
        List<WeatherData> data;
        FormInput inputForm;
        FormOutput outputForm;
        bool multiple;
        public Form1()
        {
            data = null;
            inputForm = new FormInput();
            outputForm = new FormOutput();
            InitializeComponent();
            ChangeMode(null, null);
        }


        private void ChangeMode(object sender, EventArgs e)
        {
            multiple = input__mode_multy.Checked;
            if (multiple)
            {
                this.label__count.Show();
                this.label__count_to.Show();
                this.input__count_to.Show();
            }
            else
            {
                this.label__count.Hide();
                this.label__count_to.Hide();
                this.input__count_to.Hide();
            }

        }

        private void OpenFile(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var path = dialog.FileName;
                    this.input__file.Text = path;
                    data = Sortes.ReadData(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при считывании входных данных. " + ex.Message);
                    return;
                }
            }
            this.input__count.Value = 1;
            this.input__count.Minimum = 1;
            this.input__count.Maximum = data.Count;
            this.input__count_to.Minimum = 1;
            this.input__count_to.Maximum = data.Count;
            this.input__count_to.Value = data.Count;
            inputForm.SetTable(data);
        }
        private void ChangeFolder(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.input__folder.Text = dialog.SelectedPath;
            }

        }

        private void SaveResult(object sender, EventArgs e)
        {

        }

        private void SelectSortes(object sender, EventArgs e)
        {

        }

        private void SelectInputs(object sender, EventArgs e)
        {

        }

        private void OpenOutWindow(object sender, EventArgs e)
        {
            outputForm.Show();
        }

        private void OpenInputWindow(object sender, EventArgs e)
        {
            inputForm.Show();
        }

        private void SortData(object sender, EventArgs e)
        {
            int startIndex, endIndex;
            startIndex = (int)this.input__count.Value;
            if (multiple)
            {
                endIndex = (int)this.input__count_to.Value;
            } else
            {
                endIndex = startIndex;
            }
            var array = new List<WeatherData>();

            for (var i = startIndex; i <= endIndex; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    array.Add(data[j % data.Count]);
                }
            }
        }
    }
}
