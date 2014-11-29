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
    public partial class Main : Form
    {
        private List<Escenario> escenarios = new List<Escenario>();

        public Main()
        {
            InitializeComponent();
        }

        private Boolean isNotEmpty(TextBox box)
        {
            return !box.Text.Equals("");
        }

        private void generarSimulacion()
        {
            UInt32 ambulancias = UInt32.Parse(this.ambulancias.Text);
            UInt32 vehiculos = UInt32.Parse(this.vehiculos.Text);
            UInt32 tiempo = UInt32.Parse(this.tiempo.Text);

            Simulacion simulacion = new Simulacion(ambulancias, vehiculos, tiempo, progressBar1);
            simulacion.run();
        }

        private void simular_Click(object sender, EventArgs e)
        {
            if (isNotEmpty(ambulancias) && isNotEmpty(vehiculos) && isNotEmpty(tiempo))
            {
                this.generarSimulacion();
                Results resultados = new Results();
                resultados.Show();
            } else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            ambulancias.Clear();
            vehiculos.Clear();
            tiempo.Clear();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || this.isSpecialKey(e.KeyChar))) 
            {
                MessageBox.Show("Solo se admiten numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private Boolean isSpecialKey(char key) 
        {
            return (key == (char)Keys.Back) || (key == (char)Keys.Escape) || 
                   (key == (char)Keys.Enter) || (key == (char)Keys.Tab);
        }
    
    }

}
