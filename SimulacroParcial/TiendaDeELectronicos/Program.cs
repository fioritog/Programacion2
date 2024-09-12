namespace TiendaDeELectronicos.modulos;

class Program 
{
    static void Main() 
    {
        /*INGRESAR UN CLIENTE*/
        Cliente cliente1 = new Cliente("Greta", 1234567, "43A179B666");  
        /*mostrar datos del cliente*/
        cliente1.MostrarCliente();

        /*INGRESAR UN PRODUCTO*/
        Producto producto1 = new Producto("papitas", 1000, "PAPAS123");
        /*mostar datos del producto*/
        producto1.MostrarDetalles();

        /*REALIZAR VENTA*/
        Venta venta1 = new Venta(DateTime.Now, producto1, 3,cliente1);
        /*calcular y mostrar total*/
        venta1.Calculartotal();
        /*mostrar detalles de la venta*/
        venta1.MostrarVenta();


    }
}
