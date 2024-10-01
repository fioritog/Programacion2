/*    En una prestigiosa academia, los profesores buscan una forma moderna de gestionar las calificaciones de sus estudiantes.
 
 *    Con las clases en pleno desarrollo, han solicitado un sistema que les permita registrar las calificaciones de los alumnos,
 *    verlas y actualizarlas en caso de ser necesario. Se debe desarrollar un sistema que almacene los nombres de los estudiantes
 *    junto con sus notas. Los profesores pueden agregar nuevos estudiantes, consultar las notas y modificar calificaciones
 *    cuando se descubren errores. La misión es construir este sistema para asegurar que los maestros mantengan las calificaciones
 *    organizadas y siempre actualizadas. 
     
 *    ¿Podrás diseñar este sistema de calificaciones que impulse el rendimiento académico de la academia?     */
class Estudiante
{
    public string Nombre { get; private set; }
    public double Nota { get; private set; }

    public Estudiante(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
    }
}
class Program 
{
    static void Main() 
    {
        IDictionary<string,double> estudiantes = new Dictionary<string,double>();
        int opcion;
        do
        {
            Console.WriteLine($"--------------------------------------");
            Console.WriteLine("Menu:  ");
            Console.WriteLine($"1) Agregar nuevo alumno. ");
            Console.WriteLine($"2) Consultar nota de un alumno. ");
            Console.WriteLine($"3) Modificar la nota de un alumno. ");
            Console.WriteLine($"4) Salir. ");
            Console.WriteLine($"-------------------------------------- \n");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine($"\n");
            switch (opcion) 
            {
                case 1:
                    Console.Write($"Ingrese el apellido del alumno:  ");
                    string apellido = Console.ReadLine();
                    if (estudiantes.ContainsKey(apellido))
                    {
                        Console.WriteLine($"Este alumno ya existe!");
                        
                    }
                    else 
                    {
                        Console.Write($"Ingrese la nota del alumno {apellido}:  ");
                        double nota = double.Parse(Console.ReadLine());

                        Estudiante estudiante1 = new Estudiante(apellido, nota);
                        estudiantes.Add(apellido, nota);
                        estudiantes.TryAdd(apellido, nota);
                        Console.WriteLine($"-- Estudiante agregado --");
                    }

                    break;

                case 2:
                    if (estudiantes.Count > 0)
                    {
                        Console.Write($"Ingrese el apellido del alumno:  ");
                        string ape = Console.ReadLine();
                        if (estudiantes.ContainsKey(ape))
                        {
                            Console.WriteLine($"");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró ese alumno :(");
                        }
                    }
                    else 
                    {
                        Console.WriteLine($"No hay estudiantes!");
                    }
                    break;
                case 3:
                    if (estudiantes.Count > 0)
                    {
                        Console.Write($"Ingrese el apellido del alumno:  ");
                        string a = Console.ReadLine();
                        if (estudiantes.ContainsKey(a))
                        {
                            Console.Write($"Ingrese la nueva nota:  ");
                            int not = int.Parse(Console.ReadLine());
                            estudiantes[a] = not;
                            Console.WriteLine($"-- Nota modificada --");
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró ese alumno :(");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No hay estudiantes (►__◄)");
                    }
                    break;
                default:
                    Console.WriteLine("Opcion no válida. Pruebe de nuevo: ");
                    break;
            }
        }
        while (opcion != 4);
    }
}
