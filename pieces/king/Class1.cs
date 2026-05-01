namespace piezas
{
    public class King : Pieza
    {
        public string Figura => "|K|";
        public string Color { get; set; } = "";


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

    public class Tower:Pieza
    {
        public string Figura => "|T|";
        public string Color { get; set; } = "";

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

    public class Soldier:Pieza
    {
        public string Figura => "|S|";
        public string Color { get; set; } = "";
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
}
