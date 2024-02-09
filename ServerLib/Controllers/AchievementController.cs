using JsonLib.Classes.DatabaseRelated;

namespace ServerLib.Controllers
{
    public class AchievementController
    {
        static List<Achievement> Achievements;

        static AchievementController()
        {
            Achievements = DatabaseController.DataBase.Achievements;
        }

        public static bool GrantAchievement(string AchievementId, string SessionId, long time = -1)
        {
            if (Achievements.Where(x => x.id == AchievementId).Any())
            { 
                var profile = ProfileController.GetProfile(SessionId);
                if (profile != null)
                {
                    if (time == -1)
                        time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    return profile.Characters.Pmc.Achievements.TryAdd(AchievementId, (int)time);
                }            
            }
            return false;
        }

        public static JsonLib.Classes.Response.AchievementStatistic GetAchievementStatistics()
        {
            Dictionary<string, int> pairs = new();
            foreach (var item in Achievements)
            {
                pairs.Add(item.id, 0);
            }
            return new()
            { 
                elements = pairs
            };
        }

        public static JsonLib.Classes.Response.GetAchievements GetAchievements()
        {
            return new()
            { 
                elements = Achievements
            };
        }
    }
}
