

using TaxisUrbanos.Enumerations;

namespace TaxisUrbanos.Modelos
{
    public class Viaje
    {
        public Pasajero Pasajero { get; private set; }
        public TipoVehiculo Vehiculo { get; private set; }  
        public Conductor Conductor { get; private set; }
        public int Distancia { get; private set; }
        public double Precio { 
            get {
                double tarifaBase = 10.00;
                tarifaBase = tarifaBase + (2.00 * Distancia);
                if (Pasajero.IsMiembro == true) 
                {
                    tarifaBase = tarifaBase * 0.90;
                }
                return tarifaBase;    
            }
        }
        public Viaje(Pasajero pasajero,Conductor conductor, TipoVehiculo vehiculo, int distancia) 
        {
            Pasajero = pasajero;
            Conductor = conductor;
            Vehiculo = vehiculo;
            Distancia = distancia;

        }
        public void MostarDetallesViaje() 
        {
            Console.WriteLine($"--------------------------------");
            Console.WriteLine($"El viaje fue realizado por {Conductor.Nombre} en {} ");
            Console.WriteLine($"");
        
        }

    }
}
