using UnityEngine;
using System.Collections;

public class ActorDWGround : ActorDW_Base {

	private static readonly string TAG = typeof(ActorDWGround).Name;

	void Start() {

	}

	void Update() {
	}

	void FixedUpdate () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			kid.Bounce();
		}
	}
}
