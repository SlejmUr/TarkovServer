using Newtonsoft.Json;
using ServerLib.Json.Classes;
using ServerLib.Utilities;
using static ServerLib.Json.Converters;

namespace ServerLib.Controllers
{
    public class QuestController
    {
        static QuestController()
        {

            Quests = new();

            Debug.PrintInfo("Initialization Done!", "QuestController");
        }
        public static Dictionary<string, Quest.Base> Quests;
        public static void Init()
        {
            try
            {
                var quests = JsonConvert.DeserializeObject<Dictionary<string, Quest.Base>>(DatabaseController.DataBase.Others.Quests, new JsonConverter[]
                {
                    QuestTargetConverter.Singleton
                });
                ArgumentNullException.ThrowIfNull(quests);
                Quests = quests;
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }
        }

        public static List<Quest.Base> GetQuests()
        {
            try
            {
                List<Quest.Base> list = new();
                foreach (var item in Quests.Values)
                {
                    if (item._id == "5936d90786f7742b1420ba5b")
                    {
                        Console.WriteLine(item._id);
                        var test = JsonConvert.SerializeObject(item, new JsonConverter[]
                        {
                            QuestTargetConverter.Singleton
                        });
                        File.WriteAllText("quetst_5936d90786f7742b1420ba5b.json",test);
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Debug.PrintError(ex.ToString());
                throw;
            }
        }
    }
}
