
namespace ListaDeTareas.Modulos
{
    public static class Sistema
    {
        static Dictionary<string, Usuario > usuarios = new();
        static readonly string archivo = "usuatios.txt";
        static readonly string userSeparator = "----------------------------------------------------";
        public static void AgregarUsuario() 
        {
            Console.Write("$ Ingrese el nombre del usuario:  ");
            string nombreUsuario = Console.ReadLine();
            if (!usuarios.ContainsKey(nombreUsuario))
            {
                usuarios[nombreUsuario] = new Usuario(nombreUsuario);
                Console.WriteLine($"El usuario fue agregado ^_^");
            }
            else
            {
                Console.WriteLine($"El Usuario ya existe");            
            }

        }
        public static void AgregarTareaAUsuario() 
        {
            Console.Write($"Ingrese el nombre del usuario: ");
            string nombreU = Console.ReadLine();
            if (usuarios.ContainsKey(nombreU))
            {
                Console.WriteLine($"Ingrese la descripcion de la tarea: ");
                string descripcionTarea = Console.ReadLine();
                Tarea tarea = new Tarea(descripcionTarea);

                usuarios[nombreU].AgregarTarea(tarea);
                Console.WriteLine($"Tarea agregada al usuario: {nombreU}");
            }
            else
            {
                Console.WriteLine($"El Usuario NO existe");
            }

        }
        public static void CambiarEstadoUsuario() 
        {
            Console.Write($"Ingrese el nombre del usuario: ");
            string nombreU = Console.ReadLine();
            if (usuarios.ContainsKey(nombreU))
            {
                Console.Write($"Ingrese el numero de la tarea a cambiar (empezando desde 0)");
                int indice = int.Parse(Console.ReadLine());

                usuarios[nombreU].CambiarIsCompletada(indice);
                Console.WriteLine($"Estado de la tarea cambiado! ");
            }
            else
            {
                Console.WriteLine($"El Usuario NO existe");
            }
        }
        public static void MostrarTareasDeUsuario() 
        {
            Console.Write($"Ingrese el nombre del usuario: ");
            string nombreU = Console.ReadLine();
            if (usuarios.ContainsKey(nombreU))
            {
                usuarios[nombreU].MostrarTareas();
            }
            else
            {
                Console.WriteLine($"El Usuario NO existe");
            }
        }
        public static void GuardarDatos() 
        {
            using StreamWriter writer = new StreamWriter(archivo);
            foreach (var usuario in usuarios) 
            {
                writer.WriteLine(usuario.Key);
                foreach (var tarea in usuario.Value.Tareas) 
                {
                    writer.WriteLine($"{tarea.Descripcion} | {tarea.IsCompletada}");
                }
                writer.WriteLine(userSeparator);
            }
            Console.WriteLine($"Datos guardados con exito! (❤️ ω ❤️)");

        }
     }
}
