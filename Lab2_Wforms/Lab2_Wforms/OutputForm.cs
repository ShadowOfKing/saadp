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

namespace Lab2_Wforms
{
    public partial class OutputForm : Form
    {
        public bool Empty;
        string[] sortNames;
        List<Chart> graphs;
        List<Lab2_WForms.Form1.SortResult> results;

        public OutputForm()
        {
            InitializeComponent();
            Empty = true;
            sortNames = new string[] { "Простая", "Естественная", "Многопутёвая"};
            graphs = new List<Chart>();
            graphs.Add(GenerateGraph(this.output_graphs, "graph_number", "Числа"));
            graphs.Add(GenerateGraph(this.output_graphs, "graph_struct", "Структуры данных"));
            results = new List<Lab2_WForms.Form1.SortResult>();
        }

        public void AddData(List<Lab2_WForms.Form1.SortResult> results)
        {
            if (results.Count > 0) {
                this.Empty = false;
            }
            foreach(var el in results)
            {
                this.output_data_result.Rows.Add(el.SortType == 0 ? "Простая" : el.SortType == 1 ? "Естественная" : "Многопутёвая",
                    el.ElementsType ? "Числа" : "Структуры данных", el.Count, el.Time / 1000.0
                );
                this.results.Add(new Lab2_WForms.Form1.SortResult(el.ElementsType, el.SortType, el.Count, el.Time));
            }
        }
        public void ClearData()
        {
            this.output_data_result.Rows.Clear();
            this.Empty = true;
            results.Clear();
        }

        public void SetGraphs()
        {
            results.Sort((a, b) =>
            {
                return a.Count == b.Count ? (a.SortType == b.SortType ? 0 : a.SortType > b.SortType ? 1 : -1) : a.Count > b.Count ? 1 : -1;
            });
            foreach (var chart in graphs) { 
                for (var i = 0; i < chart.Series.Count; i++)
                {
                    chart.Series[i].Points.Clear();
                }
                var elementsType = false;
                switch (chart.Name)
                {
                    case "output__graph__graph_number":
                        elementsType = true;
                        break;
                    case "output__graph__graph_struct":
                        elementsType = false;
                        break;
                }
                var hide = true;
                for (var i = 0; i < results.Count; i++)
                {
                    if (results[i].ElementsType == elementsType)
                    {
                        var result = results[i];
                        var sort = result.SortType;
                        string sortName = sort == 0 ? "Простая" : sort == 1 ? "Естественная" : "Многопутёвая";
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
                        var count = 0.0;
                        long time = 0;
                        for(; i < results.Count && results[i].SortType == sort && results[i].Count == result.Count; i++)
                        {
                            count++;
                            time += results[i].Time;
                        }
                        i--;
                        chart.Series[index].Points.AddXY(result.Count, time / count);
                        hide = false;
                    }
                }
                for (var i = 0; i < chart.Series.Count; i++)
                {
                    if (chart.Series[i].Points.Count == 0)
                    {
                        chart.Series[i].Enabled = false;
                    }
                    else
                    {
                        chart.Series[i].Enabled = true;
                    }
                }
                if (hide == true)
                {
                    //chart.Hide();
                }
                else
                {
                    //chart.Show();
                }
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
            graph.Paint += new PaintEventHandler(this.graph_Paint);
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

        private void graph_Paint(object sender, PaintEventArgs e)
        {
            var parent = (Chart)sender;
            //MessageBox.Show(parent.Name, "Отрисовано", MessageBoxButtons.OK);
            parent.Height = parent.Parent.Height / 2;
        }
    }
}
