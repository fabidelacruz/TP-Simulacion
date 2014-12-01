using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Final_Simulacion.Clases
{
    public class Item
    {
        public Int32 index { get; set; }
        public Double value { get; set; }

        public Item(Int32 i, Double v)
        {
            index = i;
            value = v;
        }
    }
}
