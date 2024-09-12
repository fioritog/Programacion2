

namespace TaxisUrbanos.Modelos
{
    public class Conductor
    {
        public string Nombre { get; private set; }
        public int NumeroLicencia { get; private set; }
        public bool IsDisponible { get; private set; } = false;

        public Conductor(string nombre, int numeroLicencia)
        { 
            Nombre = nombre;
            NumeroLicencia = numeroLicencia;
        }

        public bool CambiarDisponibilidad(bool isdisponible) 
        {
            return isdisponible = !isdisponible; 
        }
    }
}
