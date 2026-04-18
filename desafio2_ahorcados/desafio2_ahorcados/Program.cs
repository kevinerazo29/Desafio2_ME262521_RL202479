using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2_ahorcados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opciones;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("\t === JUEGO DEL AHORCADO ===");
                Console.WriteLine("\t1. Jugar");
                Console.WriteLine("\t2. Instrucciones del juego");
                Console.WriteLine("\t3. Salir");
                Console.Write("\tSelecciona una opción: ");
                opciones = Console.ReadLine();

                switch (opciones)
                {
                    case "1":
                        jugar();
                        break;
                    case "2":
                        instrucciones();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\t=== OPCION INVALIDA ===");
                        Console.ReadKey();
                        break;
                }
            }


        }


        static void jugar()
        {

            string[] palabras = { "espejo", "corazon", "delfin", "anillo", "camisa", "pantunflas", "calabaza", "princesa", "sorbete", "otorrinolaringologia", };
            Random palabraRandom = new Random();
            string palabraSeleccionada = palabras[palabraRandom.Next(palabras.Length)];
            

            char[] letraAdivinada = new char[palabraSeleccionada.Length];

            for (int i = 0; i < letraAdivinada.Length; i++)
            {
                letraAdivinada[i] = '_';
            }

            List<char> letraUsada = new List<char>();
            int intentos = 0;

            bool finalizado = false;
            while (!finalizado)
            {
                Console.Clear();
                dibujo(intentos);
                Console.WriteLine("\t === COMENZAMOS EL JUEGO ===");
                Console.WriteLine("\tPalabra : " + new string(letraAdivinada));
                Console.WriteLine("\tLetras usadas : "+string.Join(", ",letraUsada));

                Console.Write("\n\tINGRESE UNA LETRA:");
                char letraIngresada = Console.ReadKey().KeyChar;
                Console.Write("\n");

                if (!char.IsLetter(letraIngresada))
                {
                    Console.WriteLine("\tCaracter ingresado invalido. Solo puedes ingresar letras");
                }
                else
                {
                    letraIngresada = char.ToLower(letraIngresada);

                    if (letraAdivinada.Contains(letraIngresada))
                    {
                        Console.WriteLine("\tYa ingresaste esa letra.");
                    }
                    else
                    {
                        letraUsada.Add(letraIngresada);
                    }

                    bool correcto = false;
                    for(int i = 0; i < palabraSeleccionada.Length; i++)
                    {
                        if (palabraSeleccionada[i] == letraIngresada)
                        {
                            letraAdivinada[i] = letraIngresada;
                            correcto = true;
                        }
                    }

                    if (correcto)
                    {
                        Console.WriteLine("\tLa letra esta en la palabra");
                    }
                    else
                    {
                        intentos++;
                        Console.WriteLine("\tLa letra no esta en la palabra");
                    }
                }

                if(new string(letraAdivinada) == palabraSeleccionada)
                {
                    Console.WriteLine("\t === GANASTE ===");
                    finalizado = true;
                }
                else if (intentos >= 6)
                {
                    Console.WriteLine("\t === PERDISTE === ");
                    finalizado = true;
                }
            }

            Console.WriteLine("\tPRESIOCA CUALQUIER TECLA PARA CONTINUAR");
            Console.ReadKey();

            

        }

        static void dibujo(int intentos)
        {
            string[] dibujito =
            {
                " +----+\n |    |\n      |\n      |\n      |\n      |\n=========",
                " +----+\n |    |\n O    |\n      |\n      |\n      |\n=========",
                " +----+\n |    |\n O    |\n |    |\n      |\n      |\n=========",
                " +----+\n |    |\n O    |\n/|    |\n      |\n      |\n=========",
                " +----+\n |    |\n O    |\n/|\\   |\n      |\n      |\n=========",
                " +----+\n |    |\n O    |\n/|\\   |\n/     |\n      |\n=========",
                " +----+\n |    |\n O    |\n/|\\   |\n/ \\   |\n      |\n========="

            };

            Console.WriteLine(dibujito[intentos]);

        }

        static void instrucciones()
        {
            Console.Clear();
            Console.WriteLine("\t === INTRUCCIONES ===");
            Console.WriteLine("\tAdivina la palabra oculta" +
                "\n\tTienes un maximo de 6 intentos" +
                "\n\tPresiona una tecla para volver al menú");
            Console.ReadKey();
        }
       
    }
}
