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

namespace TP_Final_Simulacion.Ventanas
{
    public partial class Detalles : Form
    {
        public BindingList<Item> items { get; set; }

        public Detalles(Double[] values)
        {
            InitializeComponent();

            items = new BindingList<Item>();

            for (int i = 0; i < values.Length; i++)
            {
                items.Add(new Item(i + 1, Math.Round(values[i], 4)));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BindingSource(items,null);
            dataGridView1.Columns["index"].HeaderText = "Numero";
            dataGridView1.Columns["value"].HeaderText = "Promedio tiempo ocioso diario (en minutos)";

            dataGridView1.Columns["index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
