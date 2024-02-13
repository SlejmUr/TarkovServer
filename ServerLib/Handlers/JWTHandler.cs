using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using ServerLib.Controllers;
using ServerLib.Utilities;
using System.Security.Cryptography;

namespace ServerLib.Handlers
{
    public class JWTHandler
    {
        public static void CreateRSA()
        {
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

        public static string CreateGameToken(string SessionId)
        {
            var minicharacter = CharacterController.GetMiniCharacter(SessionId);
            if (minicharacter == null)
            {
                Debug.PrintError("Profile not found returning null!", "CreateGameToken");
                return string.Empty;
            }
            RSA rsa = GetRSA();
            var token = JwtBuilder.Create()
            .WithAlgorithm(new RS256Algorithm(rsa, rsa))
            .AddClaim("sub", minicharacter.Aid)
            .AddClaim("profileId", minicharacter.Id)
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
