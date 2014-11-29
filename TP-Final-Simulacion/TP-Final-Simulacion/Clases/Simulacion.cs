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
        public UInt32 ambulancias;
        public UInt32 vehiculos;
        public UInt32 tiempo;
        public Ambulancia[] TPSA; 
        public UInt32[] TPSV;
        public int NT;
        public uint T = 0;
        public uint NSR = 0;
        public uint NSA = 0;
        public uint NSV = 0;
        public uint SSC = 0;
        public uint TPLL = 0;
        public uint SLLC = 0;
        public uint[] STOA;
        public uint[] STOV;
        public uint[] ITOA;
        public uint[] ITOV;

        public Simulacion(UInt32 ambulancias, UInt32 vehiculos, UInt32 tiempo, ProgressBar progressBar)
        {
            this.progressBar = progressBar;
            this.ambulancias = ambulancias;
            this.vehiculos = vehiculos;
            this.tiempo = tiempo;

            STOA = new uint[ambulancias];
            STOV = new uint[vehiculos];
            ITOA = new uint[ambulancias];
            ITOV = new uint[vehiculos];
            TPSA = new Ambulancia[ambulancias];
            TPSV = new UInt32[vehiculos];

            ArrayUtils.inicializarArray(TPSV);
        }

        public void run()
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
                TPLL = UInt32.MaxValue;
                this.iterar();
            }

            
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
