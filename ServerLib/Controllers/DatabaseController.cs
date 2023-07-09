using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class DatabaseController
    {
        public static Database DataBase = new();
        public static void Init()
        {
            ConfigController.Init();
            LoadCharacters();
            LoadBots();
            LoadItems();
            Debug.PrintInfo("Initialization Done!", "DATABASE");
        }

        static void LoadCharacters()
        {
            DataBase.Characters = new();
            DataBase.Characters.CharacterBase = new();
            DataBase.Characters.CharacterBase.TryAdd("bear", Character.Base.FromJson(File.ReadAllText("Files/characters/bear.json")));
            DataBase.Characters.CharacterBase.TryAdd("usec", Character.Base.FromJson(File.ReadAllText("Files/characters/usec.json")));
            DataBase.Characters.CharacterBase.TryAdd("scav", Character.Base.FromJson(File.ReadAllText("Files/characters/scav.json")));
            Debug.PrintDebug("Characters loaded");
        }
        static void LoadBots()
        {
            DataBase.Bot = new();
            DataBase.Bot.Base = Character.Base.FromJson(File.ReadAllText("Files/bot/botBase.json"));
            DataBase.Bot.Bosses = new();
            DataBase.Bot.Bosses.TryAdd("Bully", Character.Base.FromJson(File.ReadAllText("Files/bot/botBossBully.json")));
            DataBase.Bot.Bosses.TryAdd("Killa", Character.Base.FromJson(File.ReadAllText("Files/bot/botBossKilla.json")));
            DataBase.Bot.Names = JsonConvert.DeserializeObject<Bot.Names>(File.ReadAllText("Files/bot/botNames.json"));
            DataBase.Bot.Weapons = JsonConvert.DeserializeObject<Bot.Weapons[]>(File.ReadAllText("Files/bot/botWeapons.json"));
            DataBase.Bot.Settings = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText("Files/bot/botSettings.json"));
            Debug.PrintDebug("Bots loaded");
        }

        static void LoadItems()
        {
            DataBase.Items = new();
            DataBase.Items = JsonConvert.DeserializeObject<Dictionary<string, Item.Base>>(File.ReadAllText("Files/static/items.json"), Item.Converter.Settings);
            Debug.PrintDebug("Items loaded");
        }
    }
}
