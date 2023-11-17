﻿using JsonLib.Classes.ProfileRelated;
using JsonLib.Classes.Request;
using Newtonsoft.Json;

namespace JsonLib.Helpers
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

        public static Character.Base ToCharacterBaseAsString(this string json)
        {
            var ret = JsonConvert.DeserializeObject<Character.Base>(json, new JsonConverter[] { Converters.ItemLocationConverter.Singleton });
            ArgumentNullException.ThrowIfNull(ret);
            return ret;

        }
    }
}