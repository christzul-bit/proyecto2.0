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
            break;
        case 2:
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