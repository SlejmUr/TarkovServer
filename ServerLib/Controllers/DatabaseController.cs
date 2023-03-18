using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class DatabaseController
    {
        public static Dictionary<string, DateTime> FileAges;
        public static Database DataBase = new();
        public static void Init()
        {
            FileAges = new();
            FileAges.Clear();
            ConfigController.Init();
            LoadBasics();
            LoadCharacters();
            LoadBots();
            LoadHideOut();
            LoadLocale();
            LoadTemplates();
            LoadOthers();
            LoadLocations();
            LoadTraders();
            LoadWeater();
            LoadCustomConfig();
            Debug.PrintInfo("Initialization Done!", "[DATABASE]");
        }

        static void LoadBasics()
        {
            DataBase.Basic.Globals = File.ReadAllText("Files/base/globals.json");
            DataBase.Basic.BlacklistedIds = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("Files/base/blacklist.json"));
            Debug.PrintDebug("Basics loaded");
        }
        static void LoadTemplates()
        {
            DataBase.Templates.Items = JsonConvert.DeserializeObject<List<Templates.Items>>(File.ReadAllText("Files/templates/items.json"));
            DataBase.Templates.Categories = JsonConvert.DeserializeObject<List<Templates.Categories>>(File.ReadAllText("Files/templates/categories.json"));
            Debug.PrintDebug("Templates loaded");
        }

        static void LoadOthers()
        {
            foreach (var item in DataBase.Templates.Items)
            {
                DataBase.Others.ItemPrices.Add(item.Id, item.Price);
            }
            DataBase.Others.ChildlessList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("Files/others/childlessList.json"));
            DataBase.Others.Items = ItemBase.FromJson(File.ReadAllText("Files/others/items.json"));
            DataBase.Others.Quests = File.ReadAllText("Files/others/quests.json");
            if (File.Exists("Files/others/resupply.json"))
            {
                DataBase.Others.Resupply = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("Files/others/resupply.json"));
            }
            DataBase.Others.Resupply = new();
            DataBase.Others.Customization = new();
            dynamic customs = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("Files/others/customization.json"));
            foreach (var item in customs)
            {
                var customItem = item.ToString().Split(":")[0].Replace("\"", "");
                DataBase.Others.Customization.Add(customItem.ToString(), customs[customItem].ToString());
            }
            Debug.PrintDebug("Others loaded");
        }

        static void LoadCharacters()
        {
            DataBase.Characters.CharacterBase["bear"] = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/characters/character_bear.json"));
            DataBase.Characters.CharacterBase["usec"] = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/characters/character_usec.json"));
            DataBase.Characters.CharacterBase["scav"] = JsonConvert.DeserializeObject<Character.Base>(File.ReadAllText("Files/characters/playerScav.json"));
            DataBase.Characters.CharacterStorage = JsonConvert.DeserializeObject<CharacterOBJ.CharacterStorage>(File.ReadAllText("Files/characters/storage.json"));
            DataBase.Characters.DefaultCustomization = JsonConvert.DeserializeObject<CharacterOBJ.DefaultCustomization>(File.ReadAllText("Files/characters/defaultCustomization.json"));
            Debug.PrintDebug("Characters loaded");
        }
        static void LoadBots()
        {
            DataBase.Bot.Base = File.ReadAllText("Files/bot/botBase.json");
            DataBase.Bot.Appearance = File.ReadAllText("Files/bot/appearance.json");
            DataBase.Bot.Settings = File.ReadAllText("Files/bot/botSettings.json");
            DataBase.Bot.Names = JsonConvert.DeserializeObject<Bots.BotNames>(File.ReadAllText("Files/bot/names.json"));
            DataBase.Bot.WeaponCache = File.ReadAllText("Files/bot/weaponcache.json");
            Database.bot.bots bots = new();
            Database.bot.bots.difficulty difficulty = new();
            string stuff = "Files/bot/bots";
            var dirs = Directory.GetDirectories("Files/bot/bots");
            foreach (var dir in dirs)
            {
                string botname = dir.Replace(stuff + "\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string bot_test = file.Replace(dir + "\\", "").Replace(".json", "");
                    switch (bot_test)
                    {
                        case "loadout":
                            bots.Loadout = File.ReadAllText(file);
                            break;
                        case "health":
                            bots.Health = File.ReadAllText(file);
                            break;
                    }
                }
                var dir2 = Directory.GetDirectories(dir);
                foreach (var dir1 in dir2)
                {
                    var files2 = Directory.GetFiles(dir1);
                    foreach (var file1 in files2)
                    {
                        string bot_test = file1.Replace(dir1 + "\\", "").Replace(".json", "");
                        string normalfile = file1.Replace("\\", "/");
                        if (dir1.Contains("difficulties"))
                        {
                            switch (bot_test)
                            {
                                case "easy":
                                    difficulty.Easy = File.ReadAllText(normalfile);
                                    break;
                                case "normal":
                                    difficulty.Normal = File.ReadAllText(normalfile);
                                    break;
                                case "hard":
                                    difficulty.Hard = File.ReadAllText(normalfile);
                                    break;
                                case "impossible":
                                    difficulty.Impossible = File.ReadAllText(normalfile);
                                    break;
                                default:
                                    difficulty.Custom = File.ReadAllText(normalfile);
                                    break;
                            }
                        }
                    }
                }
                bots.Difficulty = difficulty;
                DataBase.Bot.Bots.Add(botname, bots);
                bots = new();
            }

            DataBase.Bot.NamesDict.Add("BossBully", DataBase.Bot.Names.BossBully);
            DataBase.Bot.NamesDict.Add("BossGluhar", DataBase.Bot.Names.BossGluhar);
            DataBase.Bot.NamesDict.Add("BossKilla", DataBase.Bot.Names.BossKilla);
            DataBase.Bot.NamesDict.Add("BossKnight", DataBase.Bot.Names.BossKnight);
            DataBase.Bot.NamesDict.Add("BossKojaniy", DataBase.Bot.Names.BossKojaniy);
            DataBase.Bot.NamesDict.Add("BossSanitar", DataBase.Bot.Names.BossSanitar);
            DataBase.Bot.NamesDict.Add("BossTagilla", DataBase.Bot.Names.BossTagilla);
            DataBase.Bot.NamesDict.Add("BossZryachiy", DataBase.Bot.Names.BossZryachiy);
            DataBase.Bot.NamesDict.Add("FollowerBigPipe", DataBase.Bot.Names.FollowerBigPipe);
            DataBase.Bot.NamesDict.Add("FollowerBirdEye", DataBase.Bot.Names.FollowerBirdEye);
            DataBase.Bot.NamesDict.Add("FollowerBully", DataBase.Bot.Names.FollowerBully);
            DataBase.Bot.NamesDict.Add("FollowerKojaniy", DataBase.Bot.Names.FollowerKojaniy);
            DataBase.Bot.NamesDict.Add("FollowerSanitar", DataBase.Bot.Names.FollowerSanitar);
            DataBase.Bot.NamesDict.Add("FollowerTagilla", DataBase.Bot.Names.FollowerTagilla);
            DataBase.Bot.NamesDict.Add("FollowerZryachiy", DataBase.Bot.Names.FollowerZryachiy);
            DataBase.Bot.NamesDict.Add("GeneralFollower", DataBase.Bot.Names.GeneralFollower);
            DataBase.Bot.NamesDict.Add("Gifter", DataBase.Bot.Names.Gifter);
            DataBase.Bot.NamesDict.Add("Normal", DataBase.Bot.Names.Normal);
            DataBase.Bot.NamesDict.Add("Scav", DataBase.Bot.Names.Scav);
            DataBase.Bot.NamesDict.Add("Sectantpriest", DataBase.Bot.Names.Sectantpriest);
            DataBase.Bot.NamesDict.Add("Sectantwarrior", DataBase.Bot.Names.Sectantwarrior);

            Debug.PrintDebug("Bots loaded");
        }
        static void LoadHideOut()
        {
            DataBase.Hideout = new();
            Database.hideout hideout = new();
            hideout.Areas = File.ReadAllText("Files/hideout/areas.json");
            hideout.Production = File.ReadAllText("Files/hideout/productions.json");
            hideout.Qte = File.ReadAllText("Files/hideout/qte.json");
            hideout.Scavcase = File.ReadAllText("Files/hideout/scavcase.json");
            hideout.Settings = File.ReadAllText("Files/hideout/settings.json");
            DataBase.Hideout = hideout;
            Debug.PrintDebug("Hideout loaded");
        }
        static void LoadLocale()
        {
            DataBase.Locale.Languages = File.ReadAllText("Files/locales/languages.json");
            DataBase.Locale.Extras = File.ReadAllText("Files/locales/extras.json");
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
            DataBase.Location.AllLocations = File.ReadAllText("Files/locations/all_locations.json");
            var dirs = Directory.GetDirectories("Files/locations");
            foreach (var dir in dirs)
            {
                var dirname = dir.Replace("Files/locations\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string filename = file.Replace("Files/locations\\" + dirname + "\\", "").Replace(".json", "");
                    DataBase.Location.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
                }
            }
            Debug.PrintDebug("Locations loaded");
        }
        static void LoadTraders()
        {
            DataBase.Trader.LiveFlea = File.ReadAllText("Files/traders/liveflea.json");
            Database.trader.traders traders = new();
            var dirs = Directory.GetDirectories("Files/traders");
            foreach (var dir in dirs)
            {
                var dirname = dir.Replace("Files/traders\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string filename = file.Replace("Files/traders\\" + dirname + "\\", "").Replace(".json", "");
                    //DataBase.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
                    switch (filename)
                    {
                        default:
                            break;
                        case "assort":
                            traders.Assort = JsonConvert.DeserializeObject<Database.trader.traders.assort>(File.ReadAllText(file));
                            break;
                        case "base":
                            traders.Base = JsonConvert.DeserializeObject<Traders.Base>(File.ReadAllText(file));
                            break;
                        case "categories":
                            if (!dirname.Contains("ragfair"))
                            {
                                traders.Categories = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(file));
                            }
                            else
                            {
                                traders.RagfairCategories = File.ReadAllText(file);
                            }
                            break;
                        case "dialogue":
                            traders.Dialog = JsonConvert.DeserializeObject<Traders.Dialog>(File.ReadAllText(file));
                            break;
                        case "questassort":
                            traders.QuestAssort = File.ReadAllText(file);
                            break;
                        case "suits":
                            traders.Suits = JsonConvert.DeserializeObject<List<TraderSuits>>(File.ReadAllText(file));
                            break;
                    }
                    DataBase.Trader.Traders.Add(filename + "_" + dirname, traders);
                }
                traders = new();
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
