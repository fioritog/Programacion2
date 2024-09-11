namespace Cine.Modelos
{
    public class Cine
    {
        public string Nombre { get; private set; }
        public List<Sala> Salas { get; private set; } = new List<Sala>();

        public Cine(string nombre)
        {
            Nombre = nombre;
        }
        public void AgregarSala(Sala sala)
        {
            Salas.Add(sala);
        }
        public void AgregarSala(List<Sala> salas)
        {
            Salas.AddRange(salas);
        }
    }
}
