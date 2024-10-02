/*  Un editor de textos quiere implementar una funcionalidad para contar la frecuencia de las palabras en un artículo.

El sistema debe:
1. Leer una cadena de texto y separar las palabras.
2. Contar cuántas veces aparece cada palabra.
3. Mostrar la lista de palabras junto con su frecuencia.  */
public static class Sistema 
{
    
}
class Program 
{
    static void Main()
    {
        Console.WriteLine("ingrese un texto:  ");
        string texto = Console.ReadLine();

        Dictionary<string, int> contadorPalabras = new Dictionary<string, int>();
        string[] palabras = texto.Split(' ');
        foreach (string palabra in palabras) 
        {
            if (contadorPalabras.ContainsKey(palabra))
            {
                contadorPalabras[palabra] += 1;
            }
            else
            {
                contadorPalabras.Add(palabra, 0);
            }
        }
        Console.WriteLine($"\n");
        Console.WriteLine($"Frecuencia de palabras: ");
        foreach (var entrada in contadorPalabras) 
        {
            Console.WriteLine($"{entrada.Key}: {entrada.Value}");
        }
    }
}
