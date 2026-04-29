//Menu de inicio y declaracion de credenciales
//password admin123+
//user player1

//variable de seguro, sirve como verificacion de las credenciales
bool seguro;
string password;
void IngresarPssw()
{
    password = "";
    Console.WriteLine("Ingrese su contraseña");
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