

using System.Net.Http.Headers;

namespace TiendaDeELectronicos.modulos
{
    public class Venta
    {
        public DateTime Fecha { get; private set; }
        public Producto ProductoVendido { get; private set; }
        public int Cantidad { get; private set; }
        public Cliente Cliente { get; private set; }

        public Venta(DateTime fecha, Producto productovendido, int cantidad, Cliente cliente) 
        {
            Fecha = fecha;
            ProductoVendido = productovendido;
            Cantidad = cantidad;
            Cliente = cliente;
        }

        public double Calculartotal() 
        {
            double total = 0;
            Console.WriteLine($"Se calculará el total de la venta de {Cliente.Nombre}");
            total = ProductoVendido.Precio * Cantidad;
            Console.WriteLine($"El total de la compra es de ${total}");
            return total;        
        }

        public void MostrarVenta() 
        {
            Console.WriteLine($"------------------------------------");
            Console.WriteLine($"Detalle de la venta:  ");
            Console.WriteLine($"Producto:  {ProductoVendido.Nombre}");
            Console.WriteLine($"Cantidad comprada  {Cantidad}");
            Console.WriteLine($"------------------------------------");

        }

    }
}
