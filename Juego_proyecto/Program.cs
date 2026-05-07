using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_proyecto
{
    internal class Program
    {
        public class Pieza
        {
            public int Fila;
            public int Columna;
            public bool Juega;
        }
        public class King : Pieza
        {
            public string Figura => "|K|";
            public string Color;


            public void MostrarPosicion(string[,] tablero)
            {
                tablero[Fila, Columna] = Figura;
            }
            public void MoverRey(int f, int c)
            {
                Fila = f;
                Columna = c;
            }
        }

        public class Tower : Pieza
        {
            public string Figura => "|T|";
            public string Color;

            public void MostrarPosicion(string[,] tablero)
            {
                tablero[Fila, Columna] = Figura;
            }

            public void MoverTorre(int f, int c)
            {
                Fila = f;
                Columna = c;
            }
        }

        public class Soldier : Pieza
        {
            public string Figura => "|S|";
            public string Color;
            public void MostrarPosicion(string[,] tablero)
            {
                tablero[Fila, Columna] = Figura;
            }
            public void MoverSoldado(int f, int c)
            {
                Fila = f;
                Columna = c;
            }
        }

        public class  Jugador
        {
            public string Nombre;
            public string Color;
            public bool Turno;

            public Jugador(string nombre, bool turno)
            {
                Nombre = nombre;
                Turno = turno;
            }
            public void MostrarTurno()
            {
                Console.WriteLine("=================================");
                Console.WriteLine("Turno de: " + Nombre);
                Console.WriteLine("=================================");
            }

            public void CambiarTurno(Jugador jugador2)
            {
                Turno = false;
                jugador2.Turno = true;
            }
        }

        static void Main(string[] args)
        {
            //Menu de inicio y declaracion de credenciales
            //password admin123+
            //user player1

            //Creando objetos/piezas
            King R1 = new King();
            R1.Juega = true;
            R1.Color = "Red";
            R1.Fila = 0;
            R1.Columna = 4;
            
            King R2 = new King();
            R2.Juega = true;
            R2.Color = "Green";
            R2.Fila = 7;
            R2.Columna = 3;

            Tower T1 = new Tower();
            T1.Juega = true;
            T1.Color = "Red";
            T1.Fila = 0;
            T1.Columna = 2;

            Tower T2 = new Tower();
            T2.Juega = true;
            T2.Color = "Red";
            T2.Fila = 0;
            T2.Columna = 5;

            Tower T3 = new Tower();
            T3.Juega = true;
            T3.Color = "Green";
            T3.Fila = 7;
            T3.Columna = 2;

            Tower T4 = new Tower();
            T4.Juega = true;
            T4.Color = "Green";
            T4.Fila = 7;
            T4.Columna = 5;

            Soldier S1 = new Soldier();
            S1.Juega = true;
            S1.Color = "red";
            S1.Fila = 1;
            S1.Columna = 2;

            Soldier S2 = new Soldier();
            S2.Juega = true;
            S2.Color = "red";
            S2.Fila = 1;
            S2.Columna = 3;

            Soldier S3 = new Soldier();
            S3.Juega = true;
            S3.Color = "red";
            S3.Fila = 1;
            S3.Columna = 4;

            Soldier S4 = new Soldier();
            S4.Juega = true;
            S4.Color = "red";
            S4.Fila = 1;
            S4.Columna = 5;

            Soldier S5 = new Soldier();
            S5.Juega = true;
            S5.Color = "Green";
            S5.Fila = 6;
            S5.Columna = 2;

            Soldier S6 = new Soldier();
            S6.Juega = true;
            S6.Color = "Green";
            S6.Fila = 6;
            S6.Columna = 3;

            Soldier S7 = new Soldier();
            S7.Juega = true;
            S7.Color = "Green";
            S7.Fila = 6;
            S7.Columna = 4;

            Soldier S8 = new Soldier();
            S8.Juega = true;
            S8.Color = "Green";
            S8.Fila = 6;
            S8.Columna = 5;

            Jugador J1 = new Jugador ("Jugador 1", true);
            Jugador J2 = new Jugador("Jugador 2", false);

            //variable de seguro, sirve como verificacion de las credenciales. variable valido, sirve para varificar el tryparse
            bool seguro, valido;
            string password;
            int cantidad, opcion = 0;
            // procedimiento para cambiar las teclas por *
            void IngresarPssw()
            {
                password = "";
                ConsoleKeyInfo tecla;
                do
                {
                    tecla = Console.ReadKey(true);
                    if (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Backspace)
                    {
                        password += tecla.KeyChar;
                        Console.Write("*");
                    }
                    else if (tecla.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                } while (tecla.Key != ConsoleKey.Enter);
                Console.WriteLine();
            }
            // procedimiento para hacer un tryparse de tipo entero
            void ValidacionInt()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                valido = int.TryParse(Console.ReadLine(), out cantidad);
                if (!valido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Respuesta invalida, ingrese solo numeros enteros.");
                    seguro = false;
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    seguro = true;
                }
            }
            //login de inicio
           bool correcto = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ingrese su usuario:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string usuario = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ingrese su contraseña:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                IngresarPssw();
                if (usuario == "player1" && password == "admin123+")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Credenciales correctas");
                    seguro = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Credenciales incorrectas, revise nuevamente");
                    seguro = false;
                }
            } while (seguro == false);
            int fila=0, columna=0;
            do
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("===== JUEGO DE TABLERO =====");
                    Console.WriteLine("1. Iniciar partida \n" +
                        "2. Ver reglas del juego \n" +
                        "3. Ver puntaje más alto \n" +
                        "4. Salir");
                    ValidacionInt();
                    if (seguro == true)
                    {
                        opcion = cantidad;
                    }
                } while (seguro == false);
                switch (opcion)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        string[,] Table = { {"|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|"},
                                {"|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|"},
                                {"|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|"},
                                {"|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|"},
                                {"|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|"},
                                {"|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|"},
                                {"|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|"},
                                {"|=|", "|-|", "|=|", "|-|", "|=|", "|-|", "|=|", "|-|"}};
                        R1.MostrarPosicion(Table);
                        R2.MostrarPosicion(Table);
                        T1.MostrarPosicion(Table);
                        T2.MostrarPosicion(Table);
                        T3.MostrarPosicion(Table);
                        T4.MostrarPosicion(Table);
                        S1.MostrarPosicion(Table);
                        S2.MostrarPosicion(Table);
                        S3.MostrarPosicion(Table);
                        S4.MostrarPosicion(Table);
                        S5.MostrarPosicion(Table);
                        S6.MostrarPosicion(Table);
                        S7.MostrarPosicion(Table);
                        S8.MostrarPosicion(Table);
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (Table[i, j] == "|-|" || Table[i, j] == "|=|")
                                {
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.Write($"{Table[i, j]} ");
                                }
                                else
                                {
                                    
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write($"{Table[i, j]} ");
                                }
                            }
                            Console.WriteLine();
                        }

                        if (J1.Turno)
                        {
                            J1.MostrarTurno();
                        }
                        else
                        {
                            J2.MostrarTurno();
                        }
                        
                        Console.WriteLine(@"Seleccione pieza:
1. Rey
2. Torre
3. Soldado
Ingrese una opción");
                        int opcionPieza=int.Parse(Console.ReadLine());

                        if (opcionPieza == 1)
                        {
                            Console.WriteLine("Seleccionaste Rey");
                            Console.WriteLine("Ingrese coordenadas ");
                            bool valido1;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la fila ");
                                valido1 = int.TryParse(Console.ReadLine(), out fila);
                                if (!valido1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (fila < 0 || fila > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la fila debe estar entre 0 y 7.");
                                    valido1 = false;
                                }
                            } while (!valido1);
                            bool valido3;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la columna  ");
                                valido3 = int.TryParse(Console.ReadLine(), out columna);
                                if (!valido3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (columna < 0 || columna > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la columna debe estar entre 0 y 7.");
                                    valido3 = false;
                                }
                            } while (!valido3);
                            break;
                        }
                        else if (opcionPieza == 2)
                        {
                            Console.WriteLine("Seleccionaste Torre");
                            Console.WriteLine("Ingrese coordenadas ");
                            bool valido1;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la fila ");
                                valido1 = int.TryParse(Console.ReadLine(), out fila);
                                if (!valido1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (fila < 0 || fila > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la fila debe estar entre 0 y 7.");
                                    valido1 = false;
                                }
                            } while (!valido1);
                            bool valido3;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la columna  ");
                                valido3 = int.TryParse(Console.ReadLine(), out columna);
                                if (!valido3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (columna < 0 || columna > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la columna debe estar entre 0 y 7.");
                                    valido3 = false;
                                }
                            } while (!valido3);
                            break;
                        }
                        else if (opcionPieza == 3)
                        {
                            Console.WriteLine("Seleccionaste Soldado");
                            Console.WriteLine("Ingrese coordenadas ");
                            bool valido1;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la fila ");
                                valido1 = int.TryParse(Console.ReadLine(), out fila);
                                if (!valido1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (fila < 0 || fila > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la fila debe estar entre 0 y 7.");
                                    valido1 = false;
                                }
                            } while (!valido1);
                            bool valido3;
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ingrese la columna  ");
                                valido3 = int.TryParse(Console.ReadLine(), out columna);
                                if (!valido3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: solo se permiten numeros.");
                                }
                                else if (columna < 0 || columna > 7)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error la columna debe estar entre 0 y 7.");
                                    valido3 = false;
                                }
                            } while (!valido3);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opción inválida.");
                        }

                       
                         break;


                    case 2:
                        Console.WriteLine("                              Reglas del juego");
                        Console.WriteLine(@"
                     1.  Funcionamiento general del juego
                            1.   El juego se desarrolla sobre un tablero de 8x8.
                            2.   Cada casilla del tablero posee una coordenada dicha por número de fila y número de columna.
                            3.   El tablero debe mostrara en consola en cada turno de forma clara, permitiendo a los jugadores
                                 ver el estado actual del juego.
                           Cada jugador contará con las siguientes piezas:
                                • 1 Rey
                                • 2 Torres
                                • 4 Soldados


                    2.  Movimiento de piezas
                             Durante su turno, el jugador debe ingresar la posición de origen y la posición de destino, indicando fila y columna.
                             El sistema no ejecutara el movimiento directamente. Primero validara completamente que el movimiento sea valido. 


                     3.  Reglas de movimiento
                            Cada tipo de pieza tiene un comportamiento específico que debe respetarse en todo momento.
                                 • Rey: puede moverse una sola casilla en cualquier dirección (horizontal, vertical o diagonal).
                                 • Torre: puede moverse en línea recta (horizontal o vertical), recorriendo varias casillas si el camino está libre. No puede saltar piezas.
                                 • Soldado: avanza una casilla hacia adelante
                                            ataca en diagonal
                                            no puede retroceder
                            Si un movimiento no cumple estas reglas, el sistema lo rechazara.
                        ");
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Nos vemos pronto.");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opcion != 4);
        }
    }
}
