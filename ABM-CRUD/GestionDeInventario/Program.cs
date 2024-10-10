/*
Se va a implementar un sistema de gestión de productos en un inventario. Cada producto tiene un nombre, un precio y una cantidad
en stock. El sistema debe permitir realizar las siguientes operaciones:

- Alta (Create): Agregar un nuevo producto al inventario.
- Baja (Delete): Eliminar un producto del inventario.
- Modificación (Update): Actualizar la información de un producto existente (nombre, precio o cantidad).
- Consulta (Read): Mostrar todos los productos del inventario.
Los productos deben persistir en un archivo de texto entre ejecuciones del programa.

Requerimientos:
1. Crea una clase Producto con las propiedades Nombre, Precio y Cantidad.
2. Usa una Lista (List<Producto>) para almacenar los productos.
3. El sistema debe permitir realizar operaciones CRUD y guardar los productos en un archivo de texto.
 */

using System.ComponentModel.Design;
using System.Linq.Expressions;

class Producto 
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public Producto(string nombre, double precio, int cantidad) 
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
    public override string ToString()
    {
        return $"{Nombre}; {Precio}; {Cantidad}";
    }
}
static class Sistema
{
    public static  List<Producto> Productos { get; set; } = new();
    static readonly string ArchivoProductos = "Productos.txt";

    static public void AgregarProducto() 
    {
        Console.Write($"Ingrese el nombre del nuevo producto: ");
        string nombre = Console.ReadLine();
        Console.Write($"Ingrese el precio de {nombre}: ");
        double precio = double.Parse(Console.ReadLine());
        Console.Write($"Ingrese catidad del producto: ");
        int cantidad = int.Parse(Console.ReadLine());

        Productos.Add(new Producto(nombre, precio, cantidad));
        Console.WriteLine($"Producto agregado!");
        Console.WriteLine($"\n");
    }
    static public void EliminarProducto() 
    {
        Console.Write($"Ingrese el nombre del nuevo producto: ");
        string nombre = Console.ReadLine();
        var p = Productos.Find(prod => prod.Nombre == nombre);
        if (p != null)
        {
            Productos.Remove(p);
            Console.WriteLine($"Producto eliminado! ");
        }
        else 
        {
            Console.WriteLine($"Producto no encontrado! ");
        }

        
    }
    static public void ModificarProducto() 
    {
        Console.Write($"Ingrese el nombre del nuevo producto: ");
        string nombre = Console.ReadLine();
        var p = Productos.Find(prod => prod.Nombre == nombre);
        if (p.Nombre != null)
        {
            Console.WriteLine($"Presione la tecla enter para omitir actualizar una propiedad. ");
            Console.Write($"Ingrese el nombre del nuevo producto: ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) 
            {
                p.Nombre = nuevoNombre;
            }
            Console.Write($"Ingrese el precio de {nuevoNombre}: ");
            string nuevoPrecio = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoPrecio))
            {
                p.Precio = double.Parse(nuevoPrecio);
            }
            Console.Write($"Ingrese catidad del producto: ");
            string nuevaCantidad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaCantidad))
            {
                p.Cantidad = int.Parse(nuevaCantidad);
            }

            Console.WriteLine($"Producto actualizado!");

        }
        else 
        {
            Console.WriteLine($"Producto no encontrado! ");
        }
    }
    public static void MostrarInventario() 
    {
        Console.WriteLine($"\nLista de productos:");
        foreach (var prod in Productos) 
        {
            Console.WriteLine(prod);
        }
    }
    public static void GuardarDatos() 
    {
        using StreamWriter writerProductos = new StreamWriter(ArchivoProductos);
        
        foreach (var prod in Productos) 
        {
            writerProductos.WriteLine(prod);
        }
        Console.WriteLine($"Productos cargados exitosamente! ");

    }
   public static void CargarDatos() 
    {
        if (File.Exists(ArchivoProductos)) 
        {
            using StreamReader reader = new StreamReader(ArchivoProductos);
            string linea;
            while ((linea = reader.ReadLine()) != null) 
            {
                var datos = linea.Split('-');
                Producto prod = new Producto(datos[0], double.Parse(datos[1]), int.Parse(datos[2]));
            }
        }
    }
}

class Program 
{
    static void Main() 
    {
        Sistema.CargarDatos();
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------------");
            Console.WriteLine($"Menú");
            Console.WriteLine($"1) Agregar producto al inventario. ");
            Console.WriteLine($"2) Eliminar un producto al inventario. ");
            Console.WriteLine($"3) Modificar/Actualizar un prod existente. ");
            Console.WriteLine($"4) Mostar todos los productos del inventario. ");
            Console.WriteLine($"5) Guardar y salir. ");
            Console.WriteLine($"--------------------------------------------");
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Sistema.AgregarProducto();
                    Console.WriteLine($"\n");
                    break;
                case 2:
                    Sistema.EliminarProducto();
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    Sistema.ModificarProducto();
                    Console.WriteLine($"\n");
                    break;
                case 4:
                    Sistema.MostrarInventario();
                    Console.WriteLine($"\n");
                    break;
                default:
                    Console.WriteLine($"opción no válida! ");
                    break;
            }        
           Console.WriteLine($"La opcion ingresada no es válida");
            
        } while (opcion != 5);
        Sistema.GuardarDatos();
    }
}