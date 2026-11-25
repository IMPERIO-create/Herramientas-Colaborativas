using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double[] array = null;
        int opcion;

        do
        {
            Console.WriteLine("1. Ingresar / Cambiar Array");
            Console.WriteLine("2. Calcular Máximo y Mínimo");
            Console.WriteLine("3. Calcular Media y Mediana");
            Console.WriteLine("4. Ordenar Array (menor a mayor)");
            Console.WriteLine("5. Calcular Desviación Típica");
            Console.WriteLine("6. Binarizar Array (base a n)");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1:
                    array = LeerArray();
                    break;
                case 2:
                    if (array == null) { Console.WriteLine("Primero ingrese un array."); break; }
                    Console.WriteLine($"Máximo: {array.Max()}, Mínimo: {array.Min()}");
                    break;
                case 3:
                    if (array == null) { Console.WriteLine("Primero ingrese un array."); break; }
                    Console.WriteLine($"Media: {CalcularMedia(array)}");
                    Console.WriteLine($"Mediana: {CalcularMediana(array)}");
                    break;
                case 4:
                    if (array == null) { Console.WriteLine("Primero ingrese un array."); break; }
                    var ordenado = array.OrderBy(x => x).ToArray();
                    Console.WriteLine("Ordenado: " + string.Join(", ", ordenado));
                    break;
                case 5:
                    if (array == null) { Console.WriteLine("Primero ingrese un array."); break; }
                    Console.WriteLine($"Desviación típica: {CalcularDesviacionTipica(array):F4}");
                    break;
                case 6:
                    if (array == null) { Console.WriteLine("Primero ingrese un array."); break; }
                    Console.Write("Ingrese el número n para binarizar: ");
                    if (double.TryParse(Console.ReadLine(), out double n))
                    {
                        int[] binarizado = array.Select(x => x < n ? 0 : 1).ToArray();
                        Console.WriteLine("Binarizado: " + string.Join(", ", binarizado));
                    }
                    break;
            }
        } while (opcion != 0);
    }

    static double[] LeerArray()
    {
        Console.Write("Ingrese los números separados por espacios: ");
        return Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
    }

    static double CalcularMedia(double[] arr) => arr.Average();

    static double CalcularMediana(double[] arr)
    {
        var ordenado = arr.OrderBy(x => x).ToArray();
        int mid = ordenado.Length / 2;
        return ordenado.Length % 2 != 0 ? ordenado[mid] : (ordenado[mid - 1] + ordenado[mid]) / 2.0;
    }

    static double CalcularDesviacionTipica(double[] arr)
    {
        double media = arr.Average();
        double sumaCuadrados = arr.Sum(x => Math.Pow(x - media, 2));
        return Math.Sqrt(sumaCuadrados / arr.Length);
    }
}