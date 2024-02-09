namespace TestServer.Messages
{
    public enum MessageId : byte
    {
        KeepAlive,
        InitConnection,
        InitConnectionRsp,
        NewUserConnected,
        NewUserConRsp,
        UserDisconnected,
        UserDisconnectedRsp,
        SpawnUser,
        SpawnUserRsp,
        DespawnUser,
        DespawnUserRsp,
        MatchRestarting,
    }
}
