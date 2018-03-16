using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lab1;

namespace Lab1_WForms
{
    public partial class FormOutput : Form
    {
        private class GraphParam
        {
            public string Name;
            public string Text;
            public Control Parent;

            public GraphParam(string name, string text, Control parent)
            {
                Name = name;
                Text = text;
                Parent = parent;
            }
        }

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
        List<SortResult> results;
        short chartsCount;
        string[] sortNames;
        List<Chart> graphs;

        public FormOutput()
        {
            InitializeComponent();
            Empty = true;
            results = new List<SortResult>();
            chartsCount = 3;
            sortNames = new string[] { "Гномья", "Пузырёк", "Шелла", "Слиянием" };
            var graphParams = new GraphParam[] {
                new GraphParam("time_rand", "Случайный набор", this.output__tab_time),
                new GraphParam("time_inc", "Возрастающий набор", this.output__tab_time),
                new GraphParam("time_dec", "Убывающий набор", this.output__tab_time),
                new GraphParam("iterations_rand", "Случайный набор", this.output__tab_iterations),
                new GraphParam("iterations_inc", "Возрастающий набор", this.output__tab_iterations),
                new GraphParam("iterations_dec", "Убывающий набор", this.output__tab_iterations),
                new GraphParam("swaps_rand", "Случайный набор", this.output__tab_swaps),
                new GraphParam("swaps_inc", "Возрастающий набор", this.output__tab_swaps),
                new GraphParam("swaps_dec", "Убывающий набор", this.output__tab_swaps),
                new GraphParam("assigments_rand", "Случайный набор", this.output__tab_assigments),
                new GraphParam("assigments_inc", "Возрастающий набор", this.output__tab_assigments),
                new GraphParam("assigments_dec", "Убывающий набор", this.output__tab_assigments)
            };

            graphs = new List<Chart>();
            foreach (var i in graphParams)
            {
                graphs.Add(GenerateGraph(i.Parent, i.Name, i.Text));
            }
        }

        private void CloseInputForm(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetTable(List<SortResult> data)
        {
            Empty = false;
            this.output__table.Rows.Clear();
            chartsCount = 0;
            for (var i = 0; i < data.Count; i++)
            {
                var el = data[i];
                string sortName = el.SortType == Sort<WeatherData>.Gnome ? "Гномья" : el.SortType == Sort<WeatherData>.Bubble ? "Пузырёк" : el.SortType == Sort<WeatherData>.Shells ? "Шелла" : "Слияние";
                string dataType = el.DataType == 0 ? "Случайный набор" : el.DataType == 1 ? "Возрастающий набор" : "Убывающий набор";
                this.output__table.Rows.Add(sortName, el.ItemsCount, dataType, ((double)el.Time) / 1000, el.Iterations, el.Swaps, el.Assigments);
                if (el.DataType == 0)
                {
                    if (chartsCount != 1 && chartsCount != 3 && chartsCount != 5 && chartsCount < 7) {
                        chartsCount++;
                    }
                } else if (el.DataType == 1)
                {
                    if (chartsCount != 2 && chartsCount != 3 && chartsCount != 6 && chartsCount < 7)
                    {
                        chartsCount += 2;
                    }

                } else
                {
                    if (chartsCount < 4)
                    {
                        chartsCount += 4;
                    }

                }
            }
            if (chartsCount == 2 || chartsCount == 4)
            {
                chartsCount = 1;
            } else if (chartsCount == 3 || chartsCount == 5 || chartsCount == 6)
            {
                chartsCount = 2;
            } else if (chartsCount >= 7 || chartsCount == 0)
            {
                chartsCount = 3;
            }
            results = new List<SortResult>(data);
            foreach (var graph in graphs) { 
                SetGraphs(graph);
            }
        }
        private void graph_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var parent = (System.Windows.Forms.Panel)sender;
            //MessageBox.Show(parent.Name, "Отрисовано", MessageBoxButtons.OK);
            parent.Height = parent.Parent.Height / 3;
        }
        private void msgraph_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var chart = (Chart)sender;
            //MessageBox.Show(chart.Name, "Отрисовано", MessageBoxButtons.OK);
            chart.Height = chart.Parent.Height / chartsCount;
        }
        private void SetGraphs(Chart chart)
        {
            for (var i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].Points.Clear();
            }
            var dataType = -1;
            switch (chart.Name)
            {
                case "output__graph__iterations_rand":
                case "output__graph__time_rand":
                case "output__graph__swaps_rand":
                case "output__graph__assigments_rand":
                    dataType = 0;
                    break;
                case "output__graph__iterations_inc":
                case "output__graph__time_inc":
                case "output__graph__swaps_inc":
                case "output__graph__assigments_inc":
                    dataType = 1;
                    break;
                case "output__graph__iterations_dec":
                case "output__graph__time_dec":
                case "output__graph__swaps_dec":
                case "output__graph__assigments_dec":
                    dataType = 2;
                    break;
            }
            if (dataType == -1 || results.Count == 0)
            {
                return;
            }

            var paramType = -1;
            switch (chart.Name)
            {
                case "output__graph__time_rand":
                case "output__graph__time_inc":
                case "output__graph__time_dec":
                    paramType = 0;
                    break;
                case "output__graph__iterations_rand":
                case "output__graph__iterations_inc":
                case "output__graph__iterations_dec":
                    paramType = 1;
                    break;
                case "output__graph__swaps_rand":
                case "output__graph__swaps_inc":
                case "output__graph__swaps_dec":
                    paramType = 2;
                    break;
                case "output__graph__assigments_rand":
                case "output__graph__assigments_inc":
                case "output__graph__assigments_dec":
                    paramType = 3;
                    break;
            }
            var hide = true;
            for (var i = 0; i < results.Count; i++)
            {
                if (results[i].DataType == dataType)
                {
                    var result = results[i];
                    var sort = result.SortType;
                    string sortName = sort == Sort<WeatherData>.Bubble ? "Пузырёк" : sort == Sort<WeatherData>.Shells ? "Шелла" : 
                        sort == Sort<WeatherData>.Merge ? "Слиянием" : "Гномья";
                    int index = -1;
                    for (var ii = 0; ii < sortNames.Length; ii++)
                    {
                        if (sortNames[ii] == sortName)
                        {
                            index = ii;
                            ii = sortNames.Length;
                        }
                    }
                    if (index == -1)
                    {
                        continue;
                    }
                    chart.Series[index].Points.AddXY(result.ItemsCount, paramType == 0 ? result.Time : paramType == 1 ? result.Iterations 
                        : paramType == 2 ? result.Swaps : result.Assigments);
                    hide = false;
                }
            }
            for (var i = 0; i < chart.Series.Count; i++)
            {
                if (chart.Series[i].Points.Count == 0)
                {
                    chart.Series[i].Enabled = false;
                } else
                {
                    chart.Series[i].Enabled = true;
                }
            }
            if (hide == true)
            {
                chart.Hide();
            }  else
            {
                chart.Show();
            }
        }

        private Chart GenerateGraph(Control parent, string name, string text)
        {
            var graphName = "output__graph__" + name;

            Chart graph = new Chart();
            ((ISupportInitialize)(graph)).BeginInit();

            short graphIndex = (short)parent.Controls.Count;
            
            graph.ChartAreas.Add(new ChartArea(graphName + "_area"));
            graph.Dock = DockStyle.Top;
            graph.Legends.Add(new Legend(graphName + "_legend"));
            graph.Location = new Point(0, 0);
            graph.Name = graphName;
            graph.Size = new Size(1000, 114);
            graph.TabIndex = 1;
            graph.Text = text;
            graph.Paint += new PaintEventHandler(this.msgraph_Paint);
            graph.Series.Clear();
            for (var i = 0; i < sortNames.Length; i++)
            {
                Series series = new Series();   
                series.ChartArea = graphName + "_area";
                series.ChartType = SeriesChartType.Spline;
                series.Legend = graphName + "_legend";
                series.Name = sortNames[i];
                graph.Series.Add(series);
            }
            parent.Controls.Add(graph);
            return graph;
        }
    }
}
