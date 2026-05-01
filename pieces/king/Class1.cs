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
}
