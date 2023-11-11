using JsonLib.Classes.ProfileRelated;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Generators
{
    public class Scav
    {
        public static Character.Base Generate(string SessionId)
        {
            var type = DatabaseController.DataBase.Bot.Types["assault"];
            var scav = Bot.GeneratePlayerScav("assault", "easy", type);
            scav.Id = "scav" + SessionId;
            scav.Aid = AIDHelper.ToAID(SessionId) + 10;
            return scav;
        }
    }
}
