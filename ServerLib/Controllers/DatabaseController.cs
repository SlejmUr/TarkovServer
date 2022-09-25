using ServerLib.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerLib.Json;
using System.Text;

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
            LoadCore();
            LoadBasics();
            LoadBots();
            LoadHideOut();
            LoadQuests();
            LoadCustomization();
            LoadLocale();
            LoadTemplates();
            LoadLocations();
            LoadTraders();
            Utils.PrintDebug("LoadFleaMarket / Ragfair");
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
            DataBase.Globals = File.ReadAllText("Files/base/globals.json");
            DataBase.Items = ItemBase.FromJson(File.ReadAllText("Files/items/items.json"));
            DataBase.Languages = File.ReadAllText("Files/locales/languages.json");
            DataBase.Quests = File.ReadAllText("Files/quests/quests.json");
            Utils.PrintDebug("Basics loaded");
        }
        static void LoadTemplates()
        {
            DataBase.Templates.Items = JsonConvert.DeserializeObject<List<Templates.Items>>(File.ReadAllText("Files/templates/items.json"));
            DataBase.Templates.Categories = JsonConvert.DeserializeObject<List<Templates.Categories>>(File.ReadAllText("Files/templates/categories.json"));
            foreach (var item in DataBase.Templates.Items)
            {
                DataBase.ItemPrices.Add(item.Id,item.Price);
            }
            Utils.PrintDebug("Templates loaded");
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
                            bots.Profile = File.ReadAllText(normalfile);
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
        static void LoadLocations()
        {
            DataBase.AllLocations = File.ReadAllText("Files/locations/all_locations.json");
            var dirs = Directory.GetDirectories("Files/locations");
            foreach (var dir in dirs)
            {
                var dirname = dir.Replace("Files/locations\\", "");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    string filename = file.Replace("Files/locations\\" + dirname + "\\", "").Replace(".json", "");
                    DataBase.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
                }
            }
            Utils.PrintDebug("Locations loaded");
        }
        static void LoadTraders()
        {
            DataBase.Traders = new();
            Database.traders traders = new();
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
                            traders.Assort = JsonConvert.DeserializeObject<Database.traders.assort>(File.ReadAllText(file));
                            break;
                        case "base":
                            traders.Base = File.ReadAllText(file);
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
                            traders.Suits = JsonConvert.DeserializeObject<List<Traders.Suits>>(File.ReadAllText(file));
                            break;
                    }
                    DataBase.Traders.Add(filename + "_" + dirname, traders);
                    traders = new();
                }
            }
            Utils.PrintDebug("Traders loaded");
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
            var Custom = ConfigController.Configs.CustomSettings;
            if (Custom.Locale.UseCustomLocale)
            {
                var from = Custom.Locale.CustomLocale.FromReplace;
                var to = Custom.Locale.CustomLocale.ToReplace;
                int counter = 0;
                foreach (string fromstep in from)
                {
                    if (from.Count < counter) break;
                    var LocaleString = DataBase.Locales[Custom.Locale.BaseReplace + "_locale"];
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
                    DataBase.Locales[Custom.Locale.BaseReplace + "_locale"] = ser_locale.Replace("Interface", "interface");
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
                    var LocaleString = DataBase.Locales[Custom.Locale.BaseReplace + "_menu"];
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
                    DataBase.Locales[Custom.Locale.BaseReplace + "_menu"] = JsonConvert.SerializeObject(locale, Formatting.Indented);
                    counter++;
                }
            }
        }
    }
}
