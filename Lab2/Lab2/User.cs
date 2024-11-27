using System.Text.Json.Serialization;

namespace Lab2;

public class User
{
    [JsonInclude]
    public string Name { get; private set; }
    
    [JsonInclude]
    public string EncodedPassword { get; private set; }
    

    [JsonConstructor]
    public User(string name, string encodedPassword)
    {
        Name = name;
        EncodedPassword = encodedPassword;
    }

    public void EncryptPassword()
    {
        EncodedPassword = Crypto.Encrypt(EncodedPassword);
    }
    
    public bool CheckPassword(string password)
    {
        return Crypto.Encrypt(password).Equals(EncodedPassword);
    }
}