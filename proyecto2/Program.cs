//Menu de inicio y declaracion de credenciales
//password admin123+
//user player1

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
        if(tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Backspace)
        {
            password += tecla.KeyChar;
            Console.Write("*");
        }else if (tecla.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password = password.Substring(0, (password.Length - 1));
            Console.Write("\b \b");
        }
    }while (tecla.Key != ConsoleKey.Enter);
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
    }else
    {
        seguro = true;
    }
}
//login de inicio
do {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Ingrese su usuario:");
    Console.ForegroundColor= ConsoleColor.Cyan;
    string usuario = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Ingrese su contraseña:");
    Console.ForegroundColor = ConsoleColor.Cyan;
    IngresarPssw();
    if(usuario == "player1" && password == "admin123+")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Credenciales correctas");
        seguro = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Credenciales incorrectas, revise nuevamente");
        seguro= false;
    }
}while(seguro ==  false);
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
        if(seguro == true)
        {
            opcion = cantidad;
        }
    }while(seguro == false);
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
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{Table[i,j]} ");
                }
                Console.WriteLine();
            }
            break;
        case 2:
            Console.WriteLine("                              Reglas del juego");
            Console.WriteLine(@"
    1.  Funcionamiento general del juego
        1.   El juego se desarrolla sobre un tablero representado por una matriz de 8x8.
        2.   Cada posición de la matriz corresponde a una casilla del tablero.
        3.   El tablero debe mostrarse en consola en cada turno de forma clara, permitiendo a los jugadores
             ver el estado actual del juego.
        Cada jugador contará con las siguientes piezas:
            • 1 Rey
            • 2 Torres
            • 4 Soldados
        Estas piezas deben colocarse en posiciones iniciales definidas automáticamente por el sistema.


    2.  Movimiento de piezas
        Durante su turno, el jugador debe ingresar la posición de origen y la posición de destino, indicando fila y columna.
        El sistema no debe ejecutar el movimiento  directamente. Primero debe validar completamente que el movimiento sea correcto según las reglas del juego. 


    3.  Reglas de movimiento
        Cada tipo de pieza tiene un comportamiento específico que debe respetarse en todo momento.
            • Rey: puede moverse una sola casilla en cualquier dirección (horizontal, vertical o diagonal).
            • Torre: puede moverse en línea recta (horizontal o vertical), recorriendo varias casillas si el camino está libre. No puede saltar piezas.
            • Soldado:
                 avanza una casilla hacia adelante
                 ataca en diagonal
                 no puede retroceder
            Si un movimiento no cumple estas reglas, el sistema debe rechazarlo.
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