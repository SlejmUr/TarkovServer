namespace ServerLib.Controllers
{
    public class KeepAliveController
    {
        // Zero will give you when sent the first KeepAlive request.
        public static Dictionary<string, int> KeepAliveCounter = new();
        public static void Main(string SessionId)
        {
            if (KeepAliveCounter.ContainsKey(SessionId))
            {
                KeepAliveCounter[SessionId] += 1;
            }
            else
            {
                KeepAliveCounter.Add(SessionId, 0);
            }


            if (!AccountController.IsWiped(SessionId))
            {
                //UpdateTraders(SessionId);
                //UpdatePlayerHideout(SessionId);
            }
        }
        public static void DeleteKeepAlive(string SessionId)
        {
            KeepAliveCounter.Remove(SessionId);
        }

    }
}
