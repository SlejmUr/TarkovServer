using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Bot
    {
        public class Names
        {
            [JsonProperty("russian")]
            public Russian Russian { get; set; }
        }

        public partial class Russian
        {
            [JsonProperty("first")]
            public First First { get; set; }

            [JsonProperty("last")]
            public string[] Last { get; set; }
        }

        public partial class First
        {
            [JsonProperty("male")]
            public string[] Male { get; set; }
        }

        public class Weapons
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_parent")]
            public string Parent { get; set; }

            [JsonProperty("_items")]
            public Item[] Items { get; set; }

            [JsonProperty("_type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("_changeWeaponName", NullValueHandling = NullValueHandling.Ignore)]
            public bool? ChangeWeaponName { get; set; }

            [JsonProperty("_name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("_encyclopedia", NullValueHandling = NullValueHandling.Ignore)]
            public string Encyclopedia { get; set; }
        }

        public partial class Item
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_tpl")]
            public string Tpl { get; set; }

            [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
            public string ParentId { get; set; }

            [JsonProperty("slotId", NullValueHandling = NullValueHandling.Ignore)]
            public string? SlotId { get; set; }

            [JsonProperty("upd", NullValueHandling = NullValueHandling.Ignore)]
            public Upd Upd { get; set; }
        }

        public partial class Upd
        {
            [JsonProperty("Sight", NullValueHandling = NullValueHandling.Ignore)]
            public Sight Sight { get; set; }

            [JsonProperty("Foldable", NullValueHandling = NullValueHandling.Ignore)]
            public Foldable Foldable { get; set; }

            [JsonProperty("FireMode", NullValueHandling = NullValueHandling.Ignore)]
            public FireMode FireMode { get; set; }
        }

        public partial class FireMode
        {
            [JsonProperty("FireMode")]
            public string FireModeFireMode { get; set; }
        }

        public partial class Foldable
        {
            [JsonProperty("Folded")]
            public bool Folded { get; set; }
        }

        public partial class Sight
        {
            [JsonProperty("SelectedSightMode")]
            public long SelectedSightMode { get; set; }
        }
    }
}
