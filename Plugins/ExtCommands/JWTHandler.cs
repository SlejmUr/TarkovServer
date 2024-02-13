using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Security.Cryptography;
using ServerLib.Handlers;

namespace ExtCommands
{
    public class JWTHandler_EX
    {
        public static string CreateAuthToken(string SessionId, string ClientSharedSecret, long exp = long.MinValue)
        {
            var profile = ProfileController.GetProfile(SessionId);
            if (profile == null)
            {
                Debug.PrintError("Profile not found returning null!", "CreateAuthToken");
                return string.Empty;
            }
            var perm = profile.ProfileAddon.Permission;

            RSA rsa = JWTHandler.GetRSA();
            if (exp == long.MinValue)
            {
                exp = DateTimeOffset.UtcNow.AddDays(10).ToUnixTimeSeconds();
            }
            var token = JwtBuilder.Create()
            .Subject(SessionId)
            .Issuer("TarkovServer")
            .WithAlgorithm(new RS256Algorithm(rsa, rsa))
            .ExpirationTime(exp)
            .AddClaim<jwt_json>("json", new() { Perms = perm, ClientSecret = ClientSharedSecret })
            .Encode();

            return token;
        }
    }
}
