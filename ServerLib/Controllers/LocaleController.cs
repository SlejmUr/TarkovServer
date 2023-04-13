using Newtonsoft.Json;
using ServerLib.Json.Classes;

namespace ServerLib.Controllers
{
    public class LocaleController
    {
        public static string GetLanguages()
        {
            return DatabaseController.DataBase.Locale.Languages;
        }

        public static Dictionary<string, string> GetDictLanguages()
        {
            return JsonConvert.DeserializeObject<Dictionary<string,string>>(DatabaseController.DataBase.Locale.Languages);
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

        public static string GetQuestLocales(string lang, string questId)
        {
            var localeDict = DatabaseController.DataBase.Locale.LocalesDict[lang + "_locale"];
            RepeatableQuests.SampleQuests questBase = new()
            {
                name = localeDict[$"{questId} name"],
                description = localeDict[$"{questId} description"],
                failMessageText = localeDict[$"{questId} failMessageText"],
                successMessageText = localeDict[$"{questId} successMessageText"]
            };
            return JsonConvert.SerializeObject(questBase);
        }


    }
}
