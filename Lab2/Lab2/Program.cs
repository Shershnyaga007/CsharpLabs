using System.Text.Json;

namespace Lab2;

public static class Program
{

    private static Dictionary<string, User> _usersDictionary = new();
    
    public static void Main()
    {
        LoadJson();

        while (true)
        {
            Console.WriteLine("1 - Create user");
            Console.WriteLine("2 - Login user");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out var option))
            {
                if (option != 1 && option != 2)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                    {
                        if (!HandleRegister())
                        {
                            Console.WriteLine("Invalid input.");
                        }

                        break;
                    }
                    case 2:
                    {
                        if (!HandleLogin())
                        {
                        
                        }

                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    private static bool HandleLogin()
    {
        Console.Write("Type login: ");
        var login = Console.ReadLine();

        if (string.IsNullOrEmpty(login) || login.Length < 3)
        {
            Console.WriteLine("Username must be at least 3 characters long.");
            return false;
        }
                    
        Console.Write("Type password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrEmpty(password) || password.Length < 4)
        {
            Console.WriteLine("Password must be at least 4 characters long.");
            return false;
        }

        if (!_usersDictionary.ContainsKey(login))
        {
            Console.WriteLine("Invalid login or password.");
            return true;
        }

        Console.WriteLine(_usersDictionary[login].CheckPassword(password)
            ? $"User {login} successfully logged in."
            : "Invalid login or password.");

        return true;
    }
    
    private static bool HandleRegister()
    {
        Console.Write("Type login: ");
        var login = Console.ReadLine();

        if (string.IsNullOrEmpty(login) || login.Length < 3)
        {
            Console.WriteLine("Username must be at least 3 characters long.");
            return false;
        }

        if (!_usersDictionary.ContainsKey(login))
        {
            Console.WriteLine($"User {login} already exists.");
            return true;
        }
        
        Console.Write("Type password: ");
        var password = Console.ReadLine();

        if (string.IsNullOrEmpty(password) || password.Length < 4)
        {
            Console.WriteLine("Password must be at least 4 characters long.");
            return false;
        }
        
        var user = new User(login, password);
        user.EncryptPassword();
        _usersDictionary.Add(login, user);
        SaveJson();
        
        Console.WriteLine($"User {login} successfully created.");
        
        return true;
    }
    
    private static void LoadJson()
    {
        var users = JsonUtil.ParseUsersFromJson("users.json");

        foreach (var user in users)
        {
            // Console.WriteLine($"{user.Name} > {user.EncodedPassword}");
            _usersDictionary[user.Name] = user;
        }
    }

    private static void SaveJson()
    {
        List<User> users = new();
        
        _usersDictionary.ToList().ForEach(user => users.Add(user.Value));
        
        JsonUtil.SerializeUsersToJson(users, "users.json");
    }
}

