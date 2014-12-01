using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    public class Vehiculo
    {
        public Boolean asignado { get; set; }
        public Double tiempo { get; set; }

        public Vehiculo()
        {
            tiempo = Double.MaxValue;
            asignado = false;
        }
    }
}
