using ViajeEspacial.Enums;

namespace ViajeEspacial.Models
{
    static public class Menu
    {

        private static List<Action> Acciones = new List<Action>
        {
            AgregarMision,
            MostrarMisiones,
            ModificarMision,
            EliminarMision
        };

        public static void MostrarMenu()
        {
            GestionMisiones.CargarDatos();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú de misiones ---\n" +
                    "1. Agregar misión\n" +
                    "2. Mostrar misiones\n" +
                    "3. Modificar misión\n" +
                    "4. Eliminar misión\n" +
                    "5. Salir\n");
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

        static Mision CrearMision(string nombre)
        {
            Console.WriteLine("Seleccione el destino: ");
            foreach (var destino in Enum.GetValues(typeof(Destino)))
            {
                Console.WriteLine($"{(int)destino}. {destino}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Destino destinoSeleccion = (Destino)seleccion;

            Console.Write("Ingrese la cantidad de astronautas: ");
            int astronautas = int.Parse(Console.ReadLine());

            Console.WriteLine("Seleccione el tipo de misión: ");
            Console.WriteLine("1. Exploración. ");
            Console.WriteLine("2. Colonización. ");
            Console.WriteLine("3. Investigación. ");

            int tipo = int.Parse(Console.ReadLine());

            Mision nuevaMision = null;

            switch (tipo)
            {
                case 1:
                    nuevaMision = new Exploracion(nombre, destinoSeleccion, astronautas);
                    break;
                case 2:
                    Console.Write("Ingrese la cantidad de colonos: ");
                    int colonos = int.Parse(Console.ReadLine());
                    nuevaMision = new Colonizacion(nombre, destinoSeleccion, astronautas, colonos);
                    break;
                case 3:
                    Console.Write("Ingrese el campo de investigación: ");
                    string campo = Console.ReadLine();
                    nuevaMision = new Investigacion(nombre, destinoSeleccion, astronautas, campo);
                    break;
                default:
                    Console.WriteLine("Tipo de misión inválido");
                    break;
            }
            return nuevaMision;
        }

        static void AgregarMision() {
            Console.Write("Ingrese el nombre de la misión: ");
            string nombre = Console.ReadLine();

            var nuevaMision = CrearMision(nombre);

            GestionMisiones.AgregarMision(nuevaMision);
        }

        static void MostrarMisiones() => GestionMisiones.MostrarMisiones();

        static void ModificarMision()
        {
            Console.Write("Ingrese el nombre de la misión: ");
            string nombre = Console.ReadLine();

            var nuevaMision = CrearMision(nombre);

            GestionMisiones.ModificarMision(nombre, nuevaMision);
        }

        static void EliminarMision()
        {
            Console.Write("Ingrese el nombre de la misión: ");
            string nombre = Console.ReadLine();
            GestionMisiones.EliminarMision(nombre);
        }

    }
}
