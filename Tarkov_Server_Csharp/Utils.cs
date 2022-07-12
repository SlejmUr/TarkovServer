using System.Security.Cryptography;
using System.Text;

namespace Tarkov_Server_Csharp
{
    internal class Utils
    {
        public static double UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return timeSpan.TotalSeconds;
        }

        public static string GetSessionID(Dictionary<string,string> HttpHeaders)
        {
            if (HttpHeaders.ContainsKey("Cookie"))
            {
                var Cookie = HttpHeaders["Cookie"];
                var SessionID = Cookie.Split("=")[1];
                return SessionID;
            }
            return null;
        }
        public static string ByteArrayToString(byte[] bytearray)
        {
            return BitConverter.ToString(bytearray).Replace("-", " ");
        }

        public static string ToBase64(byte[] bytearray)
        {
            return Convert.ToBase64String(bytearray);
        }
        public static string CreateNewProfileID()
        {
            Random rand = new Random();

            // Choosing the size of string
            // Using Next() string
            int stringlen = 24;
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number.
                randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                str = str + letter;
            }
            string md5_str = ConvertStringtoMD5(str);
            return "AID" + md5_str;
        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
