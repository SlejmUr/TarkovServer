using ServerLib.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerLib.Json;

namespace ServerLib.Controllers
{
    public class DatabaseController
    {
        public static Database DataBase = new();
        public static void Init()
        {
            ConfigController.Init();
            LoadCore();
            LoadBasics();
            LoadBots();
            LoadHideOut();
            LoadQuests();
            LoadCustomization();
            LoadLocale();
            Utils.PrintDebug("LoadLocations");
            Utils.PrintDebug("LoadTraders");
            Utils.PrintDebug("LoadFleaMarket");
            LoadWeater();
            LoadCustomConfig();
            Utils.PrintDebug("Initialization Done!", "debug", "[DATABASE]");
        }

        static void LoadCore()
        {
            DataBase.Core = new();
            DataBase.Core.BotBase = File.ReadAllText("Files/base/botBase.json");
            DataBase.Core.BotCore = File.ReadAllText("Files/base/botCore.json");
            DataBase.Core.FleaOffer = File.ReadAllText("Files/base/fleaOffer.json");
            DataBase.Core.MatchMetrics = File.ReadAllText("Files/base/matchMetrics.json");
            Utils.PrintDebug("Core Data loaded");
        }
        static void LoadBasics()
        {
            DataBase.Server = JsonConvert.DeserializeObject<ServerConfig.Base>(File.ReadAllText("Files/configs/server_base.json"));
            DataBase.Globals = File.ReadAllText("Files/base/globals.json");
            DataBase.Gameplay = JsonConvert.DeserializeObject<GameplayConfig.Base>(File.ReadAllText("Files/configs/gameplay_base.json"));
            DataBase.Items = ItemBase.FromJson(File.ReadAllText("Files/items/items.json"));
            DataBase.Languages = File.ReadAllText("Files/locales/languages.json");
            DataBase.Quests = File.ReadAllText("Files/quests/quests.json");
            Utils.PrintDebug("Basics loaded");
        }
        static void LoadBots()
        {
            DataBase.Bots = new();
            Database.bots bots = new();
            Database.bots.difficulty difficulty = new();
            string stuff = "Files/bots";
            var dirs = Directory.GetDirectories("Files/bots");
            foreach (var dir in dirs)
            {
                string botname = dir.Replace(stuff + "\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string bot_test = file.Replace(dir + "\\", "").Replace(".json", "");
                    switch (bot_test)
                    {
                        case "appearance":
                            bots.Appearance = File.ReadAllText(file);
                            break;
                        case "chances":
                            bots.Chances = File.ReadAllText(file);
                            break;
                        case "experience":
                            bots.Experience = File.ReadAllText(file);
                            break;
                        case "generation":
                            bots.Generation = File.ReadAllText(file);
                            break;
                        case "health":
                            bots.Health = File.ReadAllText(file);
                            break;
                        case "inventory":
                            bots.Inventory = File.ReadAllText(file);
                            break;
                        case "names":
                            bots.BotNames = File.ReadAllText(file);
                            break;
                        case "skills":
                            //Do nothing
                            break;
                    }
                    //Console.WriteLine(bot_test);
                }
                var dir2 = Directory.GetDirectories(dir);
                foreach (var dir1 in dir2)
                {
                    var files2 = Directory.GetFiles(dir1);
                    foreach (var file1 in files2)
                    {
                        string bot_test = file1.Replace(dir1 + "\\", "").Replace(".json", "");
                        string normalfile = file1.Replace("\\","/");
                        if (dir1.Contains("profile"))
                        {
                            //do profile things
                            Console.WriteLine("Profile detected! This hasnt been handled fully YET!");
                        }
                        else if (dir1.Contains("difficulty"))
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
                        else //inventory
                        { 
                            bots.Inventory_dict.Add(bot_test, File.ReadAllText(normalfile));
                        }
                    }
                }
                bots.Difficulty = difficulty;
                DataBase.Bots.Add(botname, bots);
                bots = new();
            }
            Utils.PrintDebug("Bots loaded");
        }
        static void LoadHideOut()
        {
            DataBase.Hideout = new();
            Database.hideout hideout = new();
            hideout.Settings = File.ReadAllText("Files/hideout/settings.json");
            hideout.Areas = File.ReadAllText("Files/hideout/areas/_items.json");
            var prod_files = Directory.GetFiles("Files/hideout/production");
            foreach (var file in prod_files)
            {
                string name = file.Replace("Files/hideout/production\\", "");
                DataBase.Hideout.Production.Add(name, File.ReadAllText(file));
            }
            var scav_files = Directory.GetFiles("Files/hideout/scavcase");
            foreach (var file in scav_files)
            {
                string name = file.Replace("Files/hideout/scavcase\\", "");
                DataBase.Hideout.Scavcase.Add(name, File.ReadAllText(file));
            }
            DataBase.Hideout = hideout;
            Utils.PrintDebug("Hideout loaded");
        }
        static void LoadQuests()
        {
            //Soon AKI quest Handle
            Utils.PrintDebug("AKI quests loaded");
        }
        static void LoadCustomization()
        { 
            DataBase.Customization = new();
            dynamic customs = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("Files/customization/items.json"));
            foreach (var item in customs)
            {
                var fsf = item.ToString().Split(":")[0].Replace("\"","");
                DataBase.Customization.Add(fsf.ToString(), customs[fsf].ToString());
            }
            Utils.PrintDebug("Customization loaded");
        }
        static void LoadLocale()
        {
            DataBase.Locales = new();
            string stuff = "Files/locales";
            var dirs = Directory.GetDirectories("Files/locales");
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string localename = dir.Replace(stuff + "\\", "");
                    string localename_add = file.Replace(dir + "\\", "").Replace(".json", "");
                    DataBase.Locales.Add(localename + "_" + localename_add, File.ReadAllText(file));
                }
            }
            Utils.PrintDebug("Locales loaded");
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
            Utils.PrintDebug("Weather loaded");
        }
        static void LoadCustomConfig()
        {
            DataBase.CustomSettings = JsonConvert.DeserializeObject<CustomConfig.Base>(File.ReadAllText("Files/configs/customsettings.json"));
            if (DataBase.CustomSettings.Locale.UseCustomLocale)
            {
                var from = DataBase.CustomSettings.Locale.CustomLocale.FromReplace;
                var to = DataBase.CustomSettings.Locale.CustomLocale.ToReplace;
                int counter = 0;
                foreach (string fromstep in from)
                {
                    if (from.Count < counter) break;
                    var LocaleString = DataBase.Locales[DataBase.CustomSettings.Locale.BaseReplace + "_locale"];
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
                    string ser_locale = JsonConvert.SerializeObject(locale, Formatting.Indented);
                    DataBase.Locales[DataBase.CustomSettings.Locale.BaseReplace + "_locale"] = ser_locale.Replace("Interface", "interface");
                    counter++;
                }
            }
            if (DataBase.CustomSettings.Locale.UseCustomMenu)
            {
                var from = DataBase.CustomSettings.Locale.CustomMenu.FromReplace;
                var to = DataBase.CustomSettings.Locale.CustomMenu.ToReplace;
                int counter = 0;
                foreach (string fromstep in from)
                {
                    if (from.Count < counter) break;
                    var LocaleString = DataBase.Locales[DataBase.CustomSettings.Locale.BaseReplace + "_menu"];
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
                    DataBase.Locales[DataBase.CustomSettings.Locale.BaseReplace + "_menu"] = JsonConvert.SerializeObject(locale, Formatting.Indented);
                    counter++;
                }
            }
        }
    }
}
