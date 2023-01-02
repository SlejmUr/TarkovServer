﻿using HttpServerLite;
using ServerLib.Controllers;
using ServerLib.Utilities;

namespace ServerLib.Web
{
    public class ClientGameProfile
    {
        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/list")]
        public async Task ProfileList(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);

            //HealOverTime!!

            string resp = CharacterController.GetCompleteCharacter(SessionID);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/search")]
        public async Task ProfileSearch(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            //HealOverTime!!

            // {"nickname": ""}


            string resp = CharacterController.GetCompleteCharacter(SessionID);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/select")]
        public async Task ProfileSelect(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string resp = "{\"status\": \"ok\",\"notifier\":\"" + ResponseControl.GetNotifier(SessionID) + "\",\"notifierServer\":\"\"}";
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/create")]
        public async Task ProfileCreate(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);
            CharacterController.CreateCharacter(SessionID, Uncompressed);
            string resp = "{ uid: \"pmc" + SessionID + "\"}";
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/nickname/reserved")]
        public async Task ProfileNicknameReserved(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string resp = AccountController.GetReservedNickname(SessionID);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.GetBody(resp));
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/nickname/validate")]
        public async Task ProfileNicknameValidate(HttpContext ctx)
        {
            //REQ stuff
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);

            var nickname = AccountController.ValidateNickname(Uncompressed);
            var resp = ResponseControl.GetBody("{status: \"ok\"}");
            if (nickname == "taken")
            {
                resp = ResponseControl.GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = ResponseControl.GetBody("null", 256, "The nickname is too short");
            }

            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/nickname/change")]
        public async Task ProfileNicknameChange(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);

            var nickname = CharacterController.ChangeNickname(Uncompressed, SessionID);
            var resp = ResponseControl.GetBody("{status: 0, nicknamechangedate: " + Utils.UnixTimeNow_Int() + "}");
            if (nickname == "taken")
            {
                resp = ResponseControl.GetBody("null", 255, "The nickname is already in use");
            }

            if (nickname == "tooshort")
            {
                resp = ResponseControl.GetBody("null", 256, "The nickname is too short");
            }
            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/voice/change")]
        public async Task ProfileVoiceChange(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string Uncompressed = ResponseControl.DeCompressReq(ctx.Request.DataAsBytes);

            CharacterController.ChangeVoice(Uncompressed, SessionID);
            // RPS
            var rsp = ResponseControl.CompressRsp(ResponseControl.NullResponse());
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/game/profile/items/moving")]
        public async Task ProfileItemsMoving(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string resp = "";
            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }

        [StaticRoute(HttpServerLite.HttpMethod.POST, "/client/profile/status")]
        public async Task ProfileStatus(HttpContext ctx)
        {
            //REQ stuff
            string SessionID = Utils.GetSessionID(ctx.Request.Headers);
            Utils.PrintRequest(ctx.Request);
            string resp = "";
            // RPS
            var rsp = ResponseControl.CompressRsp(resp);
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentLength = rsp.Length;
            await ctx.Response.TrySendAsync(rsp);
            return;
        }
    }
}
