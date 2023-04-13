using Newtonsoft.Json;
using ServerLib.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class BotController
    {

        public static Character.Base GenerateDogtag(Character.Base bot)
        {
            Item.Base item = new();
            item.Id = Utils.CreateNewID();
            item.Tpl = bot.Info.Side == "Usec" ? "59f32c3b86f77472a31742f0" : "59f32bb586f774757e1e8442";
            item.ParentId = bot.Inventory.Equipment;
            item.SlotId = "Dogtag";
            Item._Dogtag dogtag = new();
            dogtag.AccountId = bot.Aid.ToString();
            dogtag.ProfileId = bot.Id;
            dogtag.Nickname = bot.Info.Nickname;
            dogtag.Side = bot.Info.Side;
            dogtag.Level = bot.Info.Level;
            dogtag.Time = TimeHelper.GetTime();
            dogtag.Status = "Killed by ";
            dogtag.KillerAccountId = "Unknown";
            dogtag.KillerProfileId = "Unknown";
            dogtag.KillerName = "Unknown";
            dogtag.WeaponName = "Unknown";
            item.Upd.Dogtag = dogtag;
            bot.Inventory.Items.Add(item);
            return bot;
        }

        public static string GetBotDifficulty(string type, string difficulty)
        {
            switch (type)
            {
                case "core":
                    return DatabaseController.DataBase.Bot.Settings;
                default:
                    switch (difficulty)
                    {
                        case "custom":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Custom;
                        case "easy":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Easy;
                        case "hard":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Hard;
                        case "impossible":
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Impossible;
                        default:
                            return DatabaseController.DataBase.Bot.Bots[type].Difficulty.Normal;
                    }
            }
        }

        public static string GenerateBotName(string role)
        {
            return MathHelper.GetRandomArray(DatabaseController.DataBase.Bot.NamesDict[role].ToArray());
        }

        public static Character.Base GenerateNewID(Character.Base bot)
        {
            var ID = Utils.CreateNewID();
            bot.Id = ID;
            bot.Aid = ID;
            return bot;
        }

        public static List<Character.Base> GenerateBot(Bots.BotGeneration generate, string SessionId)
        {
            //DO botgen
            return new();
        }

        public static Character.Base GenerateInventory(Character.Base bot)
        {
            Dictionary<string, Item.Base> inventoryItemHash = new();
            Dictionary<string, Item.Base> itemsByParentHash = new();
            string InventoryID = "";


            foreach (var item in bot.Inventory.Items)
            {
                inventoryItemHash.Add(item.Id, item);

                if (item.Tpl == "55d7217a4bdc2d86028b456d")
                {
                    InventoryID = item.Id;
                    continue;
                }
                if (!string.IsNullOrEmpty(item.ParentId))
                {
                    continue;
                }

                if (!itemsByParentHash.ContainsKey(item.ParentId))
                {
                    itemsByParentHash.Add(item.ParentId, item);
                    continue;
                }
                itemsByParentHash.Add(item.ParentId, item);
            }
            string newID = Utils.CreateNewID();
            inventoryItemHash[InventoryID].Id = newID;
            bot.Inventory.Equipment = newID;

            if (itemsByParentHash.ContainsKey(InventoryID))
            {
                itemsByParentHash[InventoryID].ParentId = newID;
            }
            return bot;
        }
    }
}
