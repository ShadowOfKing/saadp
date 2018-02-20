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
        public Form1()
        {
            data = null;
            inputForm = new FormInput();
            InitializeComponent();
        }


        private void ChangeMode(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {
            var path = this.input__file.Text;
            try
            {
                data = Sortes.ReadData(path);
            } catch(Exception ex)
            {
                MessageBox.Show("Ошибка при считывании входных данных. " + ex.Message);
            }
            this.input__count.Text = data.Count.ToString();
            this.input__count_to.Text = data.Count.ToString();
            inputForm.SetTable(data);
        }
        private void ChangeFolder(object sender, EventArgs e)
        {

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

        }

        private void OpenInputWindow(object sender, EventArgs e)
        {

        }
    }
}
