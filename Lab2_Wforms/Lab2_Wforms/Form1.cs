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
        public class SortResult
        {
            public bool ElementsType { get; }
            public short SortType { get; }
            public long Count { get; }
            public long Time { get; }

            public SortResult(bool elementType, short sortType, long count, long time)
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
            dialog.Filter = "input files (*.in)|*.in|text files (*.txt)|*.txt|All files (*.*)|*.*";
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
            outputForm.AddData(this.results);
            if (outputForm.Empty)
            {
                MessageBox.Show("Ошибка. Статистика сортировки пуста.");
                return;
            }
            outputForm.ShowDialog();
            this.results.Clear();
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
                        sort = OutSort.Simple;
                        break;
                    case 1:
                        sort = OutSort.Nature;
                        break;
                    case 2:
                        sort = OutSort.Multiple;
                        break;
                }
                File.Copy(inputFile, copyFileName, true);
                try
                {
                    sort(copyFileName, isNumber);
                } catch(Exception ex)
                {
                    MessageBox.Show("Ошибка. " + ex.Message);
                    return;
                } finally
                {
                    File.Delete(copyFileName);
                }
                this.results.Add(new SortResult(isNumber, short.Parse(i.ToString()), OutSort.Count, OutSort.Time));
            }
        }

        private void SelectSortType(object sender, EventArgs e)
        {

        }

        private void ClearStatistic(object sender, EventArgs e)
        {
            this.results.Clear();
            outputForm.ClearData();
        }
    }
}
