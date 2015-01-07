using UnityEngine;
using System.Collections;

public class GeneSuicide : MonoBehaviour {

	[Range(0, 60)] public float lifeDurationInSeconds = 30.0f;

	float timeElapsed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if(timeElapsed >= lifeDurationInSeconds) {
			Destroy(gameObject);
		}
	}
}
