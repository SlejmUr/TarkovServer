using ServerLib.Controllers;
using ServerLib.Json.Classes;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Generators
{
    internal class Scav
    {
        public static Character.Base Generate(string SessionId)
        {
            var type = DatabaseController.DataBase.Bot.Types["assault"];
            var scav = Bot.GeneratePlayerScav("assault", "easy", type);
            scav.Id = "scav" + SessionId;
            scav.Aid = AIDHelper.ToAID(SessionId);
            return scav;
        }
    }
}
