using UnityEngine;
using System.Collections;

public class SeTiDodgeNetworkMaster : SeTi_Base {

	private static readonly string TAG = "SeTiDodgeNetworkMaster";

	float elapsedTimeForObstacles = 0;

	Transform transformSpawnPointLeft;

	private SeTiDodgeNetworkMaster() {
	}
	
	public override void Enter () {
		base.Enter ();

		transformSpawnPointLeft = GameObject.Find("Dodge Network").transform.FindChild("Spawn Point Left");

		PhotonNetwork.InstantiateSceneObject(ConstantResources.BACKGROUND, new Vector3(0, 0, 10), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(-5.12f, 0, 0), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(5.1f, 0, 0), Quaternion.identity, 0, null);
		PhotonNetwork.InstantiateSceneObject(ConstantResources.GROUND_LONG, new Vector3(0, -2.9f, 0), Quaternion.identity, 0, null);

		PhotonNetwork.Instantiate(ConstantResources.KID_1, new Vector3(0, 0, 0), Quaternion.identity, 0);
		//PhotonNetwork.Instantiate(ConstantResources.KID_2, new Vector3(0, 0, 0), Quaternion.identity, 0);
	}

	public override void Update () {
		base.Update (); 

		elapsedTimeForObstacles += Time.deltaTime;

		if(elapsedTimeForObstacles >= 5.0f) {
			elapsedTimeForObstacles = 0;
			CreateObstacle();
		}

	}

	public override void Exit () {
		base.Exit ();
	}

	private void CreateObstacle() {

		CreateObstacle1();
	}

	private void CreateObstacle1() {
		PhotonNetwork.InstantiateSceneObject(ConstantResources.ATTACK_BLADE, transformSpawnPointLeft.position, Quaternion.identity, 0, null);
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
