
namespace ListaDeTareas.Modulos
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public List<Tarea> Tareas { get; set; }

        public Usuario(string nombreUsuario) 
        {
            Nombre = nombreUsuario;
            Tareas = new List<Tarea>();
        }
        public void AgregarTarea(Tarea tarea) => Tareas.Add(tarea);
        public void MostrarTareas() 
        {
            Console.WriteLine($"Tareas de {Nombre}:");
            foreach (var tarea in Tareas) 
            {
                Console.WriteLine($"{tarea}");
            }
            if (Tareas.Count > 0) 
            {
                Console.WriteLine($"{Nombre} no tiene ninguna tarea en el momento.");
            }
        }
        public void CambiarIsCompletada(int indice) 
        {
            if (indice >= 0 && indice < Tareas.Count)
            {
                Tareas[indice].IsCompletada = !Tareas[indice].IsCompletada;
            }
            else 
            {
                Console.WriteLine($"No existe la tarea indicada");
            }
        }
    }
}
