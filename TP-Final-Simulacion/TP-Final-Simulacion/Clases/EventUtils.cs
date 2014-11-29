using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    class EventUtils
    {

        public static void salidaAmbulancia()
        {

        }

        public static void salidaVehiculo(UInt32 T, UInt32 NSV, UInt32[] TPSV, UInt32[] ITOV, UInt32 SSC)
        {
            uint TAV = 0;
            int i = ArrayUtils.obtenerMenorTPSV(TPSV);
            
            NSV--;

            if (NSV >= TPSV.Length)
            {
                SSC = SSC + T;
                //TAV
                TPSV[i] = T + TAV;
            }
            else
            {
                TPSV[i] = UInt32.MaxValue;
                ITOV[i] = T;
            }
        }

        public static int buscarAmbulanciaLibre(Ambulancia[] TPSA)
        {
            int i = 0;

            while (i < TPSA.Length && TPSA[i].tiempo != UInt32.MaxValue)
            {
                i++;
            }

            return i;
        }

        public static void llegadaLlamado(uint T, uint TPLL, uint NSR, uint NSA, uint NSV, uint SLLC, Ambulancia[] TPSA, uint[] TPSV, uint[] STOA, uint[] ITOA, uint[] STOV, uint[] ITOV)
        {
            int i;
            uint IA = 0;
            uint TAR = 0;
            uint TAA = 0;
            uint TAV = 0;
            Random random = new Random();
            double r = random.NextDouble();

            T = TPLL;
            //IA
            TPLL = T + IA;

            if (r <= 0.12)
            {
                //TAR
                verificarYEnviarAmbulancia(NSR, NSR, NSA, TPSA, TAR, T, STOA, SLLC, ITOA, 'R');
            }
            else if (r <= 0.33)
            {
                //TAA
                NSA++;
                verificarYEnviarAmbulancia(NSA, NSR, NSA, TPSA, TAA, T, STOA, SLLC, ITOA, 'A');
            }
            else
            {
                NSV++;
                if (NSV <= TPSV.Length)
                {
                    i = EventUtils.buscarVehiculoLibre(TPSV);
                    STOV[1] += T - ITOV[1];
                //TAV
                    TPSV[i] = T + TAV;
                }
                else
                {
                    SLLC += T;
                }
            }
        }

        private static int buscarVehiculoLibre(UInt32[] TPSV)
        {
            int i = 0;

            while (i < TPSV.Length && TPSV[i] != UInt32.MaxValue)
            {
                i++;
            }

            return i;
        }


        private static void verificarYEnviarAmbulancia(uint NS, uint NSR, uint NSA, Ambulancia[] TPSA, UInt32 TA, uint T, uint[] STOA, uint SLLC, uint[] ITOA, Char codigo)
        {
            NS++;
            if ((NSR + NSA) <= TPSA.Length)
            {
                int i = EventUtils.buscarAmbulanciaLibre(TPSA);
                STOA[i] += T - ITOA[i];
                TPSA[i].tiempo = T + TA;
                TPSA[i].codigo = codigo;
            }
            else
            {
                SLLC += T;
            }
        }
    }
}
