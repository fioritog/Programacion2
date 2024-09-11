
namespace Cine.Modelos
{
    public class Cine
    {
        public string Nombre { get; private set; }
        public List<Sala> Sala { get; private set; }

        public Cine(string nombre)
        {
            Nombre = nombre;
        }
        public void AgregarSala(Sala sala)
        {
            Sala.Add(sala);
        }
    }
}
