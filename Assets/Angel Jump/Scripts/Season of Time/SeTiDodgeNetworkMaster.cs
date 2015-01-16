using UnityEngine;
using System.Collections;

public class SeTiDodgeNetworkMaster : SeTi_Base {

	private static readonly string TAG = typeof(SeTiDodgeNetworkMaster).Name;

	GodDodgeNetwork godDodgeNetwork = GuildOfMB.GodDodgeNetwork;

	float elapsedTimeForObstacles = 0;

	Transform transformSpawnPointLeft;
	
	public override void Enter () {
		base.Enter ();
		UtilLogger.Log(TAG, "Enter()");

		transformSpawnPointLeft = GameObject.Find("Dodge Network").transform.FindChild("Spawn Point Left");

		godDodgeNetwork.SpawnEnvironment();
		PhotonNetwork.Instantiate(ConstantResources.ANGEL, new Vector3(0, 0, 0), Quaternion.identity, 0);
	}

	public override void Exit () {
		UtilLogger.Log(TAG, "Exit()");
		base.Exit ();
	}

	private static SeTiDodgeNetworkMaster instance;
	public static SeTiDodgeNetworkMaster Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiDodgeNetworkMaster();}
			
			return instance;
		}
	}
}
