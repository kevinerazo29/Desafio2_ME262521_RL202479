using System;

class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("== SISTEMA DE REGISTRO DE NOTAS =="); 

        // Cantidad de estudiantes 
        Console.Write("Ingrese la cantidad de estudiantes: ");
        int n = int.Parse(Console.ReadLine());

        // Validación básica
        if (n <= 0)
        {
            Console.WriteLine("Cantidad inválida.");
            return;
        }

        // Vectores paralelos 
        string[] nombres = new string[n];
        double[] notas = new double[n];

        // Ingreso de datos 
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEstudiante #{i + 1}");

            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();

            double nota;

            do
            {
                Console.Write("Nota (0 - 10): ");
                nota = double.Parse(Console.ReadLine());

                if (nota < 0 || nota > 10)
                {
                    Console.WriteLine("Nota inválida. Intente nuevamente.");
                }

            } while (nota < 0 || nota > 10);

            notas[i] = nota;
        }

        //  Calcular promedio, max y min 
        double suma = 0;
        double max = notas[0];
        double min = notas[0];

        for (int i = 0; i < n; i++)
        {
            suma += notas[i];

            if (notas[i] > max)
                max = notas[i];

            if (notas[i] < min)
                min = notas[i];
        }

        double promedio = suma / n;

        // Mostrar reporte 
        int aprobados = 0;
        int reprobados = 0;

        Console.WriteLine("\n=== REPORTE DE ESTUDIANTES ===");

        for (int i = 0; i < n; i++)
        {
            string estado;
            string letra;

            // Estado
            if (notas[i] >= 6)
            {
                estado = "Aprobado";
                aprobados++;
            }
            else
            {
                estado = "Reprobado";
                reprobados++;
            }

            // Letra
            if (notas[i] >= 9) letra = "A";
            else if (notas[i] >= 8) letra = "B";
            else if (notas[i] >= 7) letra = "C";
            else if (notas[i] >= 6) letra = "D";
            else letra = "F";

            Console.WriteLine($"Nombre: {nombres[i]} | Nota: {notas[i]} | Letra: {letra} | Estado: {estado}");
        }

        // Resumen final 
        Console.WriteLine("\n=== RESUMEN FINAL ===");
        Console.WriteLine($"Promedio del grupo: {promedio:F2}");
        Console.WriteLine($"Nota máxima: {max}");
        Console.WriteLine($"Nota mínima: {min}");
        Console.WriteLine($"Total aprobados: {aprobados}");
        Console.WriteLine($"Total reprobados: {reprobados}");

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
