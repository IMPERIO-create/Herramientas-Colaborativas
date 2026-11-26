using System;

namespace ProyectoDecimales
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE OPERACIONES CON DECIMALES ===");
                Console.WriteLine("1. Redondear un número al alza");
                Console.WriteLine("2. Eliminar los decimales de un número (truncar)");
                Console.WriteLine("3. Resolver ecuación de segundo grado (ax² + bx + c = 0)");
                Console.WriteLine("0. Salir");
                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        double numAlza = PedirDecimal("Introduce un número decimal: ");
                        Console.WriteLine($"Redondeado al alza: {RedondearAlAlza(numAlza)}");
                        break;

                    case "2":
                        double numTruncar = PedirDecimal("Introduce un número decimal: ");
                        Console.WriteLine($"Sin decimales: {EliminarDecimales(numTruncar)}");
                        break;

                    case "3":
                        Console.WriteLine("Para la ecuación ax² + bx + c = 0, introduce los coeficientes:");
                        double a = PedirDecimal("Coeficiente a: ");
                        double b = PedirDecimal("Coeficiente b: ");
                        double c = PedirDecimal("Coeficiente c: ");
                        ResolverEcuacionSegundoGrado(a, b, c);
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

        static double PedirDecimal(string mensaje)
        {
            double numero;
            while (true)
            {
                Console.Write(mensaje);
                // Nota: usa coma o punto según la configuración regional de tu sistema
                if (double.TryParse(Console.ReadLine(), out numero))
                {
                    return numero;
                }
                Console.WriteLine("Entrada no válida. Por favor, introduce un número válido.");
            }
        }

        static double RedondearAlAlza(double numero)
        {
            return Math.Ceiling(numero);
        }

        static double EliminarDecimales(double numero)
        {
            return Math.Truncate(numero);
        }

        static void ResolverEcuacionSegundoGrado(double a, double b, double c)
        {
            if (a == 0)
            {
                Console.WriteLine("El coeficiente 'a' no puede ser 0 en una ecuación de segundo grado.");
                return;
            }

            double discriminante = Math.Pow(b, 2) - 4 * a * c;

            if (discriminante > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                Console.WriteLine($"La ecuación tiene dos soluciones reales:");
                Console.WriteLine($"x1 = {x1:F4}");
                Console.WriteLine($"x2 = {x2:F4}");
            }
            else if (discriminante == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"La ecuación tiene una única solución real doble:");
                Console.WriteLine($"x = {x:F4}");
            }
            else
            {
                Console.WriteLine("La ecuación no tiene soluciones reales (el discriminante es negativo).");
            }
        }
    }
}
