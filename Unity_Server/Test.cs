using System;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour
{

	public static void LogMe(NetworkBehaviour obj, NetworkReader rdr)
	{
		Debug.Log("L: " + rdr.GetLenght());
		var bytes = rdr.GetBytes();
		Debug.Log("Bytes: " + BitConverter.ToString(bytes));
	}

}