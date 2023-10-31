using Newtonsoft.Json;
using ServerLib.Json.Classes;

namespace ServerLib.Json.Helpers
{
    public static class JsonHelper
    {
        public static Login ToLogin(Profile.Info info)
        {
            return new()
            {
                password = info.Password,
                username = info.Username
            };
        }
        public static Profile.Info FromLogin(Login login)
        {
            return new()
            {
                Username = login.username,
                Password = login.password
            };
        }

        public static string FromCharacterBase(this Character.Base? @base)
        {
            ArgumentNullException.ThrowIfNull(@base);
            return JsonConvert.SerializeObject(@base, new JsonConverter[] { Converters.ItemLocationConverter.Singleton });
        }

        public static Character.Base ToCharacterBase(this string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(file);
            var ret = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText(file), new JsonConverter[] { Converters.ItemLocationConverter.Singleton });
            ArgumentNullException.ThrowIfNull(ret);
            return ret;

        }
    }
}
