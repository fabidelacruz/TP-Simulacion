using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    class Funciones
    {
        private static Random r = new Random();

        public static Double IA()
        {
            return -1 * Math.Log(1 - r.NextDouble(), Math.E) / 0.5693;
        }

        public static Double TAR()
        {
            Double rand = r.NextDouble();

            if (rand <= 0.25)
            {
                return r.NextDouble() * 15;
            } 
            else if (rand <= 0.46)
            {
                return 4 * r.NextDouble() + 16;
            }
            else if (rand <= 0.64)
            {
                return 4 * r.NextDouble() + 21;
            }
            else if (rand <= 0.76)
            {
                return 4 * r.NextDouble() + 26; 
            }
            else if (rand <= 0.97)
            {
                return 29 * r.NextDouble() + 31; 
            }
            else
            {
                return 29 * r.NextDouble() + 61;
            }
        }

        public static Double TAA()
        {
            Double rand = r.NextDouble();
            
            if (rand <= 0.11)
            {
                return r.NextDouble() * 20; 
            }
            else if (rand <= 0.31)
            {
                return 9 * r.NextDouble() + 21;
            }
            else if (rand <= 0.51)
            {
                return 9 * r.NextDouble() + 31;
            }
            else if (rand <= 0.66)
            {
                return 9 * r.NextDouble() + 41;
            }
            else if (rand <= 0.77)
            {
                return 9 * r.NextDouble() + 51;
            }
            else
            {
                return 29 * r.NextDouble() + 61;
            }

        }

        public static Double TAV()
        {
            Double rand = r.NextDouble();

            if (rand <= 0.34)
            {
                return r.NextDouble() * 90;
            }
            else if (rand <= 0.48)
            {
                return 29 * r.NextDouble() + 91;
            }
            else if (rand <= 0.69)
            {
                return 59 * r.NextDouble() + 121;
            }
            else if (rand <= 0.83)
            {
                return 59 * r.NextDouble() + 181;
            }
            else
            {
                return 59 * r.NextDouble() + 241;
            }

        }
    }
}
