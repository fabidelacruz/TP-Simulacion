using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    public class Resultados
    {
        public Double PEC;
        public Double[] PTOA;
        public Double[] PTOV;
        public Int32 ambulancias;
        public Int32 vehiulos;
        public Double tiempo;

        public Resultados(Int32 ambulancias, Int32 vehiculos, Double tiempo, Double[] PTOA, Double[] PTOV, Double PEC)
        {
            this.PEC = PEC;
            this.PTOA = PTOA;
            this.PTOV = PTOV;
            this.ambulancias = ambulancias;
            this.vehiulos = vehiculos;
            this.tiempo = tiempo;
        }
    }
}
