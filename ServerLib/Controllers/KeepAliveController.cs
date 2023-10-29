namespace ServerLib.Controllers
{
    public class KeepAliveController
    {
        // Zero will give you when sent the first KeepAlive request.
        public static Dictionary<string, int> KeepAliveCounter = new();

        //you can add actions here to what you want to do if still in server
        public static List<Action<string>> KeepAiveActions = new();
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

            foreach (var action in KeepAiveActions)
            {
                action(SessionId);
            }
        }
        public static void DeleteKeepAlive(string SessionId)
        {
            KeepAliveCounter.Remove(SessionId);
        }

    }
}
