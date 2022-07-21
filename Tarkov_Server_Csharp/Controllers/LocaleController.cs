using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tarkov_Server_Csharp.Controllers
{
    public class LocaleController
    {
        public static Dictionary<string,string> LangDic = new();
        public static void Init()
        {
            string stuff = "Files/locales";
            var dirs = Directory.GetDirectories("Files/locales");
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string localename = dir.Replace(stuff + "\\", "");
                    string localename_add = file.Replace(dir + "\\", "").Replace(".json","");
                    LangDic.Add(localename + "_" + localename_add, File.ReadAllText(file));
                }
            }
        }
        public static string GetLanguages()
        {
            return File.ReadAllText("Files/locales/languages.json");
        }
        public static string GetMenu(string lang, string url_lang,string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            lang = url_lang;
            if (Account.Lang != lang)
            {
                Account.Lang = lang;
            }
            if (!LangDic.TryGetValue(lang + "_locale", out var global))
            {
                return LangDic["en_locale"];
            }
            return LangDic[lang + "_menu"];
        }
        public static string GetLocale(string lang, string url_lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            lang = url_lang;
            if (Account.Lang != lang)
            {
                Account.Lang = lang;
            }
            if (!LangDic.TryGetValue(lang + "_locale", out var global))
            {
                return LangDic["en_locale"];
            }
            return LangDic[lang + "_locale"];
        }
        public static string GetGlobal(string lang, string sessionId)
        {
            var Account = AccountController.FindAccount(sessionId);
            if (Account.Lang != lang)
            {
                Account.Lang = lang;
            }
            if (!LangDic.TryGetValue(lang + "_locale", out var global))
            {
                return LangDic["en_locale"];
            }
            return LangDic[lang + "_locale"];
        }
    }
}
