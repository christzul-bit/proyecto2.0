using System;
using System.Collections.Generic;
using System.IO;
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

            public void DoblePosicion(string[,] tablero)
            {
                
            }
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

            public bool ValidarKing( int filaDestino, int columnaDestino)
            {
                if (filaDestino < Fila - 1 || filaDestino > Fila + 1 || columnaDestino < Columna - 1 || columnaDestino > Columna + 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

            public bool ValidarTower(int filaDestino, int columnaDestino)
            {
                if (filaDestino != Fila && columnaDestino != Columna)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

            public void CambiarTurno()
            {
                if(Turno == true)
                {
                    Turno = false;
                }else
                {
                    Turno= true;
                }
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
            int cantidad, opcion = 0, column = 0, row =0;
            int filaDestino = 0;
            int columnaDestino = 0;
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
            // procedimiento para mostrar el tablareo y jugadas
            void Vertablero()
            {
                string[,] Table =
                {
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
        { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " }
    };

                Table[R1.Fila, R1.Columna] = "K1 ";
                Table[R2.Fila, R2.Columna] = "K2 ";

                Table[T1.Fila, T1.Columna] = "T1 ";
                Table[T2.Fila, T2.Columna] = "T2 ";
                Table[T3.Fila, T3.Columna] = "T3 ";
                Table[T4.Fila, T4.Columna] = "T4 ";

                Table[S1.Fila, S1.Columna] = "S1 ";
                Table[S2.Fila, S2.Columna] = "S2 ";
                Table[S3.Fila, S3.Columna] = "S3 ";
                Table[S4.Fila, S4.Columna] = "S4 ";

                Table[S5.Fila, S5.Columna] = "S5 ";
                Table[S6.Fila, S6.Columna] = "S6 ";
                Table[S7.Fila, S7.Columna] = "S7 ";
                Table[S8.Fila, S8.Columna] = "S8 ";

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("     ");

                for (int i = 0; i < 8; i++)
                {
                    Console.Write($"{i}   ");
                }
                Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {i}  ");

                    for (int j = 0; j < 8; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("|");
                        if (Table[i, j].Trim() == "")
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Table[i, j]);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("|");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("     ");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write($"{i}   ");
                }
                Console.WriteLine();
            }
            // procedimiento para ingresar las coord
            void Cords()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese coordenadas para mover la pieza:");
               
                
                bool valido1;
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ingrese la fila ");
                    valido1 = int.TryParse(Console.ReadLine(), out row);
                    if (!valido1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: solo se permiten numeros.");
                    }
                    else if (row < 0 || row > 7)
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
                    valido3 = int.TryParse(Console.ReadLine(), out column);
                    if (!valido3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: solo se permiten numeros.");
                    }
                    else if (column < 0 || column > 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error la columna debe estar entre 0 y 7.");
                        valido3 = false;
                    }
                } while (!valido3);
                filaDestino = row;
                columnaDestino = column;
            }
            //login de inicio
        
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
                        bool seguir = true;
                        while (seguir)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Vertablero();

                            if (J1.Turno)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                J1.MostrarTurno();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                J2.MostrarTurno();
                            }
                            // cambie esto para pedir fila y columna para buscar la pieza y despes mover la pieza
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Ingrese fila de origen:");
                            Cords();

                            int filaOrigen = row;
                            int columnaOrigen = column;
                            Pieza piezaSeleccionada = null;
                            if (J1.Turno == true)
                            {
                                if (R1.Fila == filaOrigen && R1.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = R1;
                                }
                                else if (T1.Fila == filaOrigen && T1.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = T1;
                                }
                                else if (T2.Fila == filaOrigen && T2.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = T2;
                                }
                                else if (S1.Fila == filaOrigen && S1.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S1;
                                }
                                else if (S2.Fila == filaOrigen && S2.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S2;
                                }
                                else if (S3.Fila == filaOrigen && S3.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S3;
                                }
                                else if (S4.Fila == filaOrigen && S4.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S4;
                                }
                            }
                            else if (J2.Turno == true){
                            

                                if (R2.Fila == filaOrigen && R2.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = R2;
                                }

                                else if (T3.Fila == filaOrigen && T3.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = T3;
                                }
                                else if (T4.Fila == filaOrigen && T4.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = T4;
                                }

                                else if (S5.Fila == filaOrigen && S5.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S5;
                                }
                                else if (S6.Fila == filaOrigen && S6.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S6;
                                }
                                else if (S7.Fila == filaOrigen && S7.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S7;
                                }
                                else if (S8.Fila == filaOrigen && S8.Columna == columnaOrigen)
                                {
                                    piezaSeleccionada = S8;
                                }
                            }
                            if (piezaSeleccionada == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No hay ninguna pieza en esa posición, o selecciona la pieza del rival.");
                                Console.ReadKey();
                                continue;
                            }


                            if (piezaSeleccionada == R1)

                            {
                                do
                                {
                                    Cords();
                                    if (R1.ValidarKing(filaDestino, columnaDestino) == true) { R1.MoverRey(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para el Rey.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para el Rey. El Rey solo puede moverse una casilla en cualquier dirección.");
                                        seguro = false;
                                    }
                                } while (seguro == false);


                            }
                            else if (piezaSeleccionada == R2)
                            {
                                do
                                {
                                    Cords();
                                    if (R2.ValidarKing(filaDestino, columnaDestino) == true) { R2.MoverRey(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para el Rey.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para el Rey. El Rey solo puede moverse una casilla en cualquier dirección.");
                                        seguro = false;
                                    }
                                } while (seguro == false);
                            }
                            else if (piezaSeleccionada == T1)
                            {
                                do
                                {
                                    Cords();
                                    if (T1.ValidarTower(filaDestino, columnaDestino) == true) { T1.MoverTorre(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para la Torre.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para la Torre. La Torre solo puede moverse en línea recta.");
                                        seguro = false;
                                    }

                                } while (seguro == false); }


                            else if (piezaSeleccionada == T2)
                            {
                                do
                                {
                                    Cords();
                                    if (T2.ValidarTower(filaDestino, columnaDestino) == true) { T2.MoverTorre(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para la Torre.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para la Torre. La Torre solo puede moverse en línea recta.");
                                        seguro = false;
                                    }

                                } while (seguro == false);
                            }
                            else if (piezaSeleccionada == T3)
                            {
                                do
                                {
                                    Cords();
                                    if (T3.ValidarTower(filaDestino, columnaDestino) == true) { T3.MoverTorre(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para la Torre.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para la Torre. La Torre solo puede moverse en línea recta.");
                                        seguro = false;
                                    }

                                } while (seguro == false);
                            }
                            else if (piezaSeleccionada == T4)
                            {
                                do
                                {
                                    Cords();
                                    if (T4.ValidarTower(filaDestino, columnaDestino) == true) { T4.MoverTorre(filaDestino, columnaDestino); seguro = true; }
                                    else
                                    {
                                        Console.WriteLine("Movimiento invalido para la Torre.");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Movimiento invalido para la Torre. La Torre solo puede moverse en línea recta.");
                                        seguro = false;
                                    }

                                } while (seguro == false) ;
                            }
                            else if (piezaSeleccionada == S1)
                            {
                                S1.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S2)
                            {
                                S2.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S3)
                            {
                                S3.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S4)
                            {
                                S4.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S5)
                            {
                                S5.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S6)
                            {
                                S6.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S7)
                            {
                                S7.MoverSoldado(filaDestino, columnaDestino);
                            }
                            else if (piezaSeleccionada == S8)
                            {
                                S8.MoverSoldado(filaDestino, columnaDestino);
                            }
                            J1.CambiarTurno();
                            J2.CambiarTurno();
                        }break;
                        


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
