using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class MBDWAttackBlade : MBDW_Base {

	private static readonly float HORIZONTAL_SPEED_PIXELS_PER_SECOND = 150;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(HORIZONTAL_SPEED_PIXELS_PER_SECOND * Time.deltaTime, 0));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Kid") {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			kid.Injure();
		}
	}
}
