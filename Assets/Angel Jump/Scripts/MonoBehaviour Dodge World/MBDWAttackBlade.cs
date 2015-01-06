using UnityEngine;
using System.Collections;

public class MBDWAttackBlade : MBDW_Base {

	private static readonly string TAG = typeof(MBDWAttackBlade).Name;

	[Range(0, 10)] public float horizontalSpeedUnitsPerSecond = 1.5f;
	[Range(1, 100)] public float lifeDurationInSeconds = 10;
	
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
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			kid.Injure();
		}

		if(other.tag == ConstantTags.JUMPER) {
			MBDWJumper jumper = other.GetComponent<MBDWJumper>();
		}
	}
}
