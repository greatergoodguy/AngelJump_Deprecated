using UnityEngine;
using System.Collections;

public abstract class MB_Base : MonoBehaviour {

	private static readonly string TAG = "MB_Base";

	void Start() {
		TurnOn();
	}

	public bool IsOn {
		get {
			return gameObject.activeInHierarchy;
		}
	}

	public void TurnOn() {
		gameObject.SetActive(true);
	}
	
	public void TurnOff() {
		gameObject.SetActive(false);
	}

	public void ToggleOnOff() {
		if(IsOn) {
			TurnOff();
		}
		else {
			TurnOn();
		}
	}
}
