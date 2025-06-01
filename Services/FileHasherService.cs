using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace file_hasher_async.HasherController;

public class FileHasherService(Stream fileStream)
{
    public string Hash  = GetHash(fileStream);
    
    
    private static SHA256 _sha256Hash = SHA256.Create();
    private static string GetHash(Stream input)
    {
        // Convert the input to a byte array and compute the hash.
        byte[] data = _sha256Hash.ComputeHash(input);

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        var sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }
}