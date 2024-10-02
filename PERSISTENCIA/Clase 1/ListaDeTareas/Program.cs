/* Se va a implementar un sistema de gestión de -tareas- pendientes para un grupo de -usuarios-. Cada usuario tiene una
 lista de tareas, y cada tarea contiene una descripción y un estado (pendiente o completada). El sistema debe permitir 
 agregar nuevas tareas, cambiar su estado, listar las tareas por usuario y guardar toda la información en archivos de texto 
 para que persistan entre ejecuciones.

Requerimientos:
1. Crea una clase Tarea con las propiedades Descripcion y Completada.
2. Crea una clase Usuario con las propiedades NombreUsuario y una lista de tareas.
3. Usa:
- Un Diccionario (Dictionary<string, Usuario>) donde la clave es el nombre del usuario y el valor es el objeto Usuario.
4. El sistema debe permitir:
- Agregar nuevos usuarios.
- Añadir tareas a un usuario.
- Cambiar el estado de una tarea (de pendiente a completada y viceversa).
- Mostrar todas las tareas de un usuario.
- Guardar los datos de los usuarios y tareas en un archivo de texto.
- Cargar los datos de un archivo de texto al iniciar el programa.  */

using ListaDeTareas.Modulos;

public class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine("Menu:  ");
            Console.WriteLine($"1) Agregar nuevo usuario. ");
            Console.WriteLine($"2) Agregar tarea al usuario. ");
            Console.WriteLine($"3) Cambiar el estado de una tarea. ");
            Console.WriteLine($"4) Mostrar todas las tareas de un usuario. ");
            Console.WriteLine($"5) Guardar y salir. ");
            Console.WriteLine($"-------------------------------------- \n");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n");
            switch (opcion)
            {
                case 1:
                    Sistema.AgregarUsuario();
                    Console.WriteLine($"\n");
                    break;
                case 2:
                    Sistema.AgregarTareaAUsuario();
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    Sistema.CambiarEstadoUsuario();
                    Console.WriteLine($"\n");
                    break;
                case 4:
                    Sistema.MostrarTareasDeUsuario();
                    Console.WriteLine($"\n");
                    break;
                default:                
                    Console.WriteLine($"Opcion inválida. Pruebe de nuevo");
                    Console.WriteLine($"\n");
                    break;
            }

        } while (opcion != 5);
    }
}