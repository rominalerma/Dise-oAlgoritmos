using System;
//Diseñe un programa en C# que se encargue de leer el precio del cubículo y la cantidad de noches que lo ocupó la mascota
//guardar el pago total del cubículo y el nombre de cada mascota
//Al principio del programa se puede averiguar la cantidad de mascotas registrada.
//Se desea obtener como resultados (en un submenú) el nombre y el precio total pagado por cada dueño de mascota.
//así como el promedio general de pagos por mascota. 

namespace EXAMEN2
{
    class Program
    {
        static void Captura(string[] nombres, double[] pagos)
        {
            double noches;
            double pago;
            int n = pagos.Length;
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nNombre de la mascota: ");
                nombres[i] = Console.ReadLine();
                do
                {
                    Console.Write("Cantidad de noches de hospedaje: ");
                    noches = double.Parse(Console.ReadLine());
                    if (noches <= 0 || noches > 15)
                    {
                        Console.WriteLine("Ingrese noches válidas (1-15)");
                    }
                } while (noches <= 0 || noches > 15);
                do
                {
                    Console.Write("¿Cuál fue el costo de su habitación?: ");
                    pago = double.Parse(Console.ReadLine());
                    if (pago < 1000 || pago > 5000)
                    {
                        Console.WriteLine("Ingrese un pago válido: ");
                    }
                } while (pago < 1000 || pago > 5000);

                pagos[i] = pago * noches;
            }
        }
        static void TotalyPromedio(double[] pagos)
        {
            double prom = 0;
            for (int j = 0; j < pagos.Length; j++)
            {
                prom += pagos[j];
            }
            Console.WriteLine("Total de pagos: " + prom);
            Console.WriteLine("Promedio de pagos: " + (prom / (pagos.Length)));
        }
        static void MostrarDatos(string[] nombres, double[] pagos, int cantidad)
        {
            for (int k = 0; k < cantidad; k++)
            {
                Console.WriteLine((k + 1) + ": " + nombres[k] + "- " + pagos[k] + " pesos");
            }
        }
        static void Menu(int n2)
        {
            int opcion, band = 0;
            double[] pago_ingresar = new double[n2];
            string[] nomb = new string[n2];
            do
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1.- Entrada de Datos");
                Console.WriteLine("2.- Resultados.");
                Console.WriteLine("3.- Terminar.");
                do
                {
                    Console.Write("Ingrese su elección (1-3): ");
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion < 1 || opcion > 3)
                    {
                        Console.WriteLine("Opción inválida, debe de ser 1, 2 o 3.");
                    }
                } while (opcion < 1 || opcion > 3);

                switch (opcion)
                {
                    case 1:
                        {
                            Console.WriteLine("Usted está capturando los datos.");
                            Console.WriteLine("---------------------------------");
                            Captura(nomb, pago_ingresar);
                            band = 1;
                            break;
                        }
                    case 2:
                        {
                            if (band == 1)
                            {
                                Console.WriteLine("Usted está emitiendo los resultados.");
                                Console.WriteLine("---------------------------------");
                                Submenu(pago_ingresar, nomb);
                            }
                            else
                            {
                                Console.WriteLine("Usted debe capturar los datos");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Hasta luego.");
                            break;
                        }
                }
            } while (opcion != 3);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Usted ha terminado.");
        }
        static void Submenu(double[] pagos, string[] nomb)
        {
            int opcion2;
            do
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1.- Promedio general de pagos.");
                Console.WriteLine("2.- Listado de mascotas y pagos.");
                Console.WriteLine("3.- Buscar los datos de una mascota en particular.");
                Console.WriteLine("4.- Terminar.");
                do
                {
                    Console.Write("\nIngrese su elección: ");
                    opcion2 = int.Parse(Console.ReadLine());

                    if (opcion2 < 1 || opcion2 > 4)
                    {
                        Console.WriteLine("Opción inválida, debe de ser 1, 2, 3, o 4.");
                    }
                } while (opcion2 < 1 || opcion2 > 4);
                switch (opcion2)
                {
                    case 1:
                        {
                            TotalyPromedio(pagos);
                            break;
                        }
                    case 2:
                        {
                            MostrarDatos(nomb, pagos, pagos.Length);
                            break;
                        }
                    case 3:
                        {
                            Buscar(nomb, pagos);
                            break;
                        }
                }
            } while (opcion2 != 4);
        }
        static void Buscar(string[] nombres, double[] pagos)
        {
            int band = -1;
            int n = nombres.Length;
            Console.Write("Ingrese el nombre de la mascota cuyo pago quiera averiguar: ");
            string nombre = Console.ReadLine();
            for (int i = 0; i < n; i++)
            {
                if (nombres[i] == nombre)
                {
                    band = i;
                    break;
                }
            }
            if (band == -1)
            {
                Console.WriteLine("El nombre buscado no fue encontrado en el registro.");
            }
            else
            {
                Console.WriteLine("El pago de " + nombres[band] + " es de " + pagos[band] + " pesos.");
            }
        }
        static void Main(string[] args)
        {
            int n1;
            do
            {
                Console.Write("Número de mascotas en el hotel: ");
                n1 = int.Parse(Console.ReadLine());

                if (n1 <= 2)
                {
                    Console.WriteLine("Ingrese un número mayor a 2 y entero");
                }
            } while (n1 <= 2);
            Menu(n1);
        }
    }

}