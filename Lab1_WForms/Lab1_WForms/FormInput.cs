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
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void CloseInputForm(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetTable(List<WeatherData> data)
        {
            this.output__table.Rows.Clear();
            for (var i = 0; i < data.Count; i++)
            {
                var el = data[i];
                this.output__table.Rows.Add(el.Time, el.T, el.P0, el.P, el.Pa, el.U, el.DD, el.Ff, el.N, el.WW, el.W1, el.W2, el.Tn, el.Tx, el.Cl, el.Nh, el.H, el.Cm, el.Ch, el.VV, el.Td, el.RRR, el.tR);
            }
        }
    }
}
