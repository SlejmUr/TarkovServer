using JsonLib.Classes.ProfileRelated;
using Newtonsoft.Json;

namespace JsonLib
{
    public readonly struct MongoID : IComparable<MongoID>, IEquatable<MongoID>
    {
        public static uint TimeStamp
        {
            get
            {
                return Convert.ToUInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            }
        }

        private static ulong Counter
        {
            get
            {
                return (ulong)((long)MongoID._random.Next(0, int.MaxValue) << 8 ^ (long)MongoID._random.Next(0, int.MaxValue));
            }
        }

        public static string Generate()
        {
            return MongoID.generate(MongoID.TimeStamp, MongoID.Counter << 24);
        }

        private static string generate(uint timeStamp, ulong counter)
        {
            return timeStamp.ToString("X8").ToLower() + counter.ToString("X16").ToLower();
        }

        public static uint ConvertTimeStamp(string id)
        {
            return Convert.ToUInt32(id.Substring(0, 8), 16);
        }

        public static ulong ConvertCounter(string id)
        {
            return Convert.ToUInt64(id.Substring(8, 16), 16);
        }

        [JsonConstructor]
        public MongoID([JsonProperty("$value")] string id)
        {
            this._timeStamp = ConvertTimeStamp(id);
            this._counter = ConvertCounter(id);
            this._stringID = id;
            this.method_0();
        }


        private MongoID(BinaryReader reader)
        {
            this._timeStamp = reader.ReadUInt32();
            this._counter = reader.ReadUInt64();
            this._stringID = null;
            this._stringID = this.GetString();
            this.method_0();
        }

        public MongoID(bool newProcessId)
        {
            this._timeStamp = 0U;
            this._stringID = null;
            if (newProcessId)
            {
                this._counter = Counter << 24;
            }
            else
            {
                _newIdCounter += 1U;
                this._counter = (_processId << 24) + (ulong)_newIdCounter;
            }
            this._timeStamp = TimeStamp;
            this._stringID = this.GetString();
        }

        public MongoID(Character.Base profile)
        {
            this._stringID = null;
            this._timeStamp = TimeStamp;
            uint num = Convert.ToUInt32(profile.Aid);
            uint num2 = Convert.ToUInt32(_random.Next(0, 16777215));
            this._counter = (4294967296UL | (ulong)num);
            this._counter <<= 24;
            this._counter |= (ulong)num2;
            this._stringID = this.GetString();
        }

        private MongoID(MongoID source, int increment, bool newTimestamp)
        {
            this._timeStamp = (newTimestamp ? TimeStamp : source._timeStamp);
            this._counter = ((increment > 0) ? (source._counter + (ulong)Convert.ToUInt32(increment)) : (source._counter - (ulong)Convert.ToUInt32(Math.Abs(increment))));
            this._stringID = null;
            this._stringID = this.GetString();
        }

        private void method_0()
        {
            ulong num = Convert.ToUInt64(this._counter >> 24);
            if (MongoID._processId != num)
            {
                return;
            }
            uint val = Convert.ToUInt32(this._counter << 40 >> 40);
            MongoID._newIdCounter = Math.Max(MongoID._newIdCounter, val);
        }

        public MongoID Next()
        {
            return new MongoID(this, 1, true);
        }


        public static MongoID Read(BinaryReader reader)
        {
            return new MongoID(reader);
        }


        public void Write(BinaryWriter writer)
        {
            writer.Write(this._timeStamp);
            writer.Write(this._counter);
        }

        public bool Equals(MongoID other)
        {
            return this._timeStamp == other._timeStamp && this._counter == other._counter;
        }

        public int CompareTo(MongoID other)
        {
            if (this == other)
            {
                return 0;
            }
            if (this > other)
            {
                return 1;
            }
            return -1;
        }

        private string GetString()
        {
            return generate(this._timeStamp, this._counter);
        }

        public override string ToString()
        {
            return this._stringID ?? string.Empty;
        }

        public byte[] ToBytes()
        {
            byte[] array = new byte[12];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(this._timeStamp >> (3 - i) * 8);
            }
            for (int j = 0; j < 8; j++)
            {
                array[j + 4] = (byte)(this._counter >> (7 - j) * 8);
            }
            return array;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj is MongoID)
                {
                    MongoID a = (MongoID)obj;
                    return a == this;
                }
                string a2;
                if ((a2 = (obj as string)) != null)
                {
                    return a2 == this.ToString();
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            uint num = Convert.ToUInt32(this._counter >> 32) * 3637U;
            uint num2 = Convert.ToUInt32(this._counter << 32 >> 32) * 5807U;
            return (int)(this._timeStamp ^ num ^ num2);
        }

        public static implicit operator string(MongoID mongoId)
        {
            return mongoId.ToString();
        }

        public static implicit operator MongoID(string id)
        {
            return new MongoID(id);
        }

        public static MongoID operator ++(MongoID id)
        {
            return new MongoID(id, 1, false);
        }

        public static MongoID operator --(MongoID id)
        {
            return new MongoID(id, -1, false);
        }

        public static bool operator ==(MongoID a, MongoID b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(MongoID a, MongoID b)
        {
            return !a.Equals(b);
        }

        public static bool operator >(MongoID a, MongoID b)
        {
            return a._timeStamp > b._timeStamp || (a._timeStamp == b._timeStamp && a._counter > b._counter);
        }

        public static bool operator <(MongoID a, MongoID b)
        {
            return a._timeStamp < b._timeStamp || (a._timeStamp == b._timeStamp && a._counter < b._counter);
        }

        public static bool operator >=(MongoID a, MongoID b)
        {
            return a == b || a > b;
        }

        public static bool operator <=(MongoID a, MongoID b)
        {
            return a == b || a < b;
        }
        private static Random _random = new Random();
        private static readonly ulong _processId = Counter;
        private static uint _newIdCounter;
        private readonly uint _timeStamp;
        private readonly ulong _counter;
        private readonly string _stringID;
        public static string Default = "ffffffffffffffffffffffff";
    }
}
