using System.Security.Cryptography;
using System.Text;

namespace Lab2;

public abstract class Crypto
{
    public static string Encrypt(string input)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));

        return bytes.Aggregate("", (current, t) => current + t.ToString("x2"));
    }
}