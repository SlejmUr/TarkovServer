using ServerLib.Json.Classes;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Controllers
{
    public class BotController
    {

        public static Character.Base GenerateDogtag(Character.Base bot)
        {
            Item.Base item = new();
            item.Id = AIDHelper.CreateNewID();
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



    }
}
