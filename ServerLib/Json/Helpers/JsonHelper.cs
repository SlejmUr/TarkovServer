using ServerLib.Json.Classes;

namespace ServerLib.Json.Helpers
{
    public static class JsonHelper
    {
        public static Login ToLogin(Profile.Info info)
        {
            return new()
            { 
                password = info.Password,
                username = info.Username
            };
        }
        public static Profile.Info FromLogin(Login login)
        {
            return new()
            {
                Username = login.username,
                Password = login.password
            };
        }
    }
}
