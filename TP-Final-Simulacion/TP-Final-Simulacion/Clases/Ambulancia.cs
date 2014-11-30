using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Final_Simulacion.Clases
{
    class Ambulancia
    {
        public Double tiempo { get; set; }
        public Char codigo { get; set; }

        public Ambulancia()
        {
            tiempo = Double.MaxValue;
        }
    }
}
