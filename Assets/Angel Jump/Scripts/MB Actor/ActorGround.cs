using UnityEngine;
using System.Collections;

public class ActorGround : Actor_Base {

	private static readonly string TAG = typeof(ActorGround).Name;

	void Start() {

	}

	void Update() {
	}

	void FixedUpdate () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			ActorJumperPhoton kid = other.GetComponent<ActorJumperPhoton>();
			kid.Bounce();
		}
	}
}
