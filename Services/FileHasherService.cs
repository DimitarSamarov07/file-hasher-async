using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace file_hasher_async.HasherController;

public static class FileHasherService
{
    private static SHA256 _sha256Hash = SHA256.Create();
    public static async Task<string> GetHash(Stream input)
    {
        // Convert the input to a byte array and compute the hash.
        byte[] data = await _sha256Hash.ComputeHashAsync(input);

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