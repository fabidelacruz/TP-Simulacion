using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Final_Simulacion.Clases;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP_Final_Simulacion.Ventanas
{
    public partial class Results : Form
    {
        private Resultados result;
        public Results(Resultados resultados)
        {
            InitializeComponent();
            result = resultados;
        }

        private void Results_Load(object sender, EventArgs e)
        {
            chart1.Series.Add("PTOA");
            chart1.Series.Add("PTOV");
            addValues(chart1.Series["PTOA"].Points, result.PTOA);
            addValues(chart1.Series["PTOV"].Points, result.PTOV);
        }

        private void addValues(DataPointCollection dataPointCollection, double[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                dataPointCollection.AddXY(i + 1, p[i]);
            }
        }

    }
}
