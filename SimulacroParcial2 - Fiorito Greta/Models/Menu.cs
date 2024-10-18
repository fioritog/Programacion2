using SimulacroParcial2___Fiorito_Greta.Enumerations;
using System.Runtime.CompilerServices;

namespace SimulacroParcial2___Fiorito_Greta.Models
{
    abstract class Menu
    {
        private static List<Action> Acciones = new()
        {
            AgregarVideojuego,
            MostrarCatalogo,
            ActualizarVideojuego,
            EliminarVideojuego,

        };
        public static void MostrarMenu()
        {
            SysVideojuegos.CargarDatos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú de misiones ---\n" +
                    "1. Agregar videojuego.\n" +
                    "2. Mostrar el catalogo.\n" +
                    "3. Actualizar Videojuego\n" +
                    "4. Eliminar videojuego\n" +
                    "5. Guardar y Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else 
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
                else
                {
                    Console.WriteLine($"\nOpción no válida.");
                }
            }
        }

        static void AgregarVideojuego()
        {
            Console.Write("Ingrese el nombre del videojuego: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Seleccione la plataforma del juego: ");
            foreach (var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma+1}. {plataforma}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Plataforma plataformaseleccionada = (Plataforma)seleccion;
            Console.Write("Ingrese el precio del videojuego: ");
            var precio = double.Parse(Console.ReadLine());
            Console.Write("Ingrese el stock del videojuego: ");
            var stock = int.Parse(Console.ReadLine());

            Videojuego nuevoVideojuego = new Videojuego(nombre, plataformaseleccionada, precio, stock);

            SysVideojuegos.AgregarVideojuego(nuevoVideojuego);
        }
        static void MostrarCatalogo() => SysVideojuegos.MostrarCatalogo();
        static void ActualizarVideojuego() 
        {
            Console.Write($"Ingrese el nombre del videojuego a modificar: ");
            string nombre = Console.ReadLine();

            SysVideojuegos.ActualizarVideojuego(nombre);
        }
        static void EliminarVideojuego() 
        {
            Console.Write($"Ingrese el nombre del videojuego a eliminar: ");
            string nombre = Console.ReadLine();

            SysVideojuegos.EliminarVideojuego(nombre);
        }
    }
}
