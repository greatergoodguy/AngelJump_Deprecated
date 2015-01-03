using UnityEngine;
using System.Collections;

public class MBP2Hero : MB_Base {

	const string TAG = "MBP2Hero";

	void Start () {

	}

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Joystick1Button16)) {
			UtilLogger.Log(TAG, "A");
		}



	}
}
