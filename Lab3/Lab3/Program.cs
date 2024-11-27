namespace Lab3;

public static class Program
{
    public static void Main()
    {
        var peoples = JsonUtil.ParsePersonsFromJson("lab3.json");

        foreach (var person in peoples.Where(person => person.FirstName.Equals("Vladimir")))
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"Id: {person.Id}");
            Console.WriteLine($"First Name: {person.FirstName}");
            Console.WriteLine($"Last Name: {person.LastName}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine($"Balance: {person.Balance}");
            Console.WriteLine("-----------------");
        }
    }
}

