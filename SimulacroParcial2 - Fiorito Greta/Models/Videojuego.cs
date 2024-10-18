
using SimulacroParcial2___Fiorito_Greta.Enumerations;

namespace SimulacroParcial2___Fiorito_Greta.Models
{
    public class Videojuego
    {
        public string Nombre { get; private set; }
        public Plataforma Plataforma { get; private set; }
        public double Precio { get; private set; }
        public int Stock {  get; private set; }

        public Videojuego(string nombre, Plataforma plataforma, double precio, int stock) 
        {
            Nombre = nombre;
            Plataforma = plataforma;
            Precio = precio;
            Stock = stock;
        }
        public override string ToString()
        {
            return $"{Nombre}, {GetType().Name}, {Precio}, {Stock}";
        }
    }
}
