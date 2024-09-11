

namespace Cine.Modelos
{
    public class Sala
    {
        public int Numero { get; private set; }
        public List<Asientos> Asiento { get; private set; }
        public Pelicula Pelicula { get; private set; }
        public DateTime Horario { get; private set; }
        public Sala(int numero) 
        {
            Numero = numero;
        }
        public Sala(int numero, List<Asientos> asiento, Pelicula pelicula, DateTime horario) 
        {
            Numero = numero;
            Asiento = asiento;
            Pelicula = pelicula;
            Horario = horario;
        }
        public void AgregarAsiento(Asientos asiento) 
        {
            Asiento.Add(asiento);
        }
        public void AgregarAsiento(List<Asientos> asiento) 
        {
            Asiento.AddRange(asiento);
        }
        public void DefinirHorario(DateTime hora) 
        {
            Horario = hora;
        }
        public void ReproducirPelicula(Pelicula pelicula) 
        {
            Pelicula = pelicula;
            Console.WriteLine($"Comenzó la funcion de la sala {Numero} de la película {Pelicula.Nombre}");
            Console.WriteLine($"-----------------------------------------------------------------------");
            Console.WriteLine($"Terminó la funcion de la sala {Numero} de la película {Pelicula.Nombre}");
            Console.WriteLine($"-----------------------------------------------------------------------");
            /*DESOCUPAR LOS ASIENTOS DE LA SALA CUANDO TERMINA LA PELICULA*/
            foreach (var asiento in Asiento) 
            {
                if (asiento.Ocupado == true) 
                {
                    asiento.CambiarEstado();
                }
            }
        }

    }
}
