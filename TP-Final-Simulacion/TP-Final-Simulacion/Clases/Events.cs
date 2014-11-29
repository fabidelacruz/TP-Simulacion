using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    class Events
    {

        public static void salidaAmbulancia(Simulacion simulacion, int i)
        {
            UInt32 TA = 0;
            UInt32 TAR = 0;
            UInt32 TAA = 0;

            switch (simulacion.TPSA[i].codigo)
            {
                case 'R':
                    simulacion.NSR--;
                    break;

                case 'A':
                    simulacion.NSA--;
                    break;
            }

            if (simulacion.NSA + simulacion.NSR >= simulacion.TPSA.Length)
            {
                simulacion.SSC += simulacion.T;

                if (simulacion.NSR > 0)
                {
                    TAR = Funciones.TAR();
                    enviarAmbulancia(simulacion, i, TA, 'R');
                }
                else
                {
                    TAA = Funciones.TAA();
                    enviarAmbulancia(simulacion, i, TA, 'A');
                }
            }
            else
            {
                simulacion.TPSA[i].tiempo = UInt32.MaxValue;
                simulacion.ITOA[i] = simulacion.T;
            }


        }

        public static void salidaVehiculo(Simulacion simulacion, int i)
        {
            uint TAV = 0;

            simulacion.NSV--;

            if (simulacion.NSV >= simulacion.TPSV.Length)
            {
                simulacion.SSC = simulacion.SSC + simulacion.T;
                TAV = Funciones.TAV();
                simulacion.TPSV[i] = simulacion.T + TAV;
            }
            else
            {
                simulacion.TPSV[i] = UInt32.MaxValue;
                simulacion.ITOV[i] = simulacion.T;
            }
        }

        public static int buscarAmbulanciaLibre(Ambulancia[] TPSA)
        {
            int i = 0;

            while (i < TPSA.Length && TPSA[i].tiempo != UInt32.MaxValue)
            {
                i++;
            }

            if (i == TPSA.Length)
            {
                i = -1;
            }

            return i;
        }

        private static int buscarVehiculoLibre(UInt32[] TPSV)
        {
            int i = 0;

            while (i < TPSV.Length && TPSV[i] != UInt32.MaxValue)
            {
                i++;
            }

            if (i == TPSV.Length) 
            {
                i = -1;
            }

            return i;
        }

        public static void llegadaLlamado(Simulacion simulacion)
        {
            int i;
            uint IA = 0;
            uint TAR = 0;
            uint TAA = 0;
            uint TAV = 0;
            Random random = new Random();
            double r = random.NextDouble();

            simulacion.T = simulacion.TPLL;
            IA = Funciones.IA();
            simulacion.TPLL = simulacion.T + IA;

            if (r <= 0.12)
            {
                TAR = Funciones.TAR();
                verificarYEnviarAmbulancia(simulacion, TAR, 'R');
            }
            else if (r <= 0.33)
            {
                TAA = Funciones.TAA();
                simulacion.NSA++;
                verificarYEnviarAmbulancia(simulacion, TAA, 'A');
            }
            else
            {
                simulacion.NSV++;
                if (simulacion.NSV <= simulacion.TPSV.Length)
                {
                                   
                    i = Events.buscarVehiculoLibre(simulacion.TPSV);
                    if (i != -1)
                    {
                        simulacion.STOV[i] += simulacion.T - simulacion.ITOV[i];
                        TAV = Funciones.TAV();
                        simulacion.TPSV[i] = simulacion.T + TAV;
                    }
                                       
                }
                else
                {
                    simulacion.SLLC += simulacion.T;
                }
            }
        }

        private static void verificarYEnviarAmbulancia(Simulacion simulacion, UInt32 TA, Char codigo)
        {
            switch (codigo)
            {
                case 'R':
                    simulacion.NSR++;
                    break;

                case 'A':
                    simulacion.NSA++;
                    break;
            }
            if ((simulacion.NSR + simulacion.NSA) <= simulacion.TPSA.Length)
            {
                int i = buscarAmbulanciaLibre(simulacion.TPSA);
            
                if (i != -1)
                {
                    enviarAmbulancia(simulacion, i, TA, codigo);
                }
            }
            else
            {
                simulacion.SLLC += simulacion.T;
            }
        }

        private static void enviarAmbulancia(Simulacion simulacion, int i, UInt32 TA, Char codigo)
        {
            simulacion.STOA[i] += simulacion.T - simulacion.ITOA[i];
            simulacion.TPSA[i].tiempo = simulacion.T + TA;
            simulacion.TPSA[i].codigo = codigo;
        }
    }
}
