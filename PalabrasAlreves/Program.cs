class Program 
{
    static void Main() 
    {
        Stack<char> Pila = new Stack<char>();

        Console.WriteLine($"Escriba la frase: ");
        string frase = Console.ReadLine();

        foreach (var cadaLetra in frase) 
        {
            Pila.Push( cadaLetra );
        }
        Console.WriteLine($"Frase invertida:  ");
        while (Pila.Count > 0) 
        {
            Console.Write(Pila.Pop());
        }
        

    }
}
