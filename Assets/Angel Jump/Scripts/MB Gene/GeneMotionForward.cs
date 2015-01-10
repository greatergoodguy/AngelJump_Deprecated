using UnityEngine;
using System.Collections;

public class GeneMotionForward : MonoBehaviour {

	private static readonly string TAG = typeof(GeneMotionForward).Name;
	
	[Range(0, 5)] public float horizontalSpeedUnitsPerSecond = 1.5f;

	void Start () {
		
	}
	
	void Update () {
		transform.Translate(new Vector2(horizontalSpeedUnitsPerSecond * Time.deltaTime, 0));
	}

	public void SetVelocity(float speedInUnitsPerSecond) {
		horizontalSpeedUnitsPerSecond = speedInUnitsPerSecond;
	}
}
