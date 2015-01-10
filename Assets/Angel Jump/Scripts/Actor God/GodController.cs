using UnityEngine;
using System;
using System.Collections;

public class GodController : God_Base {

	private static readonly string TAG = typeof(GodController).Name;

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
