public class Producto 
{
    public int Codigo { get; private set; }
    public string Nombre { get; private set; }
    public int Cantidad { get; set; }
    public Producto(int codigo, string nombre, int cantidad) 
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
    }

}
public class Program 
{
    static void Main() 
    {
        Dictionary<int,Producto> almacen = new Dictionary<int,Producto>();
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine("Menu:  ");
            Console.WriteLine($"1) Agregar nuevo producto. ");
            Console.WriteLine($"2) Actualizar stock. ");
            Console.WriteLine($"3) Mostrar los productos en stock. ");
            Console.WriteLine($"4) Salir. ");
            Console.WriteLine($"-------------------------------------- \n");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n");
            switch (opcion) 
            {
                case 1:
                    Console.Write($"Ingrese código del producto:  ");
                    int codigo = int.Parse(Console.ReadLine());
                    Console.Write($"Ingrese el nombre del producto:  ");
                    string nombre = Console.ReadLine();
                    Console.Write($"Ingrese cantidad del producto:  ");
                    int cant = int.Parse(Console.ReadLine());
                    Producto prod = new Producto(codigo, nombre, cant);
                    almacen.Add(codigo,prod);
                    almacen.TryAdd(codigo,prod); /*sirve por si se ingresa el mismo codigo dos veces*/
                    Console.WriteLine($"\n");
                    break;
                case 2:
                    Console.Write($"Ingrese el código del producto a actualizar");
                    int cod = int.Parse(Console.ReadLine());
                    if (almacen.ContainsKey(cod))
                    {
                        Console.Write($"Ingrese la nueva cantidad:  ");
                        int canti = int.Parse(Console.ReadLine());
                        almacen[cod].Cantidad = canti;
                        Console.WriteLine($"Cantidad actualizada ╰(*°▽°*)╯");
                    }
                    else 
                    {
                        Console.WriteLine($"Producto no encontrado. :P");   
                    }
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    Console.WriteLine($"Productos en stock:  ");
                    foreach (var producto in almacen.Values) 
                    {
                        Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}");
                    }
                    Console.WriteLine($"\n");
                    break;
            }
        }
        while (opcion != 4);
        Console.WriteLine($"Pulse cualquier tecla para salir");
        
    }
}
