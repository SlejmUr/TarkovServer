using System;
using UnityEngine.Networking;


public class Game
{
	public static void OneFourSeven(NetworkMessage msg)
	{
		var ProfileId = msg.reader.ReadString();
		var ObserveOnly = msg.reader.ReadBoolean();

		//msg.conn.Send(msg.msgType, );
	}
}