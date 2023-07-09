using System;
using UnityEngine.Networking;
using UnityEngine;


public class TarkovNetworkServer : NetworkServerSimple
{
	public override void OnConnected (NetworkConnection conn)
	{
		conn.logNetworkMessages = true;
		Debug.Log (conn.connectionId + " " + conn.address + " " + conn.hostId);
		base.OnConnected (conn);
	}

	public override void OnData (NetworkConnection conn, int receivedSize, int channelId)
	{
		conn.logNetworkMessages = true;
		Debug.Log (conn.connectionId + " " + conn.address + " " + conn.hostId + " " + receivedSize + " " + channelId);
		base.OnData (conn, receivedSize, channelId);
	}

	public override void OnDataError (NetworkConnection conn, byte error)
	{		
		Debug.Log (conn.connectionId + " " + conn.address + " " + conn.hostId + " " + error);
		base.OnDataError (conn, error);
	}
		
}