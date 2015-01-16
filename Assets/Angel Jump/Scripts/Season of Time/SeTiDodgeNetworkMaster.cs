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

		PhotonNetwork.InstantiateSceneObject(ConstantResources.BACKGROUND, new Vector3(0, 0, 10), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(-5.12f, 0, 0), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(5.1f, 0, 0), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.GROUND_LONG, new Vector3(0, -2.9f, 0), Quaternion.identity, 0, null);

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
