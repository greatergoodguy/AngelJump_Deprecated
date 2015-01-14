using UnityEngine;
using System.Collections;

public class GodDodgeNetwork : God_Base {

	Transform tDodgeNetworkWorld;

	void Awake() {
		tDodgeNetworkWorld = transform.FindChild("Dodge Network World");
	}

	public void AddToWorld(GameObject gameObject) {
		gameObject.transform.parent = tDodgeNetworkWorld;
	}
}
