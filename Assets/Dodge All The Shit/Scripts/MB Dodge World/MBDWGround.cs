using UnityEngine;
using System.Collections;

public class MBDWGround : MBDW_Base {


	void Start() {

	}

	void Update() {
	}

	void FixedUpdate () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Kid") {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			kid.Bounce();
		}
	}
}
