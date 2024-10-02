
namespace ListaDeTareas.Modulos
{
    public class Tarea
    {
        public string Descripcion { get; set; }
        public bool IsCompletada { get; set; }

        public Tarea(string descripcion, bool isCompletada = false) 
        {
            Descripcion = descripcion;
            IsCompletada = isCompletada ;
        }

        public override string ToString() 
        {
            return $"{Descripcion} - {(IsCompletada ? "Completada" : "Pendiente")}";
        }
    }
}
