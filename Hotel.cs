using System;

namespace ConsoleApp19
{
    struct Institucion
    {
        public string id;
        public string direccion;
        public DateTime inauguracion;
        public uint cant_aport;
        public double[] aport;
        public double prom;
    }
    class Program
    {
        static void Captura(Institucion[] arr1)
        {
            int n1 = arr1.Length;
            for (int i = 0; i < n1; i++)
            {
                double acum = 0;
                Console.Write("ID de la institucion " + (i + 1) + ": ");
                arr1[i].id = Console.ReadLine();
                Console.Write("Dirección exacta de la institución: ");
                arr1[i].direccion = Console.ReadLine();
                Console.Write("Fecha de ingreso: ");
                arr1[i].inauguracion = DateTime.Parse(Console.ReadLine());
                do
                {
                    Console.Write("Deme el número de aportaciones: ");
                    arr1[i].cant_aport = uint.Parse(Console.ReadLine());
                    if (arr1[i].cant_aport < 1 || arr1[i].cant_aport > 15)
                    {
                        Console.WriteLine("La cantidad de aportaciones debe estar entre 1 y 15");
                    }
                } while (arr1[i].cant_aport < 1 || arr1[i].cant_aport > 15);
                arr1[i].aport = new double[arr1[i].cant_aport];
                for (int j = 0; j < arr1[i].cant_aport; j++)
                {
                    do
                    {
                        Console.Write("\tAportación {0}: ", (j + 1));
                        arr1[i].aport[j] = double.Parse(Console.ReadLine());
                        if (arr1[i].aport[j] < 0 || arr1[i].aport[j] > 50000)
                        {
                            Console.WriteLine("La aportación debe estar entre 0 y 50,000 pesos.");
                        }
                    } while (arr1[i].aport[j] < 0 || arr1[i].aport[j] > 50000);
                    acum += arr1[i].aport[j];
                }
                arr1[i].prom = acum / arr1[i].cant_aport;
            }
        }
        static void PromedioMayor(Institucion[] arr4)
        {
            int ultimo = arr4.Length - 1;
            //ordenación por burbuja             pu
            Ordenacion(arr4);
            Console.WriteLine("Institución (" + arr4[ultimo].id + ") ubicada en " + arr4[ultimo].direccion + " tiene el mayor promedio de aportaciones, con un promedio de $" + arr4[ultimo].prom);
        }
        static void Busqueda(Institucion[] arr1)
        {
            int n1 = arr1.Length;
            int indice = -1;
            Console.Write("Deme el ID de la institución que va a buscar: ");
            string valor = Console.ReadLine();
            //Búsqueda Secuencial
            for (int m = 0; m < n1; m++)
            {
                if (arr1[m].id == valor)
                {
                    indice = m;
                    Console.WriteLine("Institución ");
                    Console.WriteLine("\tID: {0}\n\tFecha de Inauguración: {1} \n\tDirección de la Institución: {2}",
                                                                    arr1[indice].id, arr1[indice].inauguracion, arr1[indice].direccion);
                    for (int z = 0; z < arr1[indice].cant_aport; z++)
                    {
                        Console.WriteLine("\t\tAportación {0}: {1}", (z + 1), (arr1[indice].aport[z]));
                    }
                    Console.WriteLine("\n\tSu promedio de aportaciones es: ${0}", arr1[indice].prom);
                    break;
                }
            }
            if (indice == -1)
            {
                Console.WriteLine("No se encontró el valor");
            }
        }
        static void Orden(Institucion[] arr2)
        {
            Ordenacion(arr2);
            for (int r = 0; r < 4; r++)
            {
                Console.WriteLine("Institución (" + arr2[r].id + ") ubicada en " + arr2[r].direccion + " con promedio de aportaciones de $" + arr2[r].prom);
            }
        }
        static void Ordenacion(Institucion[] arr2)
        {
            int n2 = arr2.Length;
            //ordenación por burbuja             
            Institucion aux;
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
                Console.Write("Deme la cantidad de instituciones: ");
                n = int.Parse(Console.ReadLine());
                if (n < 4)
                {
                    Console.WriteLine("Este programa funciona para 4 instituciones o más");
                }
            } while (n < 4);
            Institucion[] arr = new Institucion[n];
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
                                    Console.WriteLine("1. Promedio más alto");
                                    Console.WriteLine("2. Búsqueda de una institución por su ID");
                                    Console.WriteLine("3. Cuatro promedios de aportaciones más bajos");
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
                                                PromedioMayor(arr);
                                                break;
                                            }
                                        case 2:
                                            {
                                                Busqueda(arr);
                                                break;
                                            }
                                        case 3:
                                            {
                                                Orden(arr);
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

