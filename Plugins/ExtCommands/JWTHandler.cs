using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Security.Cryptography;

namespace ExtCommands
{
    public class JWTHandler
    {
        /// <summary>
        /// Create cert/rsa.xml
        /// </summary>
        public static void CreateRSA()
        {
            if (!Directory.Exists("cert"))
            {
                Directory.CreateDirectory("cert");
            }
            if (!File.Exists("cert/rsa.xml"))
            {
                RSA rsa = RSA.Create();
                File.WriteAllText("cert/rsa.xml", rsa.ToXmlString(true));
            }
        }

        public static RSA GetRSA()
        {
            RSA rsa = RSA.Create();
            if (!File.Exists("cert/rsa.xml"))
            {
                File.WriteAllText("cert/rsa.xml", rsa.ToXmlString(true));
                return rsa;
            }
            else
            {
                rsa.FromXmlString(File.ReadAllText("cert/rsa.xml"));
                return rsa;
            }
        }

        public static string CreateAuthToken(string SessionId, string ClientSharedSecret, long exp = long.MinValue)
        {
            var profile = AccountController.FindAccount(SessionId);
            if (profile == null)
            {
                Debug.PrintError("Profile not found returning null!", "CreateAuthToken");
                return string.Empty;
            }
            var perm = profile.Permission;

            RSA rsa = GetRSA();
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

        /// <summary>
        /// Get JWT Token as JSON
        /// </summary>
        /// <param name="token">The Token</param>
        /// <returns>JSON String</returns>
        public static string GetJWTJson(string token)
        {
            RSA rsa = GetRSA();
            var json = JwtBuilder.Create()
                                 .WithAlgorithm(new RS256Algorithm(rsa, rsa))
                                 .Decode(token);

            return json;
        }

        /// <summary>
        /// Validating any jwt Token
        /// </summary>
        /// <param name="token">The Token</param>
        /// <returns>True | False</returns>
        public static bool Validate(string token)
        {
            RSA rsa = GetRSA();
            try
            {
                var json = JwtBuilder.Create()
                                     .WithAlgorithm(new RS256Algorithm(rsa, rsa))
                                     .MustVerifySignature()
                                     .Decode(token);
            }
            catch (TokenNotYetValidException)
            {
                Console.WriteLine("Token is not valid yet");
                return false;
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                return false;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                return false;
            }
            return true;
        }
    }
}
