using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    struct ventas
    {
        public int No_orden;
        public string mueble;
        public int cant_pagos;
        public double[] pagos;
        public double promedio;
    }
    class Program
    {
        static void menor_promedio(ventas[] muebles)
        {
            int n = muebles.Length;
            ventas aux;
            for (int k = 0; k < n - 1; k++)
            {
                for (int h = 0; h < n - (k + 1); h++)
                {
                    if (muebles[h].promedio < muebles[h + 1].promedio)
                    {
                        aux = muebles[h + 1];
                        muebles[h + 1] = muebles[h];
                        muebles[h] = aux;
                    }
                }
            }
            Console.WriteLine("\nLos cuato menores promedios de pago son: ");
            Console.WriteLine("El cliente con el número de orden " + muebles[n - 1].No_orden
            + " que compró un: " + muebles[n - 1].cant_pagos);
            Console.WriteLine("El cliente con el número de orden " + muebles[n - 2].No_orden +
            " que compró un: " + muebles[n - 2].cant_pagos);
            Console.WriteLine("El cliente con el número de orden " + muebles[n - 3].No_orden +
            " que compró un: " + muebles[n - 3].cant_pagos);
            Console.WriteLine("El cliente con el número de orden " + muebles[n - 4].No_orden +
            " que compró un: " + muebles[n - 4].cant_pagos);
        }
        static void promediogeneral(double acumventas, int acumpagos)
        {
            double promediogeneral;
            promediogeneral = acumventas / acumpagos;
            Console.WriteLine("\nEl promedio general de pagos es de: " + promediogeneral);
        }
        static void submenu(ventas[] muebles, int acumpagos, double acumventas)
        {
            int resp;
            do
            {
                Console.WriteLine("\nResultados / Salidas");
                Console.WriteLine("1.- Promedio General de pagos");
                Console.WriteLine("2.- Menor promedio de pagos");
                Console.WriteLine("3.- Salir");
                do
                {
                    Console.Write("Deme la opción deseada: ");
                    resp = int.Parse(Console.ReadLine());
                } while (resp < 1 || resp > 3);
                switch (resp)
                {
                    case 1:
                        {
                            promediogeneral(acumventas, acumpagos);
                            break;
                        }
                    case 2:
                        {
                            menor_promedio(muebles);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\n\nRegreso al Menú Principal");
                            break;
                        }
                }
            } while (resp < 3);
        }
        static void captura_datos(ventas[] muebles, ref int acumpagos, ref double acumventas)
        {
            double acum_pago;
            int n = muebles.Length;
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nDeme el número de orden del cliente " + (i + 1) + ": ");
                muebles[i].No_orden = int.Parse(Console.ReadLine());
                Console.Write("Deme el tipo de Mueble que compró el cliente " + (i + 1) + ": ");
                muebles[i].mueble = (Console.ReadLine());
                do
                {
                    Console.Write("Deme el número de exhibiciones en las que se realizará el pago (1,3,6 o 12): ");
                    muebles[i].cant_pagos = int.Parse(Console.ReadLine());
                } while (muebles[i].cant_pagos != 1 && muebles[i].cant_pagos != 3 && muebles[i].cant_pagos != 6 && muebles[i].cant_pagos != 12);
                muebles[i].pagos = new double[muebles[i].cant_pagos];
                acum_pago = 0;
                for (int j = 0; j < muebles[i].cant_pagos; j++)
                {
                    do
                    {
                        Console.Write("¿Cuánto pagó en la " + (j + 1) + " exhibición? (< $5,000): ");
                        muebles[i].pagos[j] = double.Parse(Console.ReadLine());
                    } while (muebles[i].pagos[j] <= 0 || muebles[i].pagos[j] > 5000);
                    acum_pago = acum_pago + muebles[i].pagos[j];
                }
                Console.WriteLine("El pago total realizado por el cliente " + (i + 1) + " es de: " + acum_pago);
                muebles[i].promedio = acum_pago / muebles[i].cant_pagos;
                acumpagos = acumpagos + muebles[i].cant_pagos;
                acumventas = acumventas + acum_pago;
            }
            Console.WriteLine("\nEl total reacudado de las ventas es de: " + acumventas);
        }
        static void menu(ventas[] muebles)
        {
            int opc, band = 0, acumpagos = 0;
            double acumventas = 0;
            do
            {
                Console.WriteLine("\nMenú");
                Console.WriteLine("1.- Captura de datos");
                Console.WriteLine("2.- Resultados / Salidas");
                Console.WriteLine("3.- Salir");
                do
                {
                    Console.Write("Deme la opción deseada: ");
                    opc = int.Parse(Console.ReadLine());
                } while (opc < 1 || opc > 3);
                switch (opc)
                {
                    case 1:
                        {
                            captura_datos(muebles, ref acumpagos, ref acumventas);
                            band = 1;
                            break;
                        }
                    case 2:
                        {
                            if (band == 1)
                            {
                                submenu(muebles, acumpagos, acumventas);
                            }
                            else
                            {
                                Console.WriteLine("\nPrimero debe capturar los datos");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nHasta Luego");
                            break;
                        }
                }
            } while (opc < 3);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int n;
            {
                Console.Write("¿Cuántos clientes compraron un mueble? (>4): ");
                n = int.Parse(Console.ReadLine());
            } while (n < 4) ;
            ventas[] muebles = new ventas[n];
            menu(muebles);
        }
    }
}
