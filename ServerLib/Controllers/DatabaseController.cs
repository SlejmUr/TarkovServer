using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Json.Classes.LootBase;
using static ServerLib.Json.Converters;

namespace ServerLib.Controllers
{
    public class DatabaseController
    {
        public static Database DataBase = new();
        public static void Init()
        {
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }
            ConfigController.Init();
            LoadCharacters();
            LoadBots();
            LoadHideOut();
            LoadLocale();
            LoadOthers();
            LoadLocations();
            LoadTraders();
            LoadWeater();
            LoadCustomConfig();
            Debug.PrintInfo("Initialization Done!", "DATABASE");
        }

        static void LoadOthers()
        {
            DataBase.Others = new();
            DataBase.Others.Templates = new();
            DataBase.Others.Templates = JsonConvert.DeserializeObject<Json.Classes.Handbook.Base>(File.ReadAllText("Files/others/handbook.json"));
            foreach (var item in DataBase.Others.Templates.Items)
            {
                DataBase.Others.ItemPrices.Add(item.Id, item.Price);
            }
            DataBase.Others.Items = JsonConvert.DeserializeObject<Dictionary<string, TemplateItem.Base>>(File.ReadAllText("Files/others/items.json"), new JsonConverter[] 
            { 
                AimSensitivityConverter.Singleton,
                EffectsHealthUnionConverter.Singleton

            });
            DataBase.Others.Quests = File.ReadAllText("Files/others/quests.json");
            DataBase.Others.Resupply = new();
            if (File.Exists("Files/others/resupply.json"))
            {
                DataBase.Others.Resupply = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("Files/others/resupply.json"));
            }
            DataBase.Others.Customization = new();
            DataBase.Others.Customization = JsonConvert.DeserializeObject<Dictionary<string, CustomizationItem.Base>>(File.ReadAllText("Files/others/customization.json"),
            new JsonConverter[]
            {
                CustomizationItemPrefabConverter.Singleton
            });
            DataBase.Loot = new();
            DataBase.Loot.staticAmmo = JsonConvert.DeserializeObject<Dictionary<string, List<StaticAmmoDetails>>>(File.ReadAllText("Files/loot/staticAmmo.json"));
            DataBase.Loot.staticContainers = JsonConvert.DeserializeObject<Dictionary<string, StaticContainerDetails>>(File.ReadAllText("Files/loot/staticContainers.json"));
            DataBase.Loot.staticLoot = JsonConvert.DeserializeObject<Dictionary<string, StaticLootDetails>>(File.ReadAllText("Files/loot/staticLoot.json"));
            Debug.PrintDebug("Others loaded");
        }

        static void LoadCharacters()
        {
            DataBase.Characters = new();
            DataBase.Characters.CharacterBase["bear"] = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/characters/character_bear.json"));
            DataBase.Characters.CharacterBase["usec"] = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/characters/character_usec.json"));
            DataBase.Characters.CharacterStorage = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("Files/characters/storage.json"));
            Debug.PrintDebug("Characters loaded");
        }
        static void LoadBots()
        {
            DataBase.Bot = new();
            DataBase.Bot.Base = File.ReadAllText("Files/bot/botBase.json");
            DataBase.Bot.Appearance = File.ReadAllText("Files/bot/appearance.json");
            DataBase.Bot.WeaponCache = File.ReadAllText("Files/bot/weaponcache.json");
            DataBase.Bot.Types = new();
            var dirs = Directory.GetFiles("Files/bot/types");
            foreach (var item in dirs)
            {
                var name = item.Replace("Files/bot/types\\", "").Replace(".json","");
                Debug.PrintDebug(name);
                DataBase.Bot.Types.Add(name, JsonConvert.DeserializeObject<Bots.BotType>(File.ReadAllText(item)));
            }

            Debug.PrintDebug("Bots loaded");
        }
        static void LoadHideOut()
        {
            DataBase.Hideout = new();
            Database.hideout hideout = new();
            hideout.Areas = File.ReadAllText("Files/hideout/areas.json");
            hideout.Production = File.ReadAllText("Files/hideout/production.json");
            hideout.Qte = File.ReadAllText("Files/hideout/qte.json");
            hideout.Scavcase = File.ReadAllText("Files/hideout/scavcase.json");
            hideout.Settings = File.ReadAllText("Files/hideout/settings.json");
            DataBase.Hideout = hideout;
            Debug.PrintDebug("Hideout loaded");
        }
        static void LoadLocale()
        {
            DataBase.Locale = new();
            DataBase.Locale.Languages = File.ReadAllText("Files/locales/languages.json");
            string stuff = "Files/locales";
            var dirs = Directory.GetDirectories("Files/locales");
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string localename = dir.Replace(stuff + "\\", "");
                    string localename_add = file.Replace(dir + "\\", "").Replace(".json", "");
                    DataBase.Locale.Locales.Add(localename + "_" + localename_add, File.ReadAllText(file));
                    if (localename_add != "menu")
                        DataBase.Locale.LocalesDict.Add(localename + "_" + localename_add, JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file)));
                }
            }
            Debug.PrintDebug("Locales loaded");
        }
        static void LoadLocations()
        {
            DataBase.Location = new();
            DataBase.Location.Base = File.ReadAllText("Files/locations/base.json");
            var dirs = Directory.GetDirectories("Files/locations");
            foreach (var dir in dirs)
            {
                var dirname = dir.Replace("Files/locations\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string filename = file.Replace("Files/locations\\" + dirname + "\\", "").Replace(".json", "");
                    Debug.PrintDebug($"Location: {dirname + "_" + filename}", "LoadLocations");
                    DataBase.Location.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
                }
            }
            Debug.PrintDebug("Locations loaded");
        }
        static void LoadTraders()
        {
            DataBase.Trader = new();
            Trader.Base trader = new();
            var dirs = Directory.GetDirectories("Files/traders");
            foreach (var dir in dirs)
            {
                var dirname = dir.Replace("Files/traders\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string filename = file.Replace("Files/traders\\" + dirname + "\\", "").Replace(".json", "");
                    Debug.PrintDebug($"Trader: {dirname + "_" + filename}", "LoadTraders");
                    //DataBase.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
                    switch (filename)
                    {
                        default:
                            break;
                        case "assort":
                            trader.assort = JsonConvert.DeserializeObject<Trader.TraderAssort>(File.ReadAllText(file));
                            break;
                        case "base":
                            trader.traderbase = JsonConvert.DeserializeObject<Trader.TraderBase>(File.ReadAllText(file));
                            break;
                        case "dialogue":
                            trader.dialogue = JsonConvert.DeserializeObject<Dictionary<string,List<string>>>(File.ReadAllText(file));
                            break;
                        case "questassort":
                            trader.questassort = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string, string>>>(File.ReadAllText(file));
                            break;
                        case "suits":
                            trader.suits = JsonConvert.DeserializeObject<List<Trader.Suit>>(File.ReadAllText(file));
                            break;
                    }
                }
                DataBase.Trader.Traders.Add(dirname, trader);
                trader = new();
            }
            Debug.PrintDebug("Traders loaded");
        }
        static void LoadWeater()
        {
            DataBase.Weather = new();
            var files = Directory.GetFiles("Files/weather");
            foreach (var file in files)
            {
                string filename = file.Replace("Files/weather\\", "").Replace(".json", "");
                DataBase.Weather.Add(filename, File.ReadAllText(file));
            }
            Debug.PrintDebug("Weather loaded");
        }
        static void LoadCustomConfig()
        {
            var Custom = ConfigController.Configs.CustomSettings;
            if (Custom.Locale.UseCustomLocale)
            {
                var from = Custom.Locale.CustomLocale.FromReplace;
                var to = Custom.Locale.CustomLocale.ToReplace;
                int counter = 0;
                foreach (string fromstep in from)
                {
                    if (from.Count < counter) break;
                    var LocaleString = DataBase.Locale.Locales[Custom.Locale.BaseReplace + "_locale"];
                    LocaleString = LocaleString.Replace("interface", "Interface");
                    dynamic locale = JsonConvert.DeserializeObject<dynamic>(LocaleString);
                    if (locale == null) { return; }
                    foreach (var thing in locale.Interface)
                    {
                        var splitter = thing.ToString().Split(": ");
                        string first = splitter[0];
                        first = first.Replace("\"", "");
                        if (first == from[counter].ToString())
                        {
                            locale.Interface[first] = to?[counter];
                        }
                    }
                    string ser_locale = JsonConvert.SerializeObject(locale);
                    DataBase.Locale.Locales[Custom.Locale.BaseReplace + "_locale"] = ser_locale.Replace("Interface", "interface");
                    counter++;
                }
            }
            if (Custom.Locale.UseCustomMenu)
            {
                var from = Custom.Locale.CustomMenu.FromReplace;
                var to = Custom.Locale.CustomMenu.ToReplace;
                int counter = 0;
                foreach (string fromstep in from)
                {
                    if (from.Count < counter) break;
                    var LocaleString = DataBase.Locale.Locales[Custom.Locale.BaseReplace + "_menu"];
                    dynamic locale = JsonConvert.DeserializeObject<dynamic>(LocaleString);
                    if (locale == null) { return; }
                    foreach (var thing in locale.menu)
                    {
                        var splitter = thing.ToString().Split(": ");
                        string first = splitter[0];
                        first = first.Replace("\"", "");
                        if (first == from[counter].ToString())
                        {
                            locale.menu[first] = to?[counter];
                        }
                    }
                    DataBase.Locale.Locales[Custom.Locale.BaseReplace + "_menu"] = JsonConvert.SerializeObject(locale);
                    counter++;
                }
            }
        }
    }
}
