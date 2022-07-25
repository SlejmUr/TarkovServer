using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Templates
    {
        public class Categories
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("ParentId")]
            public string ParentId { get; set; }

            [JsonProperty("Icon")]
            public string Icon { get; set; }

            [JsonProperty("Color")]
            public string Color { get; set; }

            [JsonProperty("Order")]
            public string Order { get; set; }
        }
        public class Items
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("ParentId")]
            public string ParentId { get; set; }

            [JsonProperty("Price")]
            public int Price { get; set; }
        }
    }
}
