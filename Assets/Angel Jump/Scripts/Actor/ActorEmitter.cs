using UnityEngine;
using System.Collections;

public class ActorEmitter : MonoBehaviour {

	public GameObject launchItem;

	[Range(0, 10)] public float cycleLengthInSeconds = 2;
	[Range(0, 10)] public float launchSpeedInUnitsPerSecond = 2;

	float timeElapsed;

	void Awake() {
		if(launchItem == null) {
			launchItem = (GameObject) Resources.Load("Badi Ghost");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if(timeElapsed >= cycleLengthInSeconds) {
			timeElapsed = 0;

			if(launchItem != null) {
				GameObject launchItemClone = (GameObject) Object.Instantiate(launchItem, transform.position, transform.rotation);
				launchItemClone.AddComponent<GeneSuicide>();

				GeneMotionForward geneMotion = launchItemClone.AddComponent<GeneMotionForward>();
				geneMotion.SetVelocity(launchSpeedInUnitsPerSecond);
			}
		}
	}
}
