using System.Security.Cryptography.X509Certificates;
using ViajeEspacial.Enums;

namespace ViajeEspacial.Models
{
    static public class GestionMisiones
    {
        static List<Mision> Misiones { get; set; } = new List<Mision>();
        static string ArchivoMisiones = "misiones.txt";

        static public void AgregarMision(Mision mision)
        {
            Misiones.Add(mision);
            GuardarMision(mision);
            Console.WriteLine($"Misión {mision.Nombre} ha sido agregada.");
        }

        static public void MostrarMisiones()
        {
            if (Misiones.Count == 0) {
                Console.WriteLine("No hay misiones registradas.");
            }
            else
            {
                Console.WriteLine("\nLista de misiones: ");
                foreach (var mision in Misiones)
                {
                    Console.WriteLine(mision);
                }
            }
        }

        static public void ModificarMision(string nombre, Mision nuevaMision)
        {
            var mision = Misiones.Find(m => m.Nombre == nombre);

            if (mision == null)
            {
                Console.WriteLine($"Misión '{nombre}' no encontrada.");
            }
            else
            {
                Misiones.Remove(mision);
                Misiones.Add(nuevaMision);
                GuardarDatos();
                Console.WriteLine($"Misión '{nombre}' ha sido modificada.");
            }
        }

        static public void EliminarMision(string nombre)
        {
            var mision = Misiones.Find(m => m.Nombre == nombre);

            if (mision == null)
            {
                Console.WriteLine($"Misión '{nombre}' no encontrada.");
            }
            else
            {
                Misiones.Remove(mision);
                GuardarDatos();
                Console.WriteLine($"Misión '{nombre}' ha sido eliminada.");
            }
        }
        static void GuardarMision(Mision mision) 
        {
            using StreamWriter writer = new(ArchivoMisiones, true);
            writer.WriteLine(mision);
        }

        static void GuardarDatos() 
        {
            using StreamWriter writer = new(ArchivoMisiones);
            foreach (var m in Misiones) 
            {
                writer.WriteLine(m);
            }
        }
        static public void CargarDatos() 
        {
            if (File.Exists(ArchivoMisiones)) 
            {
                foreach (var linea in File.ReadAllLines(ArchivoMisiones)) 
                {
                    string[] d = linea.Split(", ");
                    Mision m = null;

                    string nombre = d[1];
                    Destino destino = (Destino)Enum.Parse(typeof(Destino), d[2]);
                    int astronautas = int.Parse(d[3]);

                    if (d[0] == typeof(Exploracion).Name) 
                    {
                        m = new Exploracion(nombre, destino, astronautas);
                    }
                    if (d[0] == typeof(Colonizacion).Name)
                    {
                        m = new Colonizacion(nombre, destino, astronautas, int.Parse(d[4]));
                    }
                    if (d[0] == typeof(Investigacion).Name)
                    {
                        m = new Investigacion(nombre, destino, astronautas, d[4]);
                    }
                    Misiones.Add(m);
                    m = null;
                }
            }
            
            
        }
    }
}
