using System;

namespace EXAMENFINAL
{
    struct Fabrica
    {
        public string id;
        public string direccion;
        public uint meses_pagar;
        public double[] pago;
        public double prom;
    }
    class Program
    {
        static void Captura(Fabrica[] arr1)
        {
            int n1 = arr1.Length;
            for (int i = 0; i < n1; i++)
            {
                double acum = 0;
                Console.Write("ID de la fábrica " + (i + 1) + ": ");
                arr1[i].id = Console.ReadLine();
                Console.Write("Dirección exacta de la fábrica: ");
                arr1[i].direccion = Console.ReadLine();
                do
                {
                    Console.Write("Deme el número de meses al que se va a pagar el seguro: ");
                    arr1[i].meses_pagar = uint.Parse(Console.ReadLine());
                    if (arr1[i].meses_pagar < 1 || arr1[i].meses_pagar > 12)
                    {
                        Console.WriteLine("La cantidad de meses debe estar entre 1 y 12");
                    }
                } while (arr1[i].meses_pagar < 1 || arr1[i].meses_pagar > 12);
                arr1[i].pago = new double[arr1[i].meses_pagar];
                for (int j = 0; j < arr1[i].meses_pagar; j++)
                {
                    do
                    {
                        Console.Write("\t Cantidad a pagar en el mes {0}: ", (j + 1));
                        arr1[i].pago[j] = double.Parse(Console.ReadLine());
                        if (arr1[i].pago[j] < 0 || arr1[i].pago[j] > 30000)
                        {
                            Console.WriteLine("El pago debe estar entre 0 y 30,000 pesos.");
                        }
                    } while (arr1[i].pago[j] < 0 || arr1[i].pago[j] > 50000);
                    acum += arr1[i].pago[j];
                }
                arr1[i].prom = acum / arr1[i].meses_pagar;
            }
        }
        static void PromedioMenores5(Fabrica[] arr4)
        { 
            Ordenacion(arr4);
            for (int r=0; r<4; r++)
            Console.WriteLine("La Fabrica (" + arr4[r].id + ") está ubicada en " + arr4[r].direccion + " tiene el mayor numero de meses a pagar, con un promedio de $" + arr4[r].prom);
        }
        static void Busqueda(Fabrica[] arr1)
        {
            int n1 = arr1.Length;
            int indice = -1;
            Console.Write("Deme el ID de la fábrica que va a buscar: ");
            string valor = Console.ReadLine();
            for (int m = 0; m < n1; m++)
            {
                if (arr1[m].id == valor)
                {
                    indice = m;
                    Console.WriteLine("Fábrica ");
                    Console.WriteLine("\tID: {0}\n\tDirección de la Fábrica: {1}",
                                                                    arr1[indice].id, arr1[indice].direccion);
                    for (int z = 0; z < arr1[indice].meses_pagar; z++)
                    {
                        Console.WriteLine("\t\tEl Pago {0}: {1}", (z + 1), (arr1[indice].pago[z]));
                    }
                    Console.WriteLine("\n\tSu promedio de pagos es: ${0}", arr1[indice].prom);
                    break;
                }
            }
            if (indice == -1)
            {
                Console.WriteLine("No se encontró el valor");
            }
        }
        static void Orden(Fabrica[] arr2)
        {
            Ordenacion(arr2);
            for (int r = 0; r < 4; r++)
            {
                Console.WriteLine("Fabrica (" + arr2[r].id + ") ubicada en " + arr2[r].direccion + " con un promedio general de: " + arr2[r].prom);
            }
        }
        static void Ordenacion(Fabrica[] arr2)
        {
            int n2 = arr2.Length;
            //ordenación por burbuja             
            Fabrica aux;
            for (int p = 0; p < n2 - 1; p++)
            {
                for (int q = 0; q < n2 - (p + 1); q++)
                {
                    if (arr2[q].prom > arr2[q + 1].prom)
                    {
                        aux = arr2[q + 1];
                        arr2[q + 1] = arr2[q];
                        arr2[q] = aux;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            uint opc, band = 0, opc1;
            int n;
            do
            {
                Console.Write("Deme la cantidad de Fábricas: ");
                n = int.Parse(Console.ReadLine());
                if (n > 10)
                {
                    Console.WriteLine("Este programa funciona para 10 fábricas o menos");
                }
            } while (n > 10);
            Fabrica[] arr = new Fabrica[n];
            do
            {
                Console.WriteLine("\nMENÚ PRINCIPAL");
                Console.WriteLine("1. Entrada de datos");
                Console.WriteLine("2. Resultados");
                Console.WriteLine("3. Terminar");
                do
                {
                    Console.Write("Deme la opción deseada: ");
                    opc = uint.Parse(Console.ReadLine());
                } while (opc < 1 || opc > 3);
                switch (opc)
                {
                    case 1:
                        {
                            //Captura de datos
                            Captura(arr);
                            band = 1;
                            break;
                        }
                    case 2:
                        {
                            //Resultados
                            if (band != 1)
                            {
                                Console.WriteLine("Primero debe ingresar los datos.");
                            }
                            else
                            {
                                do
                                {
                                    Console.WriteLine("SUBMENÚ");
                                    Console.WriteLine("1. Cinco Fábricas con Menor promedio");
                                    Console.WriteLine("2. Búsqueda de un piso de fábrica por su ID");
                                    Console.WriteLine("3. Promedio General");
                                    Console.WriteLine("4. Salir");
                                    do
                                    {
                                        Console.Write("Elija una opción: ");
                                        opc1 = uint.Parse(Console.ReadLine());
                                    } while (opc1 < 1 || opc1 > 4);
                                    switch (opc1)
                                    {
                                        case 1:
                                            {
                                                PromedioMenores5(arr);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Busqueda(arr);
                                                break;
                                            }
                                        case 3:
                                            {
                                               Ordenacion(arr);
                                                break;
                                            }
                                    }
                                } while (opc1 < 4);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Fin del programa.");
                            break;
                        }
                }
            } while (opc < 3);
        }
    }
}

