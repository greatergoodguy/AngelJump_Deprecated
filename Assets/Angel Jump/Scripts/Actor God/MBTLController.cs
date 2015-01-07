using UnityEngine;
using System;
using System.Collections;

public class MBTLController : MBTL_Base {

	private static readonly string TAG = "MBTLController";

	void Start() {
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
		}
	
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
		}

	}

	public event Action actionKeyDownEscape = () => {};

}
