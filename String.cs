using System;
using System.Text;

namespace ProyectoString
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ DE OPERACIONES CON STRINGS ===");
                Console.WriteLine("1. Comprobar si un texto es palíndromo");
                Console.WriteLine("2. Mostrar texto en MAYÚSCULAS y minúsculas");
                Console.WriteLine("3. Contar ocurrencias de una letra");
                Console.WriteLine("4. Repetir dos textos N veces");
                Console.WriteLine("5. Duplicar cada letra de un texto (ej. NBA -> NNBBAA)");
                Console.WriteLine("6. Borrar apariciones de un texto dentro de otro");
                Console.WriteLine("0. Salir");
                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Introduce una palabra o frase: ");
                        string textoPal = Console.ReadLine() ?? "";
                        Console.WriteLine(EsPalindromo(textoPal)
                            ? $"\"{textoPal}\" ES un palíndromo."
                            : $"\"{textoPal}\" NO es un palíndromo.");
                        break;

                    case "2":
                        Console.Write("Introduce un nombre o texto: ");
                        string nombre = Console.ReadLine() ?? "";
                        MostrarMayusMinus(nombre);
                        break;

                    case "3":
                        Console.Write("Introduce el texto: ");
                        string frase = Console.ReadLine() ?? "";
                        Console.Write("Introduce la letra a buscar: ");
                        string entradaLetra = Console.ReadLine() ?? "";
                        if (entradaLetra.Length > 0)
                        {
                            char letra = entradaLetra[0];
                            int veces = ContarOcurrencias(frase, letra);
                            Console.WriteLine($"La letra '{letra}' aparece {veces} vez/veces.");
                        }
                        else
                        {
                            Console.WriteLine("No has introducido ninguna letra.");
                        }
                        break;

                    case "4":
                        Console.Write("Introduce el primer texto (ej. Alejandro): ");
                        string str1 = Console.ReadLine() ?? "";
                        Console.Write("Introduce el segundo texto (ej. crack): ");
                        string str2 = Console.ReadLine() ?? "";
                        int repeticiones = PedirEntero("¿Cuántas veces quieres repetirlos?: ");
                        Console.WriteLine("Resultado: " + RepetirDosStrings(str1, str2, repeticiones));
                        break;

                    case "5":
                        Console.Write("Introduce un texto (ej. Madrid): ");
                        string textoDuplicar = Console.ReadLine() ?? "";
                        Console.WriteLine("Resultado: " + DuplicarLetras(textoDuplicar));
                        break;

                    case "6":
                        Console.Write("Introduce el texto principal (ej. Real Zaragoza es de la realeza): ");
                        string textoPrincipal = Console.ReadLine() ?? "";
                        Console.Write("Introduce el texto a borrar (ej. Real): ");
                        string textoBorrar = Console.ReadLine() ?? "";
                        Console.WriteLine("Resultado: " + BorrarApariciones(textoPrincipal, textoBorrar));
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
                if (int.TryParse(Console.ReadLine(), out numero) && numero >= 0)
                {
                    return numero;
                }
                Console.WriteLine("Por favor, introduce un número entero válido (0 o mayor).");
            }
        }

        static bool EsPalindromo(string texto)
        {
            // Se eliminan espacios y se pasa a minúsculas para evaluar frases y palabras
            string limpio = texto.Replace(" ", "").ToLower();
            int izquierda = 0;
            int derecha = limpio.Length - 1;

            while (izquierda < derecha)
            {
                if (limpio[izquierda] != limpio[derecha])
                {
                    return false;
                }
                izquierda++;
                derecha--;
            }
            return limpio.Length > 0;
        }

        static void MostrarMayusMinus(string texto)
        {
            Console.WriteLine($"En mayúsculas: {texto.ToUpper()}");
            Console.WriteLine($"En minúsculas: {texto.ToLower()}");
        }

        static int ContarOcurrencias(string texto, char letra)
        {
            int contador = 0;
            char objetivo = char.ToLower(letra);

            foreach (char c in texto)
            {
                if (char.ToLower(c) == objetivo)
                {
                    contador++;
                }
            }
            return contador;
        }

        static string RepetirDosStrings(string s1, string s2, int veces)
        {
            if (veces <= 0) return "";

            string[] bloques = new string[veces];
            for (int i = 0; i < veces; i++)
            {
                bloques[i] = $"{s1} {s2}";
            }
            return string.Join(" ", bloques);
        }

        static string DuplicarLetras(string texto)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in texto)
            {
                sb.Append(c);
                sb.Append(c);
            }
            return sb.ToString();
        }

        static string BorrarApariciones(string original, string aBorrar)
        {
            if (string.IsNullOrEmpty(aBorrar)) return original;

            // Ignora mayúsculas/minúsculas para que "Real" borre tanto "Real" como "real"
            return original.Replace(aBorrar, "", StringComparison.OrdinalIgnoreCase).Trim();
        }
    }
}
