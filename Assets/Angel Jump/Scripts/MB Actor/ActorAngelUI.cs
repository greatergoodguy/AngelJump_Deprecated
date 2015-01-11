using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActorAngelUI : Actor_Base {

	Text textPoints;

	void Awake() {
		textPoints = transform.FindChild("Points Text").GetComponent<Text>();
	}

	public void UpdatePoints(int points) {
		textPoints.text = points.ToString();
	}
}
