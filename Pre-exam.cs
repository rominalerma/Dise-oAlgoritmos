using System;

//Genere un programa en C # que se encargue de leer la cantidad de niños de una guardería
//y después de tener este dato, lea el nombre de cada uno y su edad en meses,
//que guarde en 2 arreglos la edad en años (con las fracciones necesarias) y el nombre de cada uno.
//Tenga en cuenta que los meses no pueden ser negativos ni cero ni pasarse de 72.
//Además, debe emitir como resultado el total de años de todos los niños, una lista de nombres y edades y el promedio de edad en años.
//También debe mostrar los tres niños con menor edad y ser capaz de localizar a un niño por su nombre y mostrar su edad (los nombres no van a estar repetidos)
//Recuerde que debe tener Menú, Métodos y Validaciones.

namespace Mock_1
{
    class Program
    {
        static void Captura(string[] nombres, double[] edad)
        {
            double meses;
            int n = edad.Length;
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nNombre del niño: ");
                nombres[i] = Console.ReadLine();
                do
                {
                    Console.Write("Edad en meses: ");
                    meses = double.Parse(Console.ReadLine());
                    if (meses <= 0 || meses > 72)
                    {
                        Console.WriteLine("Ingrese meses válidos (1-72)");
                    }
                } while (meses <= 0 || meses > 72);

                edad[i] = (meses / 12);
            }
        }
        static void TotalyPromedio(double[] edad)
        {
            double prom = 0;
            for (int j = 0; j < edad.Length; j++)
            {
                prom += edad[j];
            }
            Console.WriteLine("Total de edades: " + prom);
            Console.WriteLine("Promedio de edades: " + (prom / (edad.Length)));
        }
        static void MostrarDatos(string[] nombres, double[] edades, int cantidad)
        {
            for (int k = 0; k < cantidad; k++)
            {
                Console.WriteLine((k + 1) + ": " + nombres[k] + "- " + edades[k] + " años.");
            }
        }
        static void Menu(int n2)
        {
            int opcion, band = 0;
            double[] edad_ingresar = new double[n2];
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
                            Captura(nomb, edad_ingresar);
                            band = 1;
                            break;
                        }
                    case 2:
                        {
                            if (band == 1)
                            {
                                Console.WriteLine("Usted está emitiendo los resultados.");
                                Console.WriteLine("---------------------------------");
                                Submenu(edad_ingresar, nomb);
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
        static void Submenu(double[] edad, string[] nomb)
        {
            int opcion2;
            do
            {
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1.- Total y promedio de edades.");
                Console.WriteLine("2.- Mostrar todos los datos.");
                Console.WriteLine("3.- Mostrar a los tres más pequeños.");
                Console.WriteLine("4.- Localizar a un niño por nombre y mostrar su edad.");
                Console.WriteLine("5.- Terminar.");
                do
                {
                    Console.Write("\nIngrese su elección: ");
                    opcion2 = int.Parse(Console.ReadLine());

                    if (opcion2 < 1 || opcion2 > 5)
                    {
                        Console.WriteLine("Opción inválida, debe de ser 1, 2, 3, 4 o 5.");
                    }
                } while (opcion2 < 1 || opcion2 > 5);
                switch (opcion2)
                {
                    case 1:
                        {
                            TotalyPromedio(edad);
                            break;
                        }
                    case 2:
                        {
                            MostrarDatos(nomb, edad, edad.Length);
                            break;
                        }
                    case 3:
                        {
                            Ordenacion(nomb, edad);
                            break;
                        }
                    case 4:
                        {
                            Buscar(nomb, edad);
                            break;
                        }
                }
            } while (opcion2 != 5);
        }
        static void Ordenacion(string[] nomb, double[] edad)
        {
            double aux;
            string aux1;
            for (int j = 0; j < edad.Length - 1; j++)
            {
                for (int i = 0; i < edad.Length - 1 - j; i++)
                {
                    if (edad[i] > edad[i + 1])
                    {
                        aux = edad[i];
                        aux1 = nomb[i];
                        edad[i] = edad[i + 1];
                        nomb[i] = nomb[i + 1];
                        edad[i + 1] = aux;
                        nomb[i + 1] = aux1;
                    }
                }
            }
            MostrarDatos(nomb, edad, 3);
        }
        static void Buscar(string[] nombres, double[] edades)
        {
            int band = -1;
            int n = nombres.Length;
            Console.Write("Ingrese el nombre del niño cuya edad quiera averiguar: ");
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
                Console.WriteLine("La edad de " + nombres[band] + " es de " + edades[band] + " años.");
            }
        }
        static void Main(string[] args)
        {
            int n1;
            do
            {
                Console.Write("Número de niños en la guardería: ");
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
