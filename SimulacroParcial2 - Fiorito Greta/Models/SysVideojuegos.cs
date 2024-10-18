using SimulacroParcial2___Fiorito_Greta.Enumerations;

namespace SimulacroParcial2___Fiorito_Greta.Models
{
    abstract class SysVideojuegos
    {
        static public List<Videojuego> Catalogo = new();
        static string ArchivoCatalogo = "Catalogo.txt";

        static public void AgregarVideojuego(Videojuego videojuego) 
        {
            Catalogo.Add(videojuego);
            GuardarVideojuego(videojuego);
        }
        static public void MostrarCatalogo() 
        {
            if (Catalogo.Count == 0)
            {
                Console.WriteLine($"No hay videojuegos en el catálogo.");
            }
            else 
            {
                foreach (var v in Catalogo)
                {
                    Console.WriteLine(v);
                }
            }  
        }
        static public void ActualizarVideojuego(string nombre) 
        {
           var videoj = Catalogo.Find(vj => vj.Nombre == nombre);
            if (videoj == null)
            {
                Console.WriteLine($"Videojuego no encontrado. ");
            }
            else 
            {
                Console.Write($"Ingrese el nuevo precio del videojuego: ");
                var precio = double.Parse(Console.ReadLine());
                Console.Write($"Ingrese el nuevo stock del videojuego: ");
                var stock = int.Parse(Console.ReadLine());
                Catalogo.Remove(videoj);
                Videojuego nuevoVideojuego = new Videojuego(nombre, videoj.Plataforma, precio,stock );
                Catalogo.Add(nuevoVideojuego);
                Console.WriteLine($"\nVideojuego: {nombre} actualizado!");
                GuardarDatos();
            }
           
        }
        static public void EliminarVideojuego(string nombre) 
        {
            var videoj = Catalogo.Find(vj => vj.Nombre == nombre);
            if (videoj == null)
            {
                Console.WriteLine($"Videojuego no encontrado. ");
            }
            else
            {
                Catalogo.Remove(videoj);
                GuardarDatos();
                Console.WriteLine($"Videojuego {nombre} removido del catalogo");
            }
        }
        static public void GuardarVideojuego(Videojuego videojuego) 
        {
            using StreamWriter writer = new(ArchivoCatalogo);
            writer.WriteLine(videojuego);
        }
        static public void GuardarDatos() 
        {
            using StreamWriter writer = new(ArchivoCatalogo);
            foreach (var v in Catalogo) 
            {
                writer.WriteLine(v);
            }
        }
        static public void CargarDatos()
        {
            if (File.Exists(ArchivoCatalogo))
            {
                foreach (var linea in File.ReadAllLines(ArchivoCatalogo))
                {
                    string[] d = linea.Split(", ");
                    Videojuego vj = null;

                    string nombre = d[0];
                    Plataforma plataforma = (Plataforma)Enum.Parse(typeof(Plataforma), d[1]);
                    double precio = double.Parse(d[2]);
                    int stock = int.Parse(d[3]);
                    vj = new Videojuego(nombre, plataforma, precio, stock);
                    Catalogo.Add(vj);
                    vj = null;
                }

            }
        }
    }
}
