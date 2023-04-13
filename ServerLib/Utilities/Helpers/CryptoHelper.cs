using System.Security.Cryptography;
using System.Text;

namespace ServerLib.Utilities.Helpers
{
    public static class CryptoHelper
    {
        public static string Hash(string _base)
        {
            using var sha1 = SHA1.Create();
            return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(_base)));
        }
    }
}
