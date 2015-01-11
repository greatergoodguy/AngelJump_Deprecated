using UnityEngine;
using System.Collections;

public class GodDodge : God_Base {

	private static readonly string TAG = typeof(GodDodge).Name;

	ActorPauseMenu pauseMenu;
	public ActorPauseMenu PauseMenu {
		get {
			if(pauseMenu == null) {
				pauseMenu = transform.FindChild("Pause Menu").GetComponent<ActorPauseMenu>();
			}

			return pauseMenu;
		}
	}

	ActorAngel angel;
	public ActorAngel Angel {
		get {
			if(angel == null) {
				angel = GetComponentInChildren<ActorAngel>();
			}
			
			return angel;
		}
	}

	void Awake() {
		PauseMenu.TurnOff();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.T)) {
			Angel.ToggleUI();
		}
	}

	public void Reset() {
		Actor_Base[] actors = transform.GetComponentsInChildren<Actor_Base>();
		foreach(Actor_Base actor in actors) {
			actor.Reset();
		}

		Angel.SetOnline(false);
	}
}
