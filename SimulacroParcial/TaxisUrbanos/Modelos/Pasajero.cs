

namespace TaxisUrbanos.Modelos
{
    public class Pasajero
    {
        public string Nombre { get; private set; }
        public string Direccion { get; private set; }
        public bool IsMiembro { get; private set; } = false;
        public Viaje viaje { get; private set; }

        public Pasajero(string nombre, string direccion) 
        {
            Nombre = nombre;
            Direccion = direccion;
        }

        public bool CambiarMembresia(bool ismiembro) 
        {
            return ismiembro = !ismiembro; 
        }
        public void RealizarViaje(Viaje viaje) 
        {

        }
    }
}
