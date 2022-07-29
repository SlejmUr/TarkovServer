using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class KeepAliveController
    {
        // Zero will give you when sent the first KeepAlive request.
        public static Dictionary<string, int> KeepAliveCounter = new();
        public static void Main(string sessionID)
        {
            if (KeepAliveCounter.ContainsKey(sessionID))
            {
                KeepAliveCounter[sessionID] += 1;
            }
            else
            {
                KeepAliveCounter.Add(sessionID, 0);
            }


            if (!AccountController.IsWiped(sessionID))
            {
                //UpdateTraders(sessionID);
                //UpdatePlayerHideout(sessionID);
            }
        }

    }
}
