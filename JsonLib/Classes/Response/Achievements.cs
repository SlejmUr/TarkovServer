using JsonLib.Classes.DatabaseRelated;

namespace JsonLib.Classes.Response
{
    public class GetAchievements
    {
        public List<Achievement> elements { get; set; }
    }

    public class AchievementStatistic
    {
        public Dictionary<string, int> elements { get; set; }
    }
}
