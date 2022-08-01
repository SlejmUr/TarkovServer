using Newtonsoft.Json;
using ServerLib.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLib.Json
{
    public class Dialog
    {
        public string? _id { get; set; }
        public DialogController.messageTypes? type { get; set; }
        public List<Messages>? messages { get; set; }
        public bool? pinned { get; set; }

        [JsonProperty("new")]
        public int? New { get; set; }
        public int? attachmentsNew { get; set; }
        public class Messages
        {
            public string? _id { get; set; }
            public string? uid { get; set; }
            public DialogController.messageTypes? type { get; set; }
            public int dt { get; set; }
            public string? templateId { get; set; }
            public string? text { get; set; }
            public bool hasRewards { get; set; }
            public bool rewardCollected { get; set; }
            public StashItems? items { get; set; }
            public int maxStorageTime { get; set; }
            public MessagesContent.SystemData? systemData { get; set; }

        }

        public class MessagesContent
        {
            public DialogController.messageTypes type { get; set; }
            public string? text { get; set; }
            public string? templateId { get; set; }
            public int maxStorageTime { get; set; } = 0;
            public SystemData? systemData { get; set; }

            public class SystemData
            {
                public int? date { get; set; }
                public string? time { get; set; }
                public string? location { get; set; }
            }
        }

        public class StashItems
        {
            public string stash { get; set; }
            public List<StashData> data { get; set; }
            public string location { get; set; }
            public class StashData
            {
                public string parentId { get; set; }
                public string slotId { get; set; }
            }
        }
    }
}
