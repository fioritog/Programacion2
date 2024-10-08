
namespace CadenaDeBibliotecas.Modelos
{
    static class Biblioteca
    {
        static List<Libro> Libros = new();
        static List<Usuario> Usuarios = new();
        static readonly string ArchivoUsuario = "usuario.txt";
        static readonly string ArchivoLibros = "Libros.txt";

        static public void AgregarLibro(Libro libro) => Libros.Add(libro);
        static public void AgregarUsuario(Usuario usuario) => Usuarios.Add(usuario);

        static public void RealizarPrestamo(Libro libro, Usuario usuario)
        {
            if (libro.EjemplaresDisponibles >= 1)
            {

                Prestamo unPrestamo = new Prestamo(libro, DateTime.Now);
                usuario.AgregarPrestamo(unPrestamo);
                libro.QuitarEjemplar();
                Console.WriteLine($"Prestamo realizado con exito.");
            }
            else
            {
                Console.WriteLine($"No hay ejemplares disponibles.");
            }
        }
        public static void DevolverLibro(Libro libro, Usuario usuario) 
        {
            Prestamo prestamo = usuario.Prestamos.Find(p=> p.Libro == libro);
            if (prestamo == null)
            {
                Console.WriteLine($"El usuario {usuario.Nombre} no realizó un prestamo del libro {libro.Titulo}");
            }
            else 
            {
                usuario.Quitarprestamo(prestamo);
                libro.AgregarEjemplar();
                Console.WriteLine($"Libro: '{libro.Titulo}' devuelto.");
            }
        } 
    }
}
