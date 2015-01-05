using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class MBDWAttackBlade : MBDW_Base {

	private static readonly float HORIZONTAL_SPEED_PIXELS_PER_SECOND = 150;
	private static readonly float LIFE_DURATION_IN_SECONDS = 10;
	
	float timeElasped = 0;

	void Start () {
	
	}

	void Update () {
		transform.Translate(new Vector2(HORIZONTAL_SPEED_PIXELS_PER_SECOND * Time.deltaTime, 0));

		timeElasped += Time.deltaTime;
		if(timeElasped > LIFE_DURATION_IN_SECONDS) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Kid") {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			kid.Injure();
		}
	}
}
