using System;
using System.Collections.Generic;

namespace ProyectoNumeros
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE OPERACIONES CON NÚMEROS ===");
                Console.WriteLine("1. Calcular si un número es primo");
                Console.WriteLine("2. Calcular el factorial");
                Console.WriteLine("3. Convertir segundos a horas, minutos y segundos");
                Console.WriteLine("4. Mostrar los primeros 15 números de la serie de Pell");
                Console.WriteLine("5. Comprobar si es un número de Armstrong");
                Console.WriteLine("6. Comprobar si tiene todos sus dígitos diferentes");
                Console.WriteLine("0. Salir");
                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        int numPrimo = PedirEntero("Introduce un número entero: ");
                        Console.WriteLine(EsPrimo(numPrimo)
                            ? $"El {numPrimo} ES primo."
                            : $"El {numPrimo} NO es primo.");
                        break;

                    case "2":
                        int numFact = PedirEntero("Introduce un número entero positivo: ");
                        if (numFact < 0)
                            Console.WriteLine("No existe el factorial de un número negativo.");
                        else
                            Console.WriteLine($"El factorial de {numFact} es: {CalcularFactorial(numFact)}");
                        break;

                    case "3":
                        int totalSegundos = PedirEntero("Introduce la cantidad de segundos: ");
                        if (totalSegundos < 0)
                            Console.WriteLine("Introduce una cantidad positiva.");
                        else
                            Console.WriteLine(ConvertirSegundos(totalSegundos));
                        break;

                    case "4":
                        long[] pell = SerieDePell(15);
                        Console.WriteLine("Primeros 15 números de Pell:");
                        Console.WriteLine(string.Join(", ", pell));
                        break;

                    case "5":
                        int numArmstrong = PedirEntero("Introduce un número entero positivo: ");
                        if (numArmstrong < 0)
                            Console.WriteLine("Introduce un número positivo.");
                        else
                            Console.WriteLine(EsArmstrong(numArmstrong)
                                ? $"El {numArmstrong} ES un número de Armstrong."
                                : $"El {numArmstrong} NO es un número de Armstrong.");
                        break;

                    case "6":
                        int numDigitos = PedirEntero("Introduce un número entero: ");
                        Console.WriteLine(TieneDigitosDiferentes(numDigitos)
                            ? $"El {numDigitos} tiene TODOS sus dígitos diferentes."
                            : $"El {numDigitos} tiene dígitos REPETIDOS.");
                        break;

                    case "0":
                        salir = true;
                        continue;

                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }

                Console.WriteLine("\nPulsa cualquier tecla para volver al menú...");
                Console.ReadKey();
            }
        }

        static int PedirEntero(string mensaje)
        {
            int numero;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out numero))
                {
                    return numero;
                }
                Console.WriteLine("Entrada no válida. Por favor, introduce un número entero.");
            }
        }

        static bool EsPrimo(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static long CalcularFactorial(int n)
        {
            long resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        static string ConvertirSegundos(int segundosTotales)
        {
            int horas = segundosTotales / 3600;
            int resto = segundosTotales % 3600;
            int minutos = resto / 60;
            int segundos = resto % 60;

            return $"{segundosTotales} segundos son {horas} hora(s), {minutos} min, y {segundos} segundos.";
        }

        static long[] SerieDePell(int cantidad)
        {
            long[] serie = new long[cantidad];
            int idx0 = 0;
            int idx1 = 1;
            if (cantidad >= 1) serie[idx0] = 0;
            if (cantidad >= 2) serie[idx1] = 1;

            for (int i = 2; i < cantidad; i++)
            {
                serie[i] = 2 * serie[i - 1] + serie[i - 2];
            }
            return serie;
        }

        static bool EsArmstrong(int n)
        {
            string digitos = n.ToString();
            int potencia = digitos.Length;
            double suma = 0;

            foreach (char c in digitos)
            {
                int digito = int.Parse(c.ToString());
                suma += Math.Pow(digito, potencia);
            }

            return (int)suma == n;
        }

        static bool TieneDigitosDiferentes(int n)
        {
            string texto = Math.Abs(n).ToString();
            HashSet<char> vistos = new HashSet<char>();

            foreach (char c in texto)
            {
                if (!vistos.Add(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
