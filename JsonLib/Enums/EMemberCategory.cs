namespace JsonLib.Enums
{
    [Flags]
    public enum EMemberCategory
    {
        Default = 0,
        Developer = 1,
        UniqueId = 2,
        Trader = 4,
        Group = 8,
        System = 16,
        ChatModerator = 32,
        ChatModeratorWithPermanentBan = 64,
        UnitTest = 128,
        Sherpa = 256,
        Emissary = 512
    }
}