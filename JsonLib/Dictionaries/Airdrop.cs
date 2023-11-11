using JsonLib.Enums;

namespace ServerLib.Json.Dictionaries
{
    public static partial class Dict
    {
        public static readonly Dictionary<EAirdrop, string> AirdropType = new()
        {
            { EAirdrop.MIXED, "mixed" },
            { EAirdrop.WEAPONARMOR, "weaponarmor" },
            { EAirdrop.FOODMEDICAL, "foodmedical" },
            { EAirdrop.BARTER, "barter" }
        };
    }
}
