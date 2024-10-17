using ViajeEspacial.Enums;

namespace ViajeEspacial.Models
{
    public class Exploracion : Mision
    {
        public Exploracion(string nombre, Destino destinoMision, int astronautas) : base(nombre, destinoMision, astronautas) {}

        public override double CalcularDuracion()
        {
            return Astronautas * 1.5 + (int)DestinoMision * 2; // Fórmula arbitraria
        }

        public override string ToString()
        {
            return $"{GetType().Name}, {Nombre}, {DestinoMision}, {Astronautas}";
        }
    }
}
