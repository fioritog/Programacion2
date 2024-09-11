

using Cine.Enums;

namespace Cine.Modelos
{
    public class Entrada
    {
        public Cine Cine { get; private set; }
        public Pelicula Pelicula { get; private set; }
        public Asientos Asiento { get; private set; }
        public double PrecioBase { get; private set; }
        public DateTime Fecha { get; private set; }
        public double Precio { 
            get 
            {
                /*En caso de ser un asiento superseat, va a salir un 30% más cara la entrada*/
                double precioFinal = 0;
                if (TipoAsiento.Superseat == Asiento.Tipo) 
                {
                    precioFinal = PrecioBase * 1.3;
                }
                return precioFinal;
            }
        }
        public Entrada(Cine cine, Pelicula pelicula, Asientos asiento, double precioBase, DateTime fecha) 
        {
            Cine = cine;
            Pelicula = pelicula;
            Asiento = asiento;
            PrecioBase = precioBase;
            Fecha = fecha;
        }
        public void MostrarDetalles() 
        {
            Console.WriteLine($"-------------------------------------------------------");
            Console.WriteLine($"{Cine.Nombre}");
            Console.WriteLine($"{Fecha}");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"Película   {Pelicula.Nombre}");
            Console.WriteLine($"Género:     {Pelicula.Genero}");
            Console.WriteLine($"Duración (en minutos):    {Pelicula.DuracionMin}");
            Console.WriteLine($"Formato:     {Pelicula.Formato}");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"Asiento a ocupar:   {Asiento.Letra} {Asiento.Numero}");
            Console.WriteLine($"Tipo de asiento:    {Asiento.Tipo}");
            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine($"TOTAL ENTRADA:     {Precio}");
            Console.WriteLine($"------------------------------------------------------");


        }

    }
}
