
namespace Cine.Modelos
{
    class Program 
    {
        static void Main() 
        {
            Cine cine = new Cine("Showcase");

            Sala sala1 = new Sala(1);

            Pelicula pelicula1 = new Pelicula("La La Land","Horror", 115, Enums.Formato.IMAX_Subtitulado);
            
            Asientos unasiento = new Asientos('C',3,Enums.TipoAsiento.Estandar);
            /*Agregar sala al cine*/
            cine.AgregarSala(sala1);
            /*Agregar asiento a la sala*/
            sala1.AgregarAsiento(unasiento);
            /*Definir horario de la funcion en la sala*/
            sala1.DefinirHorario(DateTime.Now);
            Entrada entrada1 =  new Entrada(cine,pelicula1,unasiento,100,DateTime.Now);
            /*Al comprar la entrada, cambiar de estado a ocupado*/
            unasiento.CambiarEstado();
            /*imprimir detalles de la entrada*/
            entrada1.MostrarDetalles();
            /*Reproducir película*/
            sala1.ReproducirPelicula(pelicula1);


        }
    }
}