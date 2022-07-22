using ServerLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Controllers
{
    public class DatabaseController
    {
        public static JsonD.Database DataBase = new();
        static void GetDatabase()
        {
            ConfigController.Init();
            LoadCoreData();
            LoadBasics();
        }

        static void LoadCoreData()
        {
            DataBase.Core = new();
            DataBase.Core.BotBase = File.ReadAllText("Files/base/botBase.json");
            DataBase.Core.BotCore = File.ReadAllText("Files/base/botCore.json");
            DataBase.Core.FleaOffer = File.ReadAllText("Files/base/fleaOffer.json");
            DataBase.Core.MatchMetrics = File.ReadAllText("Files/base/matchMetrics.json");
            Console.WriteLine("Core Data loaded");
        }
        static void LoadBasics()
        {
            DataBase.Globals = File.ReadAllText("Files/base/globals.json");
            DataBase.Gameplay = File.ReadAllText("Files/configs/gameplay_base.json");
            DataBase.Items = File.ReadAllText("Files/items/items.json");
            DataBase.Languages = File.ReadAllText("Files/locales/languages.json");
            Console.WriteLine("Basics loaded");
        }
        static void LoadBots()
        {
            DataBase.Bots = new();
            JsonD.Database.bots bots = new();


            DataBase.Bots.Add("", bots);

            Console.WriteLine("Bots loaded");
        }

    }
}
