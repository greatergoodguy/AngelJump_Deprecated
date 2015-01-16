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

}
