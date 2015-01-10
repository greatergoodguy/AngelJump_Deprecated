using UnityEngine;
using System.Collections;

public class ActorEmitter : MonoBehaviour {

	public enum LaunchItem {
		badiGhost,
		attackBlade,
		none
	}
	
	private void SetLaunchItem() {
		switch(launchItem) {
		case LaunchItem.badiGhost:
			goLaunchItem = (GameObject) Resources.Load("Badi Ghost");
			break;
		case LaunchItem.attackBlade:
			goLaunchItem = (GameObject) Resources.Load("Attack Blade");
			break;
		case LaunchItem.none:
			break;
		}
	}

	public LaunchItem launchItem = LaunchItem.badiGhost;
	LaunchItem launchItemPoser;

	private GameObject goLaunchItem;

	[Range(0, 10)] public float cycleLengthInSeconds = 2;
	[Range(0, 10)] public float launchSpeedInUnitsPerSecond = 2;

	float timeElapsed;

	void Awake() {
		launchItemPoser = launchItem;
		SetLaunchItem();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(launchItemPoser != launchItem) {
			SetLaunchItem();
			launchItemPoser = launchItem;
		}

		timeElapsed += Time.deltaTime;

		if(timeElapsed >= cycleLengthInSeconds) {
			timeElapsed = 0;

			if(goLaunchItem != null) {
				GameObject goLaunchItemClone = (GameObject) Object.Instantiate(goLaunchItem, transform.position, transform.rotation);
				goLaunchItemClone.AddComponent<GeneSuicide>();

				GeneMotionForward geneMotion = goLaunchItemClone.AddComponent<GeneMotionForward>();
				geneMotion.SetVelocity(launchSpeedInUnitsPerSecond);

				if(transform.parent != null) {
					goLaunchItemClone.transform.parent = transform.parent;
				}
			}
		}
	}
}
