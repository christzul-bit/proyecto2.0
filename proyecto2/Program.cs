//Menu de inicio y declaracion de credenciales
//password admin123+
//user player1

//variable de seguro, sirve como verificacion de las credenciales
bool seguro;

//login de inicio
do {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Ingrese su usuario:");
    Console.ForegroundColor= ConsoleColor.Cyan;
    string usuario = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Ingrese su usuario:");
    Console.ForegroundColor = ConsoleColor.Cyan;
    string pssw = Console.ReadLine();
    if(usuario == "player1" && pssw == "admin123+")
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