

namespace CadenaDeBibliotecas.Modelos
{
    public class Libro
    {
        public string CodLibro { get; private set; }
        public string Titulo {  get; private set; }
        public string Autor {  get; private set; }
        public int EjemplaresDisponibles { get; private set; }

        public Libro(string codLibro, string titulo, string autor, int ejemplares) 
        {
            CodLibro = codLibro;
            Titulo = titulo;
            Autor = autor;
            EjemplaresDisponibles = ejemplares;
        }
        public void AgregarEjemplar() => EjemplaresDisponibles++;
        public void QuitarEjemplar()=> EjemplaresDisponibles--;
    }
}
