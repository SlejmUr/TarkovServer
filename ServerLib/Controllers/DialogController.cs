using ServerLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Controllers
{
    public class DialogController
    {
        public static List<object> Dialogs;
        public static List<object> DialogFileAge;
        public enum messageTypes 
        {
            npcTrader = 2,
            insuranceReturn = 8,
            questStart = 10,
            questFail = 11,
            questSuccess = 12,
        };

        public static void Init()
        {
            Dialogs = new();
            Dialogs.Clear();
            DialogFileAge = new();
            DialogFileAge.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[DIALOG]");
        }
        public static string GetDialoguePath(string sessionID)
        {
            return $"user/profiles/{sessionID}/dialogue.json";
        }
    }
}
