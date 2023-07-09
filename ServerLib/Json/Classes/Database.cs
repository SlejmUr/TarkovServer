namespace ServerLib.Json.Classes
{
    public class Database
    {
        public bot Bot { get; set; } = new();
        public class bot
        {
            public Character.Base Base { get; set; }
            public Dictionary<string, Character.Base> Bosses { get; set; }
            public Bot.Names Names { get; set; }
            public Bot.Weapons[] Weapons { get; set; }
            public Dictionary<string, string[]> Settings { get; set; }

        }
        public characters Characters { get; set; } = new();
        public class characters
        {
            public Dictionary<string, Character.Base> CharacterBase = new();
        }

        public Dictionary<string, Item.Base> Items { get; set; }
    }
}
