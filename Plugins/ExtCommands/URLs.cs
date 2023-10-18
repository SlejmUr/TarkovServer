using NetCoreServer;
using Newtonsoft.Json;
using ServerLib.Controllers;
using ModdableWebServer.Helper;
using ModdableWebServer;
using ModdableWebServer.Attributes;

namespace ExtCommands
{
    public class URLs
    {
        [HTTP("POST", "/extcommands/auth")]
        public static bool ExtCommandsAuth(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine(request.Body);
            var rsp = JWTHandler.CreateAuthToken("yeet","yssss");
            serverStruct.Response.MakeGetResponse(rsp);
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("POST", "/extcommands/use")]
        public static bool ExtCommandsPost(HttpRequest request, ServerStruct serverStruct)
        {
            Console.WriteLine($"Command: {request.Body}");

            if (serverStruct.Headers.TryGetValue("Auth", out string authtoken) && JWTHandler.Validate(authtoken))
            {
                var json = JsonConvert.DeserializeObject<jwt_json>(JWTHandler.GetJWTJson(authtoken));
                if (json.Perms == ServerLib.Json.Enums.EPerms.Blocked)
                {
                    serverStruct.Response.MakeGetResponse("You are Banned!");
                    serverStruct.SendResponse();
                    return true;
                }
                if (CommandsController.CommandsPermission.TryGetValue(request.Body.Split(" ")[0], out var permission))
                {
                    if (permission >= json.Perms)
                    {
                        CommandsController.Run(request.Body);
                        serverStruct.Response.MakeGetResponse("Success!");
                        serverStruct.SendResponse();
                        return true;
                    }            
                }
            }
            serverStruct.Response.MakeGetResponse("Something not right...");
            serverStruct.SendResponse();
            return true;
        }
    }
}
