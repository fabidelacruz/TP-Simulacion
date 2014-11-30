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
    }
}
