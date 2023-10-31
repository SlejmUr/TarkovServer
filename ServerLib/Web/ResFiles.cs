using ModdableWebServer;
using ModdableWebServer.Attributes;
using ModdableWebServer.Helper;
using NetCoreServer;
using ServerLib.Utilities.Helpers;

namespace ServerLib.Web
{
    public class ResFiles
    {

        [HTTP("GET", "/files/trader/avatar/{avatar}")]
        public static bool GetFilesAvatar(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string avatar = serverStruct.Parameters["avatar"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/trader/{avatar}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/avatar.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/trader/{avatar}");
            }
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/files/handbook/{handbook}")]
        public static bool GetFilesHandbook(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string handbook = serverStruct.Parameters["handbook"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/handbook/{handbook}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/handbook.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/handbook/{handbook}");
            }
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/files/Hideout/{Hideout}")]
        public static bool GetFilesHideout(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string Hideout = serverStruct.Parameters["Hideout"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/hideout/{Hideout}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/hideout.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/hideout/{Hideout}");
            }
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png");
            serverStruct.SendResponse();
            return true;
        }

        [HTTP("GET", "/files/quest/icon/{quest}")]
        public static bool GetFilesQuestIcon(HttpRequest request, ServerStruct serverStruct)
        {
            ServerHelper.PrintRequest(request, serverStruct);
            string quest = serverStruct.Parameters["quest"].Replace("jpg", "png");
            byte[] rsp;
            if (!File.Exists($"Files/res/quest/{quest}"))
            {
                rsp = File.ReadAllBytes($"Files/res/noimage/quest.png");
            }
            else
            {
                rsp = File.ReadAllBytes($"Files/res/quest/{quest}");
            }
            serverStruct.Response.MakeGetResponse(rsp).SetHeader("Content-Type", "image/png");
            serverStruct.SendResponse();
            return true;
        }

    }
}
