using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class Server : NetworkBehaviour
{
	public NetworkServerSimple server;

	public void StartServer()
	{
		try
		{
			LogFilter.current = LogFilter.FilterLevel.Developer;
			var tarkovConfig = ServerHelper.GetTarkovConfig();
			HostTopology hostTopology = new HostTopology(tarkovConfig, 100);
			server = new NetworkServerSimple();
			server.Configure(hostTopology);
			var isListen = server.Listen("127.0.0.1", 7777);
			Console.WriteLine(isListen);
			Debug.Log("Server Started");
			server.RegisterHandler(147, Game.OneFourSeven);
			RegisterCommandDelegate(typeof(Test), -249139387, Test.LogMe); //KillMe
			RegisterCommandDelegate(typeof(Test), 1930730778, Test.LogMe); //PlayerInput
			RegisterCommandDelegate(typeof(Test), 2102444979, Test.LogMe); //SendP2PInput
			RegisterCommandDelegate(typeof(Test), 1769900727, Test.LogMe); //SetDamageCoeff
			RegisterCommandDelegate(typeof(Test), -335664441, Test.LogMe); //StopInteract
			RegisterCommandDelegate(typeof(Test), 1961573666, Test.LogMe); //SearchContent
			RegisterCommandDelegate(typeof(Test), -795093056, Test.LogMe); //StopSearchContent
			RegisterCommandDelegate(typeof(Test), -2138577201, Test.LogMe); //ToggleGoggles
			RegisterCommandDelegate(typeof(Test), -1981236734, Test.LogMe); //TriggerPhrase
			RegisterCommandDelegate(typeof(Test), -1865438789, Test.LogMe); //ApplyFoodDrink
			RegisterCommandDelegate(typeof(Test), -1414617747, Test.LogMe); //ApplyMed
			RegisterCommandDelegate(typeof(Test), -392642507, Test.LogMe); //ClientConfirmCallback
			RegisterCommandDelegate(typeof(Test), 343818253, Test.LogMe); //SetDamageCoeff
			RegisterCommandDelegate(typeof(Test), -2029650985, Test.LogMe); //SwitchRenderers
			RegisterCommandDelegate(typeof(Test), -1957940333, Test.LogMe); //StartSearchingAction
			RegisterCommandDelegate(typeof(Test), -1238757687, Test.LogMe); //StopSearchingAction
			RegisterCommandDelegate(typeof(Test), -1946162020, Test.LogMe); //UpdateAccessStatus
			RegisterCommandDelegate(typeof(Test), -1821332252, Test.LogMe); //SetSearched
			RegisterCommandDelegate(typeof(Test), 2046473907, Test.LogMe); //StopSearching
			RegisterCommandDelegate(typeof(Test), 1943776490, Test.LogMe); //PlayerDied
			RegisterCommandDelegate(typeof(Test), -564706240, Test.LogMe); //EnemyKilled
			RegisterCommandDelegate(typeof(Test), -2037601397, Test.LogMe); //AcceptDownHealth
			RegisterCommandDelegate(typeof(Test), 1622233948, Test.LogMe); //SyncHealth
			RegisterCommandDelegate(typeof(Test), -1691042855, Test.LogMe); //SyncHidrationAndEnergy
			RegisterCommandDelegate(typeof(Test), -875210356, Test.LogMe); //AcceptCreatedEffect
			RegisterCommandDelegate(typeof(Test), 65847916, Test.LogMe); //AccecptDestroyedEffect
			RegisterCommandDelegate(typeof(Test), -898573523, Test.LogMe); //ArmorPointsChange
			RegisterCommandDelegate(typeof(Test), 447819449, Test.LogMe); //ToggleGoggles
			RegisterCommandDelegate(typeof(Test), 605159916, Test.LogMe); //TriggerPhrase
			RegisterCommandDelegate(typeof(Test), 1027122222, Test.LogMe); //BeeingHit
			RegisterCommandDelegate(typeof(Test), 1115725094, Test.LogMe); //ChangeSkillExperience
			RegisterCommandDelegate(typeof(Test), -911913671, Test.LogMe); //ChangeMasteringLevel
			Debug.Log("RegisterCommandDelegate's done");
		}
		catch (Exception ex)
		{
			Debug.Log(ex);
		}

	}

	void LateUpdate()
	{
		if (server != null)
		{
			if (server.serverHostId != -1)
			{
				Debug.Log("Timer");
				server.Update();
			}
		}
	}


	public void Stop()
	{
		server.Stop();
		Console.WriteLine("MLServer Stopped!");
	}
}
