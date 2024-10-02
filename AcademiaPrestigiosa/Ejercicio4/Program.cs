/*Un banco quiere implementar un sistema que gestione la cola de espera para atención al cliente. Los clientes son atendidos
 en el orden en que llegan.

El sistema debe:
1. Agregar un cliente a la cola.
2. Atender al cliente que está en la primera posición.
3. Mostrar los clientes que están en la cola. */
using Ejercicio4.Modelos;
using System.Threading;

class Program 
{
    static void Main()
    {
        Queue<Cliente> ColaDeClientes = new Queue<Cliente>();
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine("Menu:  ");
            Console.WriteLine($"1) Agregar cliente a la cola. ");
            Console.WriteLine($"2) Atender al proximo cliente. ");
            Console.WriteLine($"3) Mostrar los clientes en la cola ");
            Console.WriteLine($"4) Salir. ");
            Console.WriteLine($"-------------------------------------- \n");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n");
            switch (opcion) 
            {
                case 1:
                    Console.WriteLine($"Ingresá el nombre del cliente:  ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine($"Ingresá el número del cliente:  ");
                    int numero = int.Parse(Console.ReadLine());
                    Console.WriteLine($"\n");
                    Cliente c = new Cliente(nombre, numero);
                    ColaDeClientes.Enqueue(c);
                    break;
                case 2:
                    if (ColaDeClientes.Count > 0)
                    {
                        Cliente clienteAtendido = ColaDeClientes.Dequeue();
                        Console.WriteLine($"Atender a: {clienteAtendido.Nombre}, {clienteAtendido.NumeroDeCliente}");
                    }
                    else 
                    {
                        Console.WriteLine($"No hay clientes en la cola para atender");
                    }
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    Console.WriteLine($"Los clientes en la cola son:  ");
                    foreach (var cliente in ColaDeClientes)
                    {
                        Console.WriteLine($"{cliente.Nombre},  {cliente.NumeroDeCliente}");
                    }
                    Console.WriteLine($"\n");
                    break;
            }
        }
        while (opcion != 4);
        Console.WriteLine($"Pulse cualquier tecla para salir!!!!!!!!! ");
    }
}