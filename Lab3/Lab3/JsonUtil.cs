using System.Text.Json;

namespace Lab3;

public static class JsonUtil
{
    public static List<Person> ParsePersonsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            using (var fs = File.Create(filePath))
            {
                fs.Close();
            }
            return new List<Person>();
        }

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var customers = JsonSerializer.Deserialize<List<Person>>(fileStream);
        return customers ?? new List<Person>();
    }
}