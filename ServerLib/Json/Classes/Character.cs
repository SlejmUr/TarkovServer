using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServerLib.Json.Classes
{
    public class Character
    {
        public partial class Base
        {
            [JsonProperty("TraderStandings")]
            public BackendCounters TraderStandings { get; set; }

            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("int_id")]
            public long IntId { get; set; }

            [JsonProperty("Info")]
            public Info Info { get; set; }

            [JsonProperty("Customization")]
            public Customization Customization { get; set; }

            [JsonProperty("Encyclopedia")]
            public string[] Encyclopedia { get; set; }

            [JsonProperty("Health")]
            public Health Health { get; set; }

            [JsonProperty("Inventory")]
            public Inventory Inventory { get; set; }

            [JsonProperty("Skills")]
            public Skills Skills { get; set; }

            [JsonProperty("Notes")]
            public Notes Notes { get; set; }

            [JsonProperty("Quests")]
            public object[] Quests { get; set; }

            [JsonProperty("ConditionCounters")]
            public ConditionCounters ConditionCounters { get; set; }

            [JsonProperty("BackendCounters")]
            public BackendCounters BackendCounters { get; set; }

            [JsonProperty("Stats")]
            public Stats Stats { get; set; }
        }

        public partial class BackendCounters
        {
        }

        public partial class ConditionCounters
        {
            [JsonProperty("Counters")]
            public object[] Counters { get; set; }
        }

        public partial class Customization
        {
            [JsonProperty("Head")]
            public Body Head { get; set; }

            [JsonProperty("Body")]
            public Body Body { get; set; }

            [JsonProperty("Feet")]
            public Body Feet { get; set; }

            [JsonProperty("Hands")]
            public Body Hands { get; set; }
        }

        public partial class Body
        {
            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("rcid")]
            public string Rcid { get; set; }
        }

        public partial class Health
        {
            [JsonProperty("HealthSeed")]
            public int HealthSeed { get; set; }

            [JsonProperty("IsAlive")]
            public bool IsAlive { get; set; }

            [JsonProperty("HydrationLimitedValue")]
            public EnergyLimitedValue HydrationLimitedValue { get; set; }

            [JsonProperty("EnergyLimitedValue")]
            public EnergyLimitedValue EnergyLimitedValue { get; set; }

            [JsonProperty("BodyPartsHealth")]
            public BodyPartsHealth BodyPartsHealth { get; set; }

            [JsonProperty("DestroyedParts")]
            public object[] DestroyedParts { get; set; }

            [JsonProperty("EffectInfoList")]
            public object[] EffectInfoList { get; set; }

            [JsonProperty("StimulatorInfoList")]
            public object[] StimulatorInfoList { get; set; }

            [JsonProperty("HealthRegenInfo")]
            public RegenInfo HealthRegenInfo { get; set; }

            [JsonProperty("HydrationRegenInfo")]
            public RegenInfo HydrationRegenInfo { get; set; }

            [JsonProperty("EnergyRegenInfo")]
            public RegenInfo EnergyRegenInfo { get; set; }

            [JsonProperty("DamageCoefficient")]
            public long DamageCoefficient { get; set; }
        }

        public partial class BodyPartsHealth
        {
            [JsonProperty("Head")]
            public EnergyLimitedValue Head { get; set; }

            [JsonProperty("Chest")]
            public EnergyLimitedValue Chest { get; set; }

            [JsonProperty("Stomach")]
            public EnergyLimitedValue Stomach { get; set; }

            [JsonProperty("LeftArm")]
            public EnergyLimitedValue LeftArm { get; set; }

            [JsonProperty("RightArm")]
            public EnergyLimitedValue RightArm { get; set; }

            [JsonProperty("LeftLeg")]
            public EnergyLimitedValue LeftLeg { get; set; }

            [JsonProperty("RightLeg")]
            public EnergyLimitedValue RightLeg { get; set; }
        }

        public partial class EnergyLimitedValue
        {
            [JsonProperty("MaxTopThreshold")]
            public int MaxTopThreshold { get; set; }

            [JsonProperty("MinTopThreshold")]
            public int MinTopThreshold { get; set; }

            [JsonProperty("CurrAndMaxValue")]
            public CurrAndMaxValue CurrAndMaxValue { get; set; }
        }

        public partial class CurrAndMaxValue
        {
            [JsonProperty("CurrentValue")]
            public double CurrentValue { get; set; }

            [JsonProperty("MaxValue")]
            public int MaxValue { get; set; }
        }

        public partial class RegenInfo
        {
            [JsonProperty("startTime")]
            public int StartTime { get; set; }

            [JsonProperty("addedValue")]
            public int AddedValue { get; set; }

            [JsonProperty("timeInterval")]
            public int TimeInterval { get; set; }
        }

        public partial class Info
        {
            [JsonProperty("Experience")]
            public int Experience { get; set; }

            [JsonProperty("Level")]
            public int Level { get; set; }

            [JsonProperty("Nickname")]
            public string Nickname { get; set; }

            [JsonProperty("Side")]
            public string Side { get; set; }

            [JsonProperty("RegistrationDate")]
            public int RegistrationDate { get; set; }
        }

        public partial class Inventory
        {
            [JsonProperty("items")]
            public Item[] Items { get; set; }

            [JsonProperty("equipment")]
            public string Equipment { get; set; }

            [JsonProperty("stash")]
            public string Stash { get; set; }

            [JsonProperty("fastPanel")]
            public BackendCounters FastPanel { get; set; }
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
            public string SlotId { get; set; }

            [JsonProperty("upd", NullValueHandling = NullValueHandling.Ignore)]
            public Upd Upd { get; set; }

            [JsonProperty("location")]
            public LocationUnion? Location { get; set; }
        }

        public partial class LocationClass
        {
            [JsonProperty("x")]
            public long X { get; set; }

            [JsonProperty("y")]
            public long Y { get; set; }

            [JsonProperty("r")]
            public RUnion R { get; set; }
        }

        public partial class Upd
        {
            [JsonProperty("Durability", NullValueHandling = NullValueHandling.Ignore)]
            public long? Durability { get; set; }

            [JsonProperty("StackObjectsCount", NullValueHandling = NullValueHandling.Ignore)]
            public long? StackObjectsCount { get; set; }

            [JsonProperty("hpPercent", NullValueHandling = NullValueHandling.Ignore)]
            public long? HpPercent { get; set; }

            [JsonProperty("hpResource", NullValueHandling = NullValueHandling.Ignore)]
            public long? HpResource { get; set; }

            [JsonProperty("MaxDurability", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxDurability { get; set; }
        }

        public partial class Notes
        {
            [JsonProperty("Notes")]
            public object[] NotesNotes { get; set; }
        }

        public partial class Skills
        {
            [JsonProperty("Common")]
            public Common[] Common { get; set; }

            [JsonProperty("Mastering")]
            public object[] Mastering { get; set; }

            [JsonProperty("Points")]
            public long Points { get; set; }
        }

        public partial class Common
        {
            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Progress")]
            public long Progress { get; set; }

            [JsonProperty("MaxAchieved")]
            public long MaxAchieved { get; set; }

            [JsonProperty("LastAccess")]
            public long LastAccess { get; set; }
        }

        public partial class Stats
        {
            [JsonProperty("SessionCounters")]
            public Counters SessionCounters { get; set; }

            [JsonProperty("OverallCounters")]
            public Counters OverallCounters { get; set; }

            [JsonProperty("SessionExperienceMult")]
            public double SessionExperienceMult { get; set; }

            [JsonProperty("TotalSessionExperience")]
            public long TotalSessionExperience { get; set; }

            [JsonProperty("LastSessionDate")]
            public long LastSessionDate { get; set; }
        }

        public partial class Counters
        {
            [JsonProperty("Items")]
            public ItemElement[] Items { get; set; }
        }

        public partial class ItemElement
        {
            [JsonProperty("Key")]
            public string[] Key { get; set; }

            [JsonProperty("Value")]
            public long Value { get; set; }
        }

        public enum REnum { Horizontal, Vertical };

        public partial struct RUnion
        {
            public REnum? Enum;
            public long? Integer;

            public static implicit operator RUnion(REnum Enum) => new RUnion { Enum = Enum };
            public static implicit operator RUnion(long Integer) => new RUnion { Integer = Integer };
        }

        public partial struct LocationUnion
        {
            public long? Integer;
            public LocationClass LocationClass;

            public static implicit operator LocationUnion(long Integer) => new LocationUnion { Integer = Integer };
            public static implicit operator LocationUnion(LocationClass LocationClass) => new LocationUnion { LocationClass = LocationClass };
            public bool IsNull => LocationClass == null && Integer == null;
        }

        public partial class Base
        {
            public static Base FromJson(string json) => JsonConvert.DeserializeObject<Base>(json, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                LocationUnionConverter.Singleton,
                RUnionConverter.Singleton,
                REnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class LocationUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(LocationUnion) || t == typeof(LocationUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Null:
                        return new LocationUnion { };
                    case JsonToken.Integer:
                        var integerValue = serializer.Deserialize<long>(reader);
                        return new LocationUnion { Integer = integerValue };
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<LocationClass>(reader);
                        return new LocationUnion { LocationClass = objectValue };
                }
                throw new Exception("Cannot unmarshal type LocationUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (LocationUnion)untypedValue;
                if (value.IsNull)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                if (value.Integer != null)
                {
                    serializer.Serialize(writer, value.Integer.Value);
                    return;
                }
                if (value.LocationClass != null)
                {
                    serializer.Serialize(writer, value.LocationClass);
                    return;
                }
                throw new Exception("Cannot marshal type LocationUnion");
            }

            public static readonly LocationUnionConverter Singleton = new LocationUnionConverter();
        }

        internal class RUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(RUnion) || t == typeof(RUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                        var integerValue = serializer.Deserialize<long>(reader);
                        return new RUnion { Integer = integerValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        switch (stringValue)
                        {
                            case "Horizontal":
                                return new RUnion { Enum = REnum.Horizontal };
                            case "Vertical":
                                return new RUnion { Enum = REnum.Vertical };
                        }
                        break;
                }
                throw new Exception("Cannot unmarshal type RUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (RUnion)untypedValue;
                if (value.Integer != null)
                {
                    serializer.Serialize(writer, value.Integer.Value);
                    return;
                }
                if (value.Enum != null)
                {
                    switch (value.Enum)
                    {
                        case REnum.Horizontal:
                            serializer.Serialize(writer, "Horizontal");
                            return;
                        case REnum.Vertical:
                            serializer.Serialize(writer, "Vertical");
                            return;
                    }
                }
                throw new Exception("Cannot marshal type RUnion");
            }

            public static readonly RUnionConverter Singleton = new RUnionConverter();
        }

        internal class REnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(REnum) || t == typeof(REnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Horizontal":
                        return REnum.Horizontal;
                    case "Vertical":
                        return REnum.Vertical;
                }
                throw new Exception("Cannot unmarshal type REnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (REnum)untypedValue;
                switch (value)
                {
                    case REnum.Horizontal:
                        serializer.Serialize(writer, "Horizontal");
                        return;
                    case REnum.Vertical:
                        serializer.Serialize(writer, "Vertical");
                        return;
                }
                throw new Exception("Cannot marshal type REnum");
            }

            public static readonly REnumConverter Singleton = new REnumConverter();
        }
    }
}
