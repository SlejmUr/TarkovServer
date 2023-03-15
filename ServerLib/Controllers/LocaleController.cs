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
        public static string GetMenu(string url_lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            if (Account.Lang != url_lang)
            {
                Account.Lang = url_lang;
            }
            if (!DatabaseController.DataBase.Locale.Locales.TryGetValue(url_lang + "_menu", out var global))
            {
                return DatabaseController.DataBase.Locale.Locales["en_menu"];
            }
            return DatabaseController.DataBase.Locale.Locales[url_lang + "_menu"];
        }

        public static string GetLocale(string url_lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            if (Account.Lang != url_lang)
            {
                Account.Lang = url_lang;
            }
            if (!DatabaseController.DataBase.Locale.Locales.TryGetValue(url_lang + "_locale", out var global))
            {
                return DatabaseController.DataBase.Locale.Locales["en_locale"];
            }
            return DatabaseController.DataBase.Locale.Locales[url_lang + "_locale"];
        }

        public static string GetConfigLanguages()
        {
            var langs = DatabaseController.DataBase.Locale.Languages;
            Json.Other.Lang lang = JsonConvert.DeserializeObject<Json.Other.Lang>(langs);
            return lang.data.ToString().Replace("\r\n", "").Replace("\\", "").Replace(" ", "");
        }
    }
}
