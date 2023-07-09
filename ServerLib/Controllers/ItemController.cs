using ServerLib.Utilities;
using ServerLib.Json.Classes;
using ServerLib.Handlers;

namespace ServerLib.Controllers
{
    public class ItemController
    {

        public struct Size
        { 
            public int x; 
            public int y;
            public int l;
            public int r;
            public int u;
            public int d;

            public Size()
            {
                this.x = 0;
                this.y = 0;
                this.l = 0;
                this.r = 0;
                this.u = 0;
                this.d = 0;
            }
        }

        public static Item.Base? GetItemFromID(string ID)
        {
            foreach (var item in DatabaseController.DataBase.Items)
            {
                if (item.Key == ID | item.Value.Id == ID)
                    return item.Value;
            }
            return null;
        }

        public static Size GetSize(string ItemTpl, string ItemId, List<Character.Item> Items) 
        {
            Size ret = new Size();
            List<string> ItemIds = new() { ItemId };
            var tmpItem = GetItemFromID(ItemTpl);
            if (tmpItem != null)
            {
                ret.x = (int)tmpItem.Props.Width.Value;
                ret.y = (int)tmpItem.Props.Height.Value;

                while (true)
                {
                    Debug.PrintDebug("Count: " + ItemIds.Count, "ItemController.GetSize");
                    if (ItemIds.Count != 0)
                    {
                        foreach (var item in Items)
                        {
                            var tmpSize = new Size();
                            if (item.ParentId == ItemIds[0])
                            {
                                ItemIds.Add(item.Id);
                                tmpItem = GetItemFromID(item.Tpl);
                                if (tmpItem != null)
                                {
                                    //No extra size, should we add to the base size?
                                }
                            }
                        }
                        ItemIds.RemoveRange(0,1);
                        continue;
                    }
                    break;
                }
            }
            return ret;
        }

        public static void AcceptQuest(string SessionId, dynamic body)
        {
            var ch = CharacterController.GetCharacter(SessionId);
            if (ch != null)
            {
                // statuses seem as follow - 1 - not accepted | 2 - accepted | 3 - failed | 4 - completed
                ch.Quests = ch.Quests.Append(new Character.Quest() { qid = body.qid, startTime = 1337, status = 1 }).ToArray();
                SaveHandler.SaveCharacter(SessionId, ch);
            }
        }

        public static void CompleteQuest(string SessionId, dynamic body)
        {
            var ch = CharacterController.GetCharacter(SessionId);
            if (ch != null)
            {
                foreach (var item in ch.Quests)
                {
                    if (item.qid == body.qid)
                    {
                        item.status = 4;
                    }
                }
                SaveHandler.SaveCharacter(SessionId, ch);
            }
        }
    }
}
