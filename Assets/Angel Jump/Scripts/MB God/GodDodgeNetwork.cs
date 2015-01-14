using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PhotonView))]
public class GodDodgeNetwork : God_Base {

	PhotonView photonView;

	Transform tDodgeNetworkWorld;

	void Awake() {

		photonView = GetComponent<PhotonView>();
		tDodgeNetworkWorld = transform.FindChild("Dodge Network World");
	}

	public void AddToWorld(GameObject gameObject) {
		gameObject.transform.parent = tDodgeNetworkWorld;
	}

	public void SpawnEnvironment() {
		photonView.RPC("SpawnEnvironment_RPC", PhotonTargets.AllBuffered);
	}

	[RPC]
	void SpawnEnvironment_RPC() {
		AddToWorld(PhotonNetwork.InstantiateSceneObject(ConstantResources.BACKGROUND, new Vector3(0, 0, 10), Quaternion.identity, 0, null));
		AddToWorld(PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(-5.12f, 0, 0), Quaternion.identity, 0, null));
		AddToWorld(PhotonNetwork.InstantiateSceneObject(ConstantResources.WALL, new Vector3(5.1f, 0, 0), Quaternion.identity, 0, null));
		AddToWorld(PhotonNetwork.InstantiateSceneObject(ConstantResources.GROUND_LONG, new Vector3(0, -2.9f, 0), Quaternion.identity, 0, null));
	}

}
