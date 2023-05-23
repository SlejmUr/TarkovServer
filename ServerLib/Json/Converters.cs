﻿using Newtonsoft.Json;
using ServerLib.Json.Classes;
using static ServerLib.Json.Classes.TemplateItem;

namespace ServerLib.Json
{
    public class Converters
    {
        public partial struct EffectsHealthUnion
        {
            public object[] AnythingArray;
            public EffectsHealth EffectsHealthClass;

            public static implicit operator EffectsHealthUnion(object[] AnythingArray) => new EffectsHealthUnion { AnythingArray = AnythingArray };
            public static implicit operator EffectsHealthUnion(EffectsHealth EffectsHealthClass) => new EffectsHealthUnion { EffectsHealthClass = EffectsHealthClass };
        }

        public partial struct CustomizationPrefab
        {
            public string StringPrefab;
            public CustomizationItem.Prefab CustomPrefab;

            public static implicit operator CustomizationPrefab(string _StringPrefab) => new CustomizationPrefab { StringPrefab = _StringPrefab };
            public static implicit operator CustomizationPrefab(CustomizationItem.Prefab _CustomPrefab) => new CustomizationPrefab { CustomPrefab = _CustomPrefab };
        }

        public partial struct AimSensitivity
        {
            public double? Double;
            public double[][] DoubleArrayArray;

            public static implicit operator AimSensitivity(double Double) => new AimSensitivity { Double = Double };
            public static implicit operator AimSensitivity(double[][] DoubleArrayArray) => new AimSensitivity { DoubleArrayArray = DoubleArrayArray };
        }

        public class AimSensitivityConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(AimSensitivity) || t == typeof(AimSensitivity?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                    case JsonToken.Float:
                        var doubleValue = serializer.Deserialize<double>(reader);
                        return new AimSensitivity { Double = doubleValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<double[][]>(reader);
                        return new AimSensitivity { DoubleArrayArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type AimSensitivity");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
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

            public static readonly AimSensitivityConverter Singleton = new AimSensitivityConverter();
        }

        public class EffectsHealthUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EffectsHealthUnion) || t == typeof(EffectsHealthUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
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

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
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

            public static readonly EffectsHealthUnionConverter Singleton = new EffectsHealthUnionConverter();
        }


        public class CustomizationItemPrefabConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CustomizationPrefab) || t == typeof(CustomizationPrefab?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
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

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
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

            public static readonly CustomizationItemPrefabConverter Singleton = new CustomizationItemPrefabConverter();
        }
    }
}