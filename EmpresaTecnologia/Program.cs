/* En una empresa tecnológica, un equipo de soporte técnico necesita gestionar una gran cantidad de tickets de usuarios que
 reportan problemas. Para facilitar esta tarea, el departamento de TI ha desarrollado un sistema automatizado que les permite
 agregar y procesar solicitudes de manera eficiente. Cada vez que un cliente reporta un problema, el sistema asigna un número
 de ticket único y lo coloca en una cola para ser atendido en orden de llegada. El desafío del programador es diseñar este
 sistema de tickets, permitiendo a los técnicos ver la lista de problemas pendientes y procesar los tickets uno por uno,
 asegurando que ningún problema quede sin resolver. ¿Podrás construir este sistema de soporte eficiente para ayudar al equipo
 técnico a mantenerse organizado?  */

class Ticket 
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public Ticket(int id, string descripcion) 
    {
        Id = id;
        Descripcion = descripcion;
    }
}
class SistemaDeTickets 
{
    private Queue<Ticket> ColaDeTickets = new Queue<Ticket>();
    private int siguienteId = 0;

    public void AgregarTicket(string descripcion) 
    {
        Ticket nuevoTicket = new Ticket(++siguienteId, descripcion);
        ColaDeTickets.Enqueue(nuevoTicket);
        Console.WriteLine($"Ticket  #{nuevoTicket.Id} agregado: {nuevoTicket.Descripcion}");
    }
    public void ProcesarTicket() 
    {
        if (ColaDeTickets.Count == 0) 
        {
            Console.WriteLine($"No hay tickets para procesar. :)");
            return;
        }
        Ticket ticket = ColaDeTickets.Dequeue();
        Console.WriteLine($"Ticket #{ticket.Id} está siendo procesado. ");
    }
    public void MostrarTickets() 
    {
        if (ColaDeTickets.Count == 0)
        {
            Console.WriteLine($"No hay tickets pendientes ");
            return;
        }
        Console.WriteLine($" Tickets pendientes:  ");
        foreach (var ticket in ColaDeTickets) 
        {
            Console.WriteLine($"Ticket #{ticket.Id}: {ticket.Descripcion}");
        }
    }
}
class Program 
{
    static void Main() 
    {
        SistemaDeTickets sistema = new SistemaDeTickets();
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine("Menu:  ");
            Console.WriteLine($"1) Agregar nuevo ticket. ");
            Console.WriteLine($"2) Ver tickets pendientes. ");
            Console.WriteLine($"3) Prosesar el ticket siguiente. ");
            Console.WriteLine($"4) Salir. ");
            Console.WriteLine($"-------------------------------------- \n");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n");
            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"Ingrese la descripción de un nuevo ticket: ");
                    string descrip = Console.ReadLine();
                    sistema.AgregarTicket(descrip);
                    Console.WriteLine($"\n");
                    break;
                case 2:
                    sistema.MostrarTickets();
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    sistema.ProcesarTicket();
                    Console.WriteLine($"\n");
                    break;
                default:
                    Console.WriteLine($"Opción no válida. Pruebe de vuelta");
                    break ;
            }
        }
        while (opcion != 4);
        Console.WriteLine($"Pulse cualquier tecla para salir");

    }
}



