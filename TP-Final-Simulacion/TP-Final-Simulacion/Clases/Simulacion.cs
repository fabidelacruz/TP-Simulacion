﻿using System;
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
        public int NT = 0;
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

        }

        public Resultados run()
        {
            ArrayUtils.inicializarArray(TPSV);
            ArrayUtils.inicializarArray(TPSA);
            ArrayUtils.inicializarArrayVacio(STOA);
            ArrayUtils.inicializarArrayVacio(ITOA);
            ArrayUtils.inicializarArrayVacio(STOV);
            ArrayUtils.inicializarArrayVacio(ITOV);

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

            Resultados results = new Resultados(ambulancias, vehiculos, tiempo, this.generarResultados(STOA), this.generarResultados(STOV), (SSC-SLLC)/NT);

            return results;
        }

        private Double[] generarResultados(Double[] STO)
        {
            Double[] result = new Double[STO.Length];

            for (int i = 0; i < STO.Length; i++)
            {
                result[i] = (STO[i] * 100 /T);
            }

            return result;
        }

        private void iterar() 
        {
            int i = 0;
            if (TPLL < TPSA[ArrayUtils.obtenerIndiceMenorTPSA(TPSA)].tiempo)
                {
                    if (TPLL <= TPSV.Min()) 
                    {
                        NT++;
                        Events.llegadaLlamado(this);
                    }
                    else
                    {
                        i = ArrayUtils.obtenerIndiceMenorTPSV(TPSV);
                        T = TPSV[i];
                        Events.salidaVehiculo(this, i);
                    }
                }
                else if (TPSA[ArrayUtils.obtenerIndiceMenorTPSA(TPSA)].tiempo <= TPSV[ArrayUtils.obtenerIndiceMenorTPSV(TPSV)])
                {
                    i = ArrayUtils.obtenerIndiceMenorTPSA(TPSA);
                    T = TPSA[i].tiempo;
                    Events.salidaAmbulancia(this, i);
                }
                else
                {
                    i = ArrayUtils.obtenerIndiceMenorTPSV(TPSV);
                    T = TPSV[i];
                    Events.salidaVehiculo(this, i);
                }

            }

        public Int32 cantidadRojos()
        {
           return TPSA.Count(e => e.codigo == 'R');
        }

        public Int32 cantidadAmarillos()
        {
            return TPSA.Count(e => e.codigo == 'A');
        }
    }
}
