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
using System.IO;
using Newtonsoft.Json;

namespace Lab1_WForms
{
    public partial class Form1 : Form
    {
        List<WeatherData> data;
        FormInput inputForm;
        FormOutput outputForm;
        bool multiple;
        List<SortResult> results;

        public Form1()
        {
            data = null;
            inputForm = new FormInput();
            outputForm = new FormOutput();
            InitializeComponent();
            ChangeMode(null, null);
            results = new List<SortResult>();
        }
        
        private void ChangeMode(object sender, EventArgs e)
        {
            multiple = input__mode_multy.Checked;
            if (multiple)
            {
                this.label__count.Show();
                this.label__count_to.Show();
                this.label_step.Show();
                this.input__count_to.Show();
                this.input__step.Show();
            }
            else
            {
                this.label__count.Hide();
                this.label__count_to.Hide();
                this.label_step.Hide();
                this.input__count_to.Hide();
                this.input__step.Hide();
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
            if (data != null) { 
                this.input__count.Value = 1;
                this.input__count_to.Value = data.Count;
                this.input__step.Value = data.Count / 20;
                this.input__mode_multy.Checked = true;
                inputForm.Empty = true;
            }
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
            var errors = false;
            if (string.IsNullOrWhiteSpace(this.input__folder.Text))
            {
                MessageBox.Show("Не выбрана папка для записи файла!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (string.IsNullOrWhiteSpace(this.input__name.Text))
            {
                MessageBox.Show("Не выбрано имя файла!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (results.Count == 0)
            {
                MessageBox.Show("Отсутствуют отсортированные данные!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (errors == true)
            {
                return;
            }
            Sortes.WriteData(Path.Combine(this.input__folder.Text, this.input__name.Text), JsonConvert.SerializeObject(results));
        }

        private void SelectSortes(object sender, EventArgs e)
        {

        }

        private void SelectInputs(object sender, EventArgs e)
        {

        }

        private void OpenOutWindow(object sender, EventArgs e)
        {
            if (results.Count == 0)
            {
                MessageBox.Show("Отсутствуют отсортированные данные!", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if (outputForm.Empty && results != null && results.Count > 0)
            {
                outputForm.SetTable(results);
            }
            outputForm.Show();
        }

        private void OpenInputWindow(object sender, EventArgs e)
        {
            if (inputForm.Empty && data != null && data.Count > 0) {
                inputForm.SetTable(data);
            }
            inputForm.Show();
        }

        private void SortData(object sender, EventArgs e)
        {
            bool errors = false;
            if (input__sortes.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Не выбран тип сортировки!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (input__inputs.CheckedIndices.Count == 0)
            {
                MessageBox.Show("Не выбран тип данных!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("Пустые входные данные!", "Ошибка", MessageBoxButtons.OK);
                errors = true;
            }
            if (errors)
            {
                return;
            }
            var startIndex = (int)this.input__count.Value;
            int endIndex, step;
            if (multiple)
            {
                endIndex = (int)this.input__count_to.Value;
            } else
            {
                endIndex = startIndex;
            }
            step = (int)this.input__step.Value;
            results.Clear();
            foreach (var i in input__sortes.CheckedIndices)
            {
                Sortes.SortF sort = null;
                switch (int.Parse(i.ToString()))
                {
                    case 0:
                        sort = Sort<WeatherData>.Gnome;
                        break;
                    case 1:
                        sort = Sort<WeatherData>.Bubble;
                        break;
                    case 2:
                        sort = Sort<WeatherData>.Shells;
                        break;
                    case 3:
                        sort = Sort<WeatherData>.Merge;
                        break;
                }
                foreach (var j in input__inputs.CheckedIndices)
                {
                    short dataType = (short)((int)j);
                    var currentData = new List<WeatherData>(data);
                    if (dataType >= 2)
                    {
                        Sort<WeatherData>.Merge(ref currentData);
                    }
                    if (dataType == 3)
                    {
                        currentData.Reverse();
                    }

                    for (var ind = startIndex; ind <= endIndex; ind += step)
                    {
                        var array = new List<WeatherData>();
                        for (var k = 0; k < ind; k++)
                        {
                            array.Add(data[k % data.Count]);
                        }
                        sort(ref array);
                        results.Add(new SortResult(sort, dataType, array.Count, Sort<WeatherData>.Time, Sort<WeatherData>.Iterations, Sort<WeatherData>.Swaps, Sort<WeatherData>.Assigments));
                    }
                }
            }
            outputForm.Empty = true;
            MessageBox.Show("Сортировка завершена", "Информация", MessageBoxButtons.OK);
        }
    }
}
