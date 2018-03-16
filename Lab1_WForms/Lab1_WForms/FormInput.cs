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
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public bool Empty;

        public FormInput()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Empty = true;

        }

        private void CloseInputForm(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetTable(List<WeatherData> data)
        {
            Empty = false;
            this.output__table.Rows.Clear();
            for (var i = 0; i < data.Count; i++)
            {
                var el = data[i];
                this.output__table.Rows.Add(el.Time, el.T, el.P0, el.P, el.Pa, el.U, el.DD, el.Ff, el.N, el.WW, el.W1, el.W2, el.Tn, el.Tx, el.Cl, el.Nh, el.H, el.Cm, el.Ch, el.VV, el.Td, el.RRR, el.tR);
            }
        }
    }
}
