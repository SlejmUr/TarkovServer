using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class CharacterController 
    {
        public static List<Json.Character> Character;
        public static List<Json.Character> ScavCharacter;

        public static void Init()
        {
            Character = new();
            Character.Clear();
            ScavCharacter = new();
            ScavCharacter.Clear();
            Utils.PrintDebug("Initialization Done!", "debug", "[CHARACTER]");
        }

        public static string GetCompleteCharacter(string sessionID)
        {
            List<string> ouptut = new();

            if (!AccountController.IsWiped(sessionID))
            {
                //ouptut.Add(JsonConvert.SerializeObject(Character[sessionID].ToString()));
                //ouptut.Add(JsonConvert.SerializeObject(ScavCharacter[sessionID].ToString()));
            }

            return JsonConvert.SerializeObject(ouptut);
        }
    }
}
