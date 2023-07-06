using System.Security.Cryptography;
using System.Text;

namespace ServerLib.Utilities.Helpers
{
    public static class CryptoHelper
    {
        public static string Hash(string _base)
        {
            var md5 = MD5.Create();
            byte[] array = md5.ComputeHash(Encoding.UTF8.GetBytes(_base));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
