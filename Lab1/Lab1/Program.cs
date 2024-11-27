namespace Lab1;

public static class Program
{
    public static void Main()
    {
        var rnd = new Random();

        var array = new int[10];
        for (var i = 0; i < 10; i++)
        {
            array[i] = rnd.Next(0, 100);
        }
        
        Console.WriteLine("Non sorted: " + string.Join(", ", array));
        Console.WriteLine("Sorted: " + string.Join(", ", Sorter.Sort(array)));
    }
}
