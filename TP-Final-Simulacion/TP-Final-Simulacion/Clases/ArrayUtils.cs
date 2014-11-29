﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_Simulacion.Clases
{
    class ArrayUtils
    {

        public static void inicializarArray(UInt32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = UInt32.MaxValue;
            }
        }

        public static int obtenerIndiceMenorTPSA(Ambulancia[] TPSA)
        {
            int j = 0;

            for (int i = 1; i < TPSA.Length; i++)
            {
                if (TPSA[i].tiempo < TPSA[j].tiempo)
                {
                    j = i;
                }
            }

            return j;
        }

        public static int obtenerIndiceMenorTPSV(UInt32[] TPSV)
        {
            int j = 0;

            for (int i = 1; i < TPSV.Length; i++)
            {
                if (TPSV[i] < TPSV[j])
                {
                    j = i;
                }
            }

            return j;
        }


        internal static void inicializarArray(Ambulancia[] TPSA)
        {
            for (int i = 0; i < TPSA.Length; i++ )
            {
                TPSA[i] = new Ambulancia();
            }
        }
    }
}
