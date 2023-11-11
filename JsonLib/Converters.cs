using JsonLib.Classes.ItemRelated;
using Newtonsoft.Json;
using static JsonLib.Classes.ItemRelated.TemplateItem;

namespace JsonLib
{
#pragma warning disable CS8601 // Possible null reference assignment.
    public class Converters
    {
        public partial struct EffectsHealthUnion
        {
            public object[] AnythingArray;
            public EffectsHealth EffectsHealthClass;

            public static implicit operator EffectsHealthUnion(object[] AnythingArray) => new() { AnythingArray = AnythingArray };
            public static implicit operator EffectsHealthUnion(EffectsHealth EffectsHealthClass) => new() { EffectsHealthClass = EffectsHealthClass };
        }

        public partial struct CustomizationPrefab
        {
            public string StringPrefab;
            public CustomizationItem.Prefab CustomPrefab;

            public static implicit operator CustomizationPrefab(string _StringPrefab) => new() { StringPrefab = _StringPrefab };
            public static implicit operator CustomizationPrefab(CustomizationItem.Prefab _CustomPrefab) => new() { CustomPrefab = _CustomPrefab };
        }

        public partial struct AimSensitivity
        {
            public double? Double;
            public double[][] DoubleArrayArray;

            public static implicit operator AimSensitivity(double Double) => new() { Double = Double };
            public static implicit operator AimSensitivity(double[][] DoubleArrayArray) => new() { DoubleArrayArray = DoubleArrayArray };
        }

        public partial struct Location
        {
            public Item._Location ItemLocation;
            public long? IntLocation;

            public static implicit operator Location(Item._Location ItemLocation) => new() { ItemLocation = ItemLocation };
            public static implicit operator Location(long IntLocation) => new() { IntLocation = IntLocation };
        }

        public class AimSensitivityConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AimSensitivity) || t == typeof(AimSensitivity?);

            public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                    case JsonToken.Float:
                        var doubleValue = serializer.Deserialize<double>(reader);
                        return new AimSensitivity { Double = doubleValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<double[][]>(reader);
                        return new AimSensitivity { DoubleArrayArray = arrayValue! };
                }
                throw new Exception("Cannot unmarshal type AimSensitivity");
            }

            public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
            {
                ArgumentNullException.ThrowIfNull(untypedValue);
                var value = (AimSensitivity)untypedValue;
                if (value.Double != null)
                {
                    serializer.Serialize(writer, value.Double.Value);
                    return;
                }
                if (value.DoubleArrayArray != null)
                {
                    serializer.Serialize(writer, value.DoubleArrayArray);
                    return;
                }
                throw new Exception("Cannot marshal type AimSensitivity");
            }

            public static readonly AimSensitivityConverter Singleton = new();
        }
        public class EffectsHealthUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EffectsHealthUnion) || t == typeof(EffectsHealthUnion?);

            public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<EffectsHealth>(reader);
                        return new EffectsHealthUnion { EffectsHealthClass = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<object[]>(reader);
                        return new EffectsHealthUnion { AnythingArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type EffectsHealthUnion");
            }

            public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
            {
                ArgumentNullException.ThrowIfNull(untypedValue);
                var value = (EffectsHealthUnion)untypedValue;
                if (value.AnythingArray != null)
                {
                    serializer.Serialize(writer, value.AnythingArray);
                    return;
                }
                if (value.EffectsHealthClass != null)
                {
                    serializer.Serialize(writer, value.EffectsHealthClass);
                    return;
                }
                throw new Exception("Cannot marshal type EffectsHealthUnion");
            }

            public static readonly EffectsHealthUnionConverter Singleton = new();
        }
        public class ItemLocationConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Location) || t == typeof(Location?);

            public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<Item._Location>(reader);
                        return new Location { ItemLocation = objectValue };
                    case JsonToken.Integer:
                        var intValue = serializer.Deserialize<long>(reader);
                        return new Location { IntLocation = intValue };
                }
                throw new Exception("Cannot unmarshal type Location");
            }

            public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
            {
                ArgumentNullException.ThrowIfNull(untypedValue);
                var value = (Location)untypedValue;
                if (value.IntLocation != null)
                {
                    serializer.Serialize(writer, value.IntLocation.Value);
                    return;
                }
                if (value.ItemLocation != null)
                {
                    serializer.Serialize(writer, value.ItemLocation);
                    return;
                }
                throw new Exception("Cannot marshal type Location");
            }

            public static readonly ItemLocationConverter Singleton = new();
        }
        public class CustomizationItemPrefabConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CustomizationPrefab) || t == typeof(CustomizationPrefab?);

            public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<CustomizationItem.Prefab>(reader);
                        return new CustomizationPrefab { CustomPrefab = objectValue };
                    case JsonToken.String:
                        var arrayValue = serializer.Deserialize<string>(reader);
                        return new CustomizationPrefab { StringPrefab = arrayValue };
                }
                throw new Exception("Cannot unmarshal type EffectsHealthUnion");
            }

            public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
            {
                ArgumentNullException.ThrowIfNull(untypedValue);
                var value = (CustomizationPrefab)untypedValue;
                if (value.CustomPrefab != null)
                {
                    serializer.Serialize(writer, value.CustomPrefab);
                    return;
                }
                if (value.StringPrefab != null)
                {
                    serializer.Serialize(writer, value.StringPrefab);
                    return;
                }
                throw new Exception("Cannot marshal type EffectsHealthUnion");
            }

            public static readonly CustomizationItemPrefabConverter Singleton = new();
        }

        public partial struct QuestTarget
        {
            public string[] StringArray;
            public string String;

            public static implicit operator QuestTarget(string[] StringArray) => new() { StringArray = StringArray };
            public static implicit operator QuestTarget(string String) => new() { String = String };
        }

        public class QuestTargetConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(QuestTarget) || t == typeof(QuestTarget?);

            public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        return new QuestTarget { String = stringValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<string[]>(reader);
                        return new QuestTarget { StringArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type QuestTarget");
            }

            public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
            {
                ArgumentNullException.ThrowIfNull(untypedValue);
                var value = (QuestTarget)untypedValue;
                if (value.String != null)
                {
                    serializer.Serialize(writer, value.String);
                    return;
                }
                if (value.StringArray != null)
                {
                    serializer.Serialize(writer, value.StringArray);
                    return;
                }
                throw new Exception("Cannot marshal type QuestTarget" + untypedValue);
            }

            public static readonly QuestTargetConverter Singleton = new();
        }
    }
#pragma warning restore CS8601 // Possible null reference assignment.
}
