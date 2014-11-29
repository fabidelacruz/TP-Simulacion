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
        private Random random = new Random();
        private ProgressBar progressBar;
        private UInt32 ambulancias;
        private UInt32 vehiculos;
        private UInt32 tiempo;
        private Ambulancia[] TPSA; 
        private UInt32[] TPSV;
        private int NT;

        public Simulacion(UInt32 ambulancias, UInt32 vehiculos, UInt32 tiempo, ProgressBar progressBar)
        {
            this.progressBar = progressBar;
            this.ambulancias = ambulancias;
            this.vehiculos = vehiculos;
            this.tiempo = tiempo;

            TPSA = new Ambulancia[ambulancias];
            TPSV = new UInt32[vehiculos];

            ArrayUtils.inicializarArray(TPSV);
        }

        public void run()
        {
            uint t = 0;
            uint NSR = 0;
            uint NSA = 0;
            uint NSV = 0;
            uint SSC = 0;
            uint TPLL = 0;
            uint SLLC = 0;
            uint value = 0;
            uint[] STOA = new uint[ambulancias];
            uint[] STOV = new uint[vehiculos];
            uint[] ITOA = new uint[ambulancias];
            uint[] ITOV = new uint[vehiculos];
            
            ArrayUtils.inicializarArray(STOA);
            ArrayUtils.inicializarArray(ITOA);
            ArrayUtils.inicializarArray(STOV);
            ArrayUtils.inicializarArray(ITOV);

            while (t < tiempo)
            {
                
                if (TPLL <= ArrayUtils.obtenerMenorTPSA(TPSA))
                {
                    if (TPLL <= TPSV.Min()) 
                    {
                        EventUtils.llegadaLlamado(t, TPLL, NSR, NSA, NSV, SLLC, TPSA, TPSV, STOA, ITOA, STOV, ITOV);
                    }
                    else
                    {
                        t = TPSV.Min();
                        EventUtils.salidaVehiculo(t, NSV, TPSV, ITOV, SSC);
                    }
                }
                else if (ArrayUtils.obtenerMenorTPSA(TPSA) <= ArrayUtils.obtenerMenorTPSV(TPSV))
                {
                    EventUtils.salidaAmbulancia();
                }

                progressBar.Value = Convert.ToInt32(t * 100 / tiempo);
            }

        }

        

        
    }
}
