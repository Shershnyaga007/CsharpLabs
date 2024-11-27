using System.Text;
using System.Text.RegularExpressions;

namespace Lab4;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Input string > ");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input string is empty.");
                continue;
            }

            Console.Write("Input regex > ");
            var filter = Console.ReadLine();
            
            while (true)
            {
                if (string.IsNullOrEmpty(filter))
                {
                    Console.WriteLine("Regex string is empty.");
                    
                    Console.Write("Input regex > ");
                    filter = Console.ReadLine();
                    continue;
                }
                
                break;
            }
            
            var words = input.Split(' ', '.', ',', ';', ':', '!', '?');
            
            Console.Write("Result: ");
            var result = new StringBuilder();
            foreach (var word in words)
            {
                if (Regex.IsMatch(word, filter, RegexOptions.IgnoreCase))
                {
                    result.Append(word + ", ");
                }
            }
            
            Console.WriteLine("Result: " + result);
        }
    }
}

