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

namespace TP_Final_Simulacion.Ventanas
{
    public partial class Results : Form
    {

        private List<Int32> valores = new List<int>() { 2,3,4,5,6};
        public Results()
        {
            InitializeComponent();
            this.chart1.Series.Add("Algo1");
            this.chart1.Series.Add("Algo2");
        }
    }
}
