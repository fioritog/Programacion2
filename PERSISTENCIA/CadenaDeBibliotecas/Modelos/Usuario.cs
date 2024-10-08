
namespace CadenaDeBibliotecas.Modelos
{
    public class Usuario
    {
        public string Nombre { get; private set; }
        public List<Prestamo> Prestamos { get; private set; } = new List<Prestamo>();
        public Usuario(string nombre, List<Prestamo> prestamo) 
        {
            Nombre = nombre;
            Prestamos = prestamo;
        }
        public Usuario(string nombre, Prestamo prestamo)
        {
            Nombre = nombre;
            Prestamos.Add(prestamo);
        }
        public void AgregarPrestamo(Prestamo prestamo) 
        {
            Prestamos.Add(prestamo);
        }
        public void Quitarprestamo(Prestamo prestamo)
        {
            Prestamos.Remove(prestamo);
        }
    }
}
