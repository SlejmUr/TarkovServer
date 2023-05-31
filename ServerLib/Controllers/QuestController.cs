using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;

namespace ServerLib.Controllers
{
    public class QuestController
    {
        static QuestController()
        {

            Quests = new();
            try
            {
                Quests = JsonConvert.DeserializeObject<Dictionary<string, Quest.Base>>(DatabaseController.DataBase.Others.Quests);
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }

            Debug.PrintInfo("Initialization Done!", "QuestController");
        }
        public static Dictionary<string, Quest.Base> Quests;

        public static List<Quest.Base> GetQuests()
        {
            try
            {
                List<Quest.Base> list = new();
                foreach (var item in Quests.Values)
                {
                    list.Add(item);
                }
                return list;
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
            }
            return null;
        }
    }
}
