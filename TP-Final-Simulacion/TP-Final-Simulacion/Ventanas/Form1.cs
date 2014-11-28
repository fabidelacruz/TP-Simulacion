using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP_Final_Simulacion.Clases;

namespace TP_Final_Simulacion.Ventanas
{
    public partial class Form1 : Form
    {
        private List<Escenario> escenarios = new List<Escenario>();

        public Form1()
        {
            InitializeComponent();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Add(new GroupBox());
            progressBar1.Increment(100);
            progressBar1.Increment(-100);
        }
    

       

    }

}
