/* 
 En una empresa, se requiere un sistema para gestionar a los empleados. Cada empleado pertenece a un departamento específico,
y los departamentos están definidos mediante un enum. El sistema debe almacenar a los empleados en un Diccionario, donde la clave
es el ID del empleado y el valor es un objeto que representa al empleado. Además, los datos deben persistir en un archivo de texto.

Los departamentos disponibles son:
- RecursosHumanos
- Finanzas
- Tecnologia
- Marketing
- Ventas

El sistema debe permitir realizar las siguientes operaciones:
- Alta (Create): Agregar un nuevo empleado.
- Baja (Delete): Eliminar un empleado.
- Modificación (Update): Modificar los datos de un empleado.
- Consulta (Read): Listar todos los empleados y su información.

Requerimientos:
1. Crea una clase Empleado con las propiedades Id, Nombre, Edad, y Departamento (de tipo enum).
2. Usa un Diccionario (Dictionary<int, Empleado>) para almacenar los empleados.
3. Implementa las operaciones CRUD y permite guardar los empleados en un archivo de texto.
*/
public enum Departamento 
{
    RecursosHumanos,
    Finanzas,
    Tecnología,
    Marketing,
    Ventas
}
class Empleado 
{
    public int ID {  get; set; }
    public string Nombre { get; set; }
    public int Edad {  get; set; }
    public Departamento Departamento { get; set; }

    public Empleado(int id, string nombre, int edad, Departamento dept) 
    {
        ID = id;
        Nombre = nombre;
        Edad = edad;
        Departamento = dept;
    }

    public override string ToString()
    {
        return $"{ID}, {Nombre}, {Edad}, {Departamento}";
    }
}
static class SysEmpleado
{
     static Dictionary<int, Empleado> Empleados = new();
     static readonly string ArchivoEmpleados = "Empleados.txt";

    static public void MostrarEmpleados() 
    {
        if (Empleados.Count > 0)
        {
            Console.WriteLine($"\nLista de empleados: ");
            foreach (var e in Empleados.Values)
            {
                Console.WriteLine(e);
            }
        }
        else 
        {
            Console.WriteLine($"\nNo hay empleados. ");
        }
        
    }
    static public void AgregarEmpleado() 
    {
        bool valid;
        int id, edad, deptIndex;
        string nombre = null!;
        Departamento departamento = Departamento.RecursosHumanos;
        do
        {
            Console.Write($"Ingrese el ID del empleado: ");
            valid = int.TryParse(Console.ReadLine(), out id);

            if (!valid) { Console.WriteLine($"El dato no es de tipo entero"); }
        }
        while (!valid);
        valid = false;
        do
        {
            Console.Write($"Ingrese el nombre del empleado:  ");
            nombre = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine($"El nombre ne debe estar vacío ");
            }
            else 
            {
                valid = true;
            }
        }
        while (!valid);
        valid = false;

        do
        {
            Console.Write($"Ingrese la edad del empleado: ");
            valid = int.TryParse(Console.ReadLine(), out edad);

            if (!valid) { Console.WriteLine($"El dato ingresado no es de tipo entero"); }
        }
        while (!valid);
        valid = false;

        do 
        {
            Console.WriteLine($"Seleccione el departamento del empleado: ");
            foreach (var dept in Enum.GetValues(typeof(Departamento))) 
            {
                Console.WriteLine($"{(int)dept}. {dept}");
            }
            valid = int.TryParse(Console.ReadLine(), out deptIndex);
            if (!valid) { Console.WriteLine($"El dato no es de tipo entero"); }
            else 
            {
                departamento =(Departamento)deptIndex;
            }
        } 
        while (!valid);

        var emp = new Empleado(id, nombre, edad, departamento);
        Empleados.Add(id, emp);
        GuardarEmpleado(emp);
        Console.WriteLine($"Empleado Agregado!");
    }
    static public void ActualizarEmpleado() 
    {
        Console.Write($"Ingrese el id del empleado a modificar: ");
        var id = int.Parse(Console.ReadLine());
        if (Empleados.ContainsKey(id))
        {
            Empleado emp = Empleados[id];   
            Console.WriteLine($"(Presione 'enter' para omitir");
            Console.Write($"Ingrese el nombre a modificar: "); 
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) 
            {
                emp.Nombre = nombre;
            }

            Console.Write($"Ingrese la edad a modificar: ");
            var edad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(edad))
            {
                emp.Edad = int.Parse(edad);
            }

            Console.WriteLine($"Seleccione el nuevo departamento: ");
            foreach (var dept in Enum.GetValues(typeof(Departamento)))
            {
                Console.WriteLine($"{(int)dept}. {dept}");
            }
            var deptIndex = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(deptIndex))
            {
                emp.Departamento = (Departamento)int.Parse((string)deptIndex);
            }
            Console.WriteLine($"Empleado modificado! ");
            GuardarDatos();
        }
        else 
        {
            Console.WriteLine($"Empleado no encontrado ");
        }
    }
    static public void EliminarEmpleado() 
    {
        Console.Write($"Ingrese el ID del empleado a eliminar: ");
        var id = int.Parse(Console.ReadLine());

        if (Empleados.Remove(id))
        {
            Console.WriteLine($"Empleado eliminado");
            GuardarDatos();
        }
        else
        {
            Console.WriteLine($"Empleado no encontrado");
        }

        /* ⬆️⬆️es esto pero como Remove(id) devuelve tru or false puedo usarlo como sentencia en el if⬆️⬆️
        if (Empleados.ContainsKey(id))
        {
            Empleados.Remove(id);
        Console.WriteLine($"Empleado eliminado");
        }
        else 
        {
            Console.WriteLine($"Empleado no encontrado");
        }
        */
    }
    static void GuardarEmpleado(Empleado emp) /*no necesita ser public pq se llama a la funcin dentro de la clase estática, no en el main*/
    {
        using StreamWriter writer = new StreamWriter(ArchivoEmpleados,true);
        writer.WriteLine(emp);
    }
    static void GuardarDatos() 
    {
        using StreamWriter writer = new StreamWriter(ArchivoEmpleados);
        foreach (var emp in Empleados.Values) 
        {
            writer.WriteLine(emp);
        }
    }
    static public void CargarDatos() 
    {
        if (File.Exists(ArchivoEmpleados)) 
        {
            foreach (var linea in File.ReadAllLines(ArchivoEmpleados)) 
            {
                string[] partes = linea.Split(", ");  
                int id = int.Parse(partes[0]);
                string nombre = partes[1];
                int edad = int.Parse(partes[2]);
                /*pasar un enum string a un enum enum*/
                Departamento departamento = (Departamento)Enum.Parse(typeof(Departamento), partes[3]);

                Empleado emp = new Empleado(id, nombre, edad, departamento);
                Empleados.Add(id,emp);
            }
            /*
            using StreamReader reader = new StreamReader(ArchivoEmpleados);
            */
            Console.WriteLine($"Empleados cargados con exito! ");
            Console.WriteLine($"\n");
        }
    }
}
class Program 
{
    static void Main()
    {
        SysEmpleado.CargarDatos();
        int opcion;
        do
        {
            Console.WriteLine($"---------------------------------");
            Console.WriteLine($"Menu: ");
            Console.WriteLine($"1) Agregar un nuevo empleado.");
            Console.WriteLine($"2) Eliminar empleado. ");
            Console.WriteLine($"3) Modificar empleado. ");
            Console.WriteLine($"4) Mostrar empleados.");
            Console.WriteLine($"5) Guardar y salir.");
            Console.Write($"opcion: ");
            opcion = int.Parse( Console.ReadLine() );
            Console.WriteLine($"---------------------------------");
            Console.WriteLine($"\n");

            switch (opcion) 
            {
                case 1:
                    SysEmpleado.AgregarEmpleado();
                    Console.WriteLine($"\n");
                    break;
                case 2:
                    SysEmpleado.EliminarEmpleado();
                    Console.WriteLine($"\n");
                    break;
                case 3:
                    SysEmpleado.ActualizarEmpleado();
                    Console.WriteLine($"\n");
                    break;
                case 4:
                    SysEmpleado.MostrarEmpleados();
                    Console.WriteLine($"\n");
                    break;
            }
        }
        while (opcion != 5);
    }
}