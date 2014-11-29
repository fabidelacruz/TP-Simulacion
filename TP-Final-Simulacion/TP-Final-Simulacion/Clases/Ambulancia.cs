using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Final_Simulacion.Clases
{
    class Ambulancia
    {
        public UInt32 tiempo { get; set; }
        public Char codigo { get; set; }

        public Ambulancia()
        {
            tiempo = UInt32.MaxValue;
        }
    }
}
