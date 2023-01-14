using Newtonsoft.Json;
using ServerLib.Json;

namespace ServerLib.Controllers
{
    public class LocaleController
    {
        public static string GetLanguages()
        {
            return DatabaseController.DataBase.Locale.Languages;
        }
        public static string GetMenu(string lang, string url_lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            lang = url_lang;
            if (Account.Lang != lang)
            {
                Account.Lang = lang;
            }
            if (!DatabaseController.DataBase.Locale.Locales.TryGetValue(lang + "_locale", out var global))
            {
                return DatabaseController.DataBase.Locale.Locales["en_locale"];
            }
            return DatabaseController.DataBase.Locale.Locales[lang + "_menu"];
        }
        public static string GetLocale(string lang, string url_lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            lang = url_lang;
            if (Account.Lang != lang)
            {
                Account.Lang = lang;
            }
            if (!DatabaseController.DataBase.Locale.Locales.TryGetValue(lang + "_locale", out var global))
            {
                return DatabaseController.DataBase.Locale.Locales["en_locale"];
            }
            return DatabaseController.DataBase.Locale.Locales[lang + "_locale"];
        }
        public static string GetGlobal(string lang, string sessionId)
        {
            return GetLocale(lang, lang, sessionId);
        }

        public static string GetConfigLanguages()
        {
            var langs = DatabaseController.DataBase.Locale.Languages;
            Other.Lang lang = JsonConvert.DeserializeObject<Other.Lang>(langs);
            string output = "";
            foreach (var langpart in lang.data)
            {
                if (langpart.ShortName.Contains("ru"))
                {
                    output += $"\"{langpart.ShortName}\":\"{langpart.Name}\"";
                }
                else
                {
                    output += $"\"{langpart.ShortName}\":\"{langpart.Name}\",";
                }

            }
            return "{" + output + "}";
        }
    }
}
