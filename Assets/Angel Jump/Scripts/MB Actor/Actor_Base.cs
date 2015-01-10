using UnityEngine;
using System.Collections;

public abstract class Actor_Base : MonoBehaviour {
	
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

	public virtual void Reset() {

	}
}
