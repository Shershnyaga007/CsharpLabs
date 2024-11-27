using System.Text;
using System.Text.Json;

namespace Lab2
{
    public abstract class JsonUtil
    {
        public static List<User> ParseUsersFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (var fs = File.Create(filePath))
                {
                    fs.Write(new UTF8Encoding(true).GetBytes("[{}]"));
                    fs.Close();
                }
                return new List<User>();
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var users = JsonSerializer.Deserialize<List<User>>(fileStream);
            fileStream.Close();
            return users ?? new List<User>();
        }

        public static void SerializeUsersToJson(List<User> users, string filePath)
        {
            var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            fileStream.Write(JsonSerializer.SerializeToUtf8Bytes(users));
            fileStream.Close();
        }
    }
}