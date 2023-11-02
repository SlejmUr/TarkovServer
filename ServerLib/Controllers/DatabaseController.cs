﻿using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Json.Helpers;
using ServerLib.Utilities;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ServerLib.Json.Classes.Database;
using static ServerLib.Json.Classes.LootBase;
using static ServerLib.Json.Converters;

namespace ServerLib.Controllers
{
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    public class DatabaseController
    {
        public static Database DataBase = new();
        public static void Init()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            if (!Directory.Exists("user/profiles")) { Directory.CreateDirectory("user/profiles"); }
            ConfigController.Init();
            List<Task> tasks = new()
            {
                Task.Run(LoadCharacters),
                Task.Run(LoadBots),
                Task.Run(LoadHideOut),
                Task.Run(LoadLocale),
                //Task.Run(LoadOthers),
                Task.Run(LoadLocations),
                Task.Run(LoadTraders),
                Task.Run(LoadWeater),
                Task.Run(LoadCustomConfig),
                                Task.Run(() =>
            {
                DataBase.Others = new()
                {
                    Templates = JsonConvert.DeserializeObject<Json.Classes.Handbook.Base>(File.ReadAllText("Files/others/handbook.json"))
                };

                foreach (var item in DataBase.Others.Templates.Items)
                {
                    DataBase.Others.ItemPrices.Add(item.Id, item.Price);
                }
                 Debug.PrintInfo($"Templates Taken {sw.ElapsedMilliseconds}ms");
            }),
                Task.Run(() =>
                {
                    
                    DataBase.Others.Items = JsonConvert.DeserializeObject<Dictionary<string, TemplateItem.Base>>(File.ReadAllText("Files/others/items.json"), new JsonConverter[]
                    {
                AimSensitivityConverter.Singleton,
                EffectsHealthUnionConverter.Singleton
                    });
                    
                     Debug.PrintInfo($"Items Taken {sw.ElapsedMilliseconds}ms");
                }),
                Task.Run(() =>
                {
                    DataBase.Others.Quests = File.ReadAllText("Files/others/quests.json");
                     Debug.PrintInfo($"Quests Taken {sw.ElapsedMilliseconds}ms");
                }),
                Task.Run(() =>
                {
                    DataBase.Others.Resupply = new();
                    if (File.Exists("Files/others/resupply.json"))
                    {
                        DataBase.Others.Resupply = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("Files/others/resupply.json"));
                    }
                     Debug.PrintInfo($"Resupply Taken {sw.ElapsedMilliseconds}ms");
                }),
                Task.Run(() =>
                {
                    DataBase.Others.Customization = JsonConvert.DeserializeObject<Dictionary<string, CustomizationItem.Base>>(File.ReadAllText("Files/others/customization.json"),
                    new JsonConverter[]
                    {
                CustomizationItemPrefabConverter.Singleton
                    });
                     Debug.PrintInfo($"Customization Taken {sw.ElapsedMilliseconds}ms");
                }),
                Task.Run(() =>
                {
                    DataBase.Loot = new()
                    {
                        staticAmmo = JsonConvert.DeserializeObject<Dictionary<string, List<StaticAmmoDetails>>>(File.ReadAllText("Files/loot/staticAmmo.json")),
                        staticContainers = JsonConvert.DeserializeObject<Dictionary<string, StaticContainerDetails>>(File.ReadAllText("Files/loot/staticContainers.json")),
                        staticLoot = JsonConvert.DeserializeObject<Dictionary<string, StaticLootDetails>>(File.ReadAllText("Files/loot/staticLoot.json"))
                    };
                     Debug.PrintInfo($"Loot Taken {sw.ElapsedMilliseconds}ms");
                })
            };
            Task.WhenAll(tasks.AsParallel().Select(task => task)).Wait();
            //Task.WhenAll(tasks).Wait();
            /*
            LoadCharacters();
            LoadBots();
            LoadHideOut();
            LoadLocale();
            LoadOthers();
            LoadLocations();
            LoadTraders();
            LoadWeater();
            LoadCustomConfig();
            */
            Debug.PrintInfo($"DatabaseController Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"DatabaseController Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintInfo("Initialization Done!", "DATABASE");
        }

        static void LoadOthers()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            List<Task> tasks = new()
            {

            };
            //Task.WhenAll(tasks.AsParallel().Select(task => task)).Wait();
            Task.WhenAll(tasks).Wait();
            Debug.PrintInfo($"LoadOthers Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"LoadOthers Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintDebug("Others loaded");
        }

        static void LoadCharacters()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            DataBase.Characters = new();
            DataBase.Characters.CharacterBase["bear"] = JsonHelper.ToCharacterBase("Files/characters/character_bear.json");
            DataBase.Characters.CharacterBase["usec"] = JsonHelper.ToCharacterBase("Files/characters/character_usec.json");
            DataBase.Characters.CharacterStorage = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("Files/characters/storage.json"));
            Debug.PrintInfo($"LoadCharacters Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"LoadCharacters Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintDebug("Characters loaded");
        }
        static void LoadBots()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            DataBase.Bot = new()
            {
                Base = File.ReadAllText("Files/bot/botBase.json"),
                Appearance = File.ReadAllText("Files/bot/appearance.json"),
                WeaponCache = File.ReadAllText("Files/bot/weaponcache.json"),
                Types = new()
            };
            var dirs = Directory.GetFiles("Files/bot/types");
            foreach (var item in dirs)
            {
                Task.Run(() => LoadBot(item));
            }
            Debug.PrintInfo($"LoadBots Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"LoadBots Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintDebug("Bots loaded");
        }

        static void LoadBot(string item)
        {
            var name = item.Replace("Files/bot/types\\", "").Replace(".json", "");
            Debug.PrintDebug(name);
            var botType = JsonConvert.DeserializeObject<Bots.BotType>(File.ReadAllText(item));
            if (botType == null)
                return;
            DataBase.Bot.Types.Add(name, botType);
        }

        static void LoadHideOut()
        {
            DataBase.Hideout = new()
            {
                Areas = File.ReadAllText("Files/hideout/areas.json"),
                Production = File.ReadAllText("Files/hideout/production.json"),
                Qte = File.ReadAllText("Files/hideout/qte.json"),
                Scavcase = File.ReadAllText("Files/hideout/scavcase.json"),
                Settings = File.ReadAllText("Files/hideout/settings.json")
            };
            Debug.PrintDebug("Hideout loaded");
        }
        static void LoadLocale()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            DataBase.Locale = new()
            {
                Languages = File.ReadAllText("Files/locales/languages.json")
            };
            //string stuff = "Files/locales";
            var dirs = Directory.GetDirectories("Files/locales");
            foreach (var dir in dirs)
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    Task.Run(() => LocaleBranch(dir, file));
                    /*
                    string localename = dir.Replace(stuff + "\\", "");
                    string localename_add = file.Replace(dir + "\\", "").Replace(".json", "");
                    DataBase.Locale.Locales.Add(localename + "_" + localename_add, File.ReadAllText(file));
                    if (localename_add != "menu")
                    {
                        var loc = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file));
                        if (loc == null)
                            continue;
                        DataBase.Locale.LocalesDict.Add(localename + "_" + localename_add, loc);
                    }
                    */
                }
            }
            Debug.PrintInfo($"LoadLocale Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"LoadLocale Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintDebug("Locales loaded");
        }

        static void LocaleBranch(string dir, string file)
        {
            string stuff = "Files/locales";
            string localename = dir.Replace(stuff + "\\", "");
            string localename_add = file.Replace(dir + "\\", "").Replace(".json", "");
            DataBase.Locale.Locales.Add(localename + "_" + localename_add, File.ReadAllText(file));
            if (localename_add != "menu")
            {
                var loc = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file));
                if (loc == null)
                    return;
                DataBase.Locale.LocalesDict.Add(localename + "_" + localename_add, loc);
            }
        }


        static void LoadLocations()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            Task.Run(() =>
            {
                DataBase.Location = new()
                {
                    Base = File.ReadAllText("Files/locations/base.json"),
                    AllLocations = File.ReadAllText("Files/locations/location_all.json")
                };
            });
            var dirs = Directory.GetDirectories("Files/locations");
            foreach (var dir in dirs)
            {
                Task.Run(() => LoadLocationFromDir(dir));
            }
            Debug.PrintInfo($"LoadLocations Taken {sw.Elapsed}ms");
            Debug.PrintInfo($"LoadLocations Taken {sw.ElapsedMilliseconds}ms");
            Debug.PrintDebug("Locations loaded");
        }

        static void LoadLocationFromDir(string dir)
        {
            var dirname = dir.Replace("Files/locations\\", "");
            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                Task.Run(() => LoadLocationFromFile(file, dirname));
               
            }
        }

        static void LoadLocationFromFile(string file, string dirname)
        {
            string filename = file.Replace("Files/locations\\" + dirname + "\\", "").Replace(".json", "");
            Debug.PrintDebug($"Location: {dirname + "_" + filename}", "LoadLocations");
            DataBase.Location.Locations.Add(dirname + "_" + filename, File.ReadAllText(file));
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
                    Task.Run(()=> TraderBranch(file, dirname));
                }
                DataBase.Trader.Traders.Add(dirname, trader);
                trader = new();
            }
            Debug.PrintDebug("Traders loaded");
        }

        static void TraderBranch(string file, string dirname)
        {
            Trader.Base trader = new();
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
                    trader.dialogue = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText(file));
                    break;
                case "questassort":
                    trader.questassort = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(File.ReadAllText(file));
                    break;
                case "suits":
                    trader.suits = JsonConvert.DeserializeObject<List<Trader.Suit>>(File.ReadAllText(file));
                    break;
            }
            DataBase.Trader.Traders.Add(dirname, trader);
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
#if false //Disabling here permanently because custom settings will be updated for future.
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
#endif
        }
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8601 // Possible null reference assignment.
}
