

namespace Ejercicio4.Modelos
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public int NumeroDeCliente { get; set; }

        public Cliente(string nombre, int numeroCliente)
        {
            Nombre = nombre;
            NumeroDeCliente = numeroCliente;
        }
    }
}
