using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class KeepAliveController
    {
        public static void Main(string sessionID)
        {
            if (!AccountController.IsWiped(sessionID))
            {
                //UpdateTraders(sessionID);
                //UpdatePlayerHideout(sessionID);
            }
        }

    }
}
