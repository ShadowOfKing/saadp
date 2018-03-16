using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Lab1;
using Lab2_Wforms;

namespace Lab2_WForms
{
    public partial class Form1 : Form
    {
        private class SortResult
        {
            bool ElementsType { get; }
            short SortType { get; }
            int Count { get; }
            long Time { get; }

            public SortResult(bool elementType, short sortType, int count, long time)
            {
                ElementsType = elementType;
                SortType = sortType;
                Count = count;
                Time = time;
            }
        }

        bool multiple;
        List<SortResult> results;
        OutputForm outputForm;

        public Form1()
        {
            InitializeComponent();
            results = new List<SortResult>();
            outputForm = new OutputForm();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "text files (*.text)|*.txt|input files (*.in)|*.in|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var path = dialog.FileName;
                    this.input__file.Text = path;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при считывании входных данных. " + ex.Message);
                    return;
                }
            }
        }
        
        private void OpenOutWindow(object sender, EventArgs e)
        {
            
        }

        private void SortData(object sender, EventArgs e)
        {
            string inputFile = this.input__file.Text;
            string copyFileName = "Lab2.Wforms.TempInput";
            var isNumber = this.input__dataType_number.Checked;
            foreach (var i in input__sortType.CheckedIndices)
            {
                Sortes.OutSortF sort = null;
                switch (int.Parse(i.ToString()))
                {
                    case 0:
                        if (isNumber)
                        {
                            sort = OutSort<double>.Simple;
                        } else
                        {
                            sort = OutSort<WeatherData>.Simple;
                        }
                        break;
                    case 1:
                        if (isNumber)
                        {
                            sort = OutSort<double>.Nature;
                        }
                        else
                        {
                            sort = OutSort<WeatherData>.Nature;
                        }
                        break;
                    case 2:
                        if (isNumber)
                        {
                            sort = OutSort<double>.Multiple;
                        }
                        else
                        {
                            sort = OutSort<WeatherData>.Multiple;
                        }
                        break;
                }
                File.Copy(inputFile, copyFileName, true);
                sort(copyFileName);
            }
        }

        private void SelectSortType(object sender, EventArgs e)
        {

        }

        private void ClearStatistic(object sender, EventArgs e)
        {
            this.results.Clear();
            outputForm.Empty = true;
        }
    }
}
