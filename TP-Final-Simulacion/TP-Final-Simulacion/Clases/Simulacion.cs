using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Final_Simulacion.Clases
{
    class Simulacion
    {
        public Random random = new Random();
        public ProgressBar progressBar;
        public Int32 ambulancias;
        public Int32 vehiculos;
        public Double tiempo;
        public Ambulancia[] TPSA; 
        public Double[] TPSV;
        public int NT;
        public Double T = 0;
        public Double NSR = 0;
        public Double NSA = 0;
        public Double NSV = 0;
        public Double SSC = 0;
        public Double TPLL = 0;
        public Double SLLC = 0;
        public Double[] STOA;
        public Double[] STOV;
        public Double[] ITOA;
        public Double[] ITOV;

        public Simulacion(Int32 ambulancias, Int32 vehiculos, Double tiempo, ProgressBar progressBar)
        {
            this.progressBar = progressBar;
            this.ambulancias = ambulancias;
            this.vehiculos = vehiculos;
            this.tiempo = tiempo;

            STOA = new Double[ambulancias];
            STOV = new Double[vehiculos];
            ITOA = new Double[ambulancias];
            ITOV = new Double[vehiculos];
            TPSA = new Ambulancia[ambulancias];
            TPSV = new Double[vehiculos];

            ArrayUtils.inicializarArray(TPSV);
        }

        public Resultados run()
        {
            ArrayUtils.inicializarArray(TPSA);
            ArrayUtils.inicializarArray(STOA);
            ArrayUtils.inicializarArray(ITOA);
            ArrayUtils.inicializarArray(STOV);
            ArrayUtils.inicializarArray(ITOV);

            while (T < tiempo)
            {   
                this.iterar();
                progressBar.Value = Convert.ToInt32(T * 100 / tiempo);
                progressBar.Refresh();
            }
            while (NSR + NSA + NSV > 0)
            {
                TPLL = Double.MaxValue;
                this.iterar();
            }

            Resultados results = new Resultados();

            return results;
        }

        private void iterar() 
        {
            int i = 0;
            if (TPLL < TPSA[ArrayUtils.obtenerIndiceMenorTPSA(TPSA)].tiempo)
                {
                    if (TPLL <= TPSV.Min()) 
                    {
                        T = TPLL;
                        
                        Events.llegadaLlamado(this);
                    }
                    else
                    {
                        i = ArrayUtils.obtenerIndiceMenorTPSV(TPSV);
                        T = TPSV[i];
                        Events.salidaVehiculo(this, i);
                    }
                }
                else if (ArrayUtils.obtenerIndiceMenorTPSA(TPSA) <= ArrayUtils.obtenerIndiceMenorTPSV(TPSV))
                {
                    i = ArrayUtils.obtenerIndiceMenorTPSA(TPSA);
                    T = TPSA[i].tiempo;
                    Events.salidaAmbulancia(this, i);
                }

            
            }
               
    }
}
