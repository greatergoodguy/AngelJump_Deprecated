using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class MBDWAttackBlade : MBDW_Base {

	private static readonly float horizontalSpeedUnitsPerSecond = 1.5f;
	private static readonly float lifeDurationInSeconds = 10;
	
	float timeElasped = 0;

	void Start () {
	
	}

	void Update () {
		transform.Translate(new Vector2(horizontalSpeedUnitsPerSecond * Time.deltaTime, 0));

		timeElasped += Time.deltaTime;
		if(timeElasped > lifeDurationInSeconds) {
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
