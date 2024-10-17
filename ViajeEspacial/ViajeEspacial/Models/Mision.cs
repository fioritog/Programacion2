using ViajeEspacial.Enums;

namespace ViajeEspacial.Models
{
    public abstract class Mision
    {
        public string Nombre { get; private set; }
        public Destino DestinoMision { get; private set; }
        public int Astronautas { get; private set; }

        public Mision(string nombre, Destino destinoMision, int astronautas)
        {
            Nombre = nombre;
            DestinoMision = destinoMision;
            Astronautas = astronautas;
        }

        public abstract double CalcularDuracion(); // Duración en meses
        public override abstract string ToString();
    }
}
