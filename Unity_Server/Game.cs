using System;
using UnityEngine.Networking;
using ComponentAce.Compression.Libs.zlib;
using UnityEngine;

public class Game
{
	public static void OneFourSeven(NetworkMessage msg)
	{
		Debug.Log ("OneFourSeven activated!");
		msg.conn.logNetworkMessages = true;
		var ofsi = msg.ReadMessage<OneFourSevenINCOMMessage> ();
		Debug.Log ("ProfileId: " + ofsi.ProfileId + " | ObserveOnly: " + ofsi.ObserveOnly);

		var ofsm = new OneFourSevenMessage ();
		ofsm.bool_0 = false;
		ofsm.networkInstanceId_0 = new NetworkInstanceId ((uint)1);
		ofsm.byte_0 = 0;
		ofsm.byte_1 = SimpleZlib.CompressToBytes("[\"factory_preset\"]", 9);
		string weather = Weather.createNew().ToString();
		Debug.Log (weather);
		ofsm.byte_2 = SimpleZlib.CompressToBytes("[\"{"+ weather +"\"}]", 9);
		msg.conn.Send(msg.msgType, ofsm);
	}

	public class OneFourSevenINCOMMessage : MessageBase
	{
		// Token: 0x06000BB0 RID: 2992 RVA: 0x000094B7 File Offset: 0x000076B7
		public override void Deserialize(NetworkReader reader)
		{
			this.ProfileId = reader.ReadString();
			this.ObserveOnly = reader.ReadBoolean();
			base.Deserialize(reader);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x000094D8 File Offset: 0x000076D8
		public override void Serialize(NetworkWriter writer)
		{
			writer.Write(this.ProfileId);
			writer.Write(this.ObserveOnly);
			base.Serialize(writer);
		}

		// Token: 0x04000AB7 RID: 2743
		public string ProfileId;

		// Token: 0x04000AB8 RID: 2744
		public bool ObserveOnly;
	}

	public class OneFourSevenMessage : MessageBase
	{
		public NetworkInstanceId networkInstanceId_0;

		public byte byte_0;

		public Time Time_0;

		public byte[] byte_1;

		public byte[] byte_2;

		public bool bool_0;

		public override void Serialize(NetworkWriter writer)
		{
			writer.Write(networkInstanceId_0.Value);
			writer.Write(byte_0);
			Time.Serialize(writer);
			writer.WriteBytesFull(byte_1);
			writer.WriteBytesFull(byte_2);
			writer.Write(bool_0);
			base.Serialize(writer);
		}

		public class Time
		{
			public static void Serialize(NetworkWriter writer)
			{
				writer.Write(true);
				writer.Write(DateTime.Now.ToBinary());
				writer.Write((float)0f);
			}

		}
	}
}