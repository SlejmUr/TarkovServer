using JsonLib.Classes.ProfileRelated;
using ServerLib.Controllers;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Generators
{
    public class Scav
    {
        public static Character.Base Generate(string SessionId, string ScavId)
        {
            var type = DatabaseController.DataBase.Bot.Types["assault"];
            var scav = Bot.GeneratePlayerScav("assault", "easy", type);
            scav.Id = ScavId;
            scav.Aid = AIDHelper.ToAID(SessionId);
            return scav;
        }
    }
}
