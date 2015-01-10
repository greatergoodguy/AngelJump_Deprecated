using UnityEngine;
using System.Collections;

public class SeTiDodge : SeTi_Base {

	private static readonly string TAG = typeof(SeTiDodge).Name;

	GodDodge godDodge;
	GodMusic godMusic;

	bool isPaused;
	bool isFinished;

	private SeTiDodge() {
		godDodge = GuildOfMB.GodDodge;
		godMusic = GuildOfMB.GodMusic;
	}

	public override void Enter () {
		base.Enter ();

		godDodge.TurnOn();
		godDodge.Reset();
		godDodge.PauseMenu.TurnOff();

		godDodge.PauseMenu.actionResume += () => {
			TogglePauseMenu();
		};
		
		godDodge.PauseMenu.actionQuit += () => {
			isFinished = true;
		};

		isFinished = false;
	}

	public override void Update () {
		base.Update ();

		if(Input.GetKeyDown(KeyCode.Escape)) {
			TogglePauseMenu();
		}
	}

	void TogglePauseMenu() {
		godDodge.PauseMenu.ToggleOnOff();
		if(godDodge.PauseMenu.IsOn) {
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
		}
	}

	public override void Exit () {
		base.Exit ();

		godDodge.PauseMenu.actionResume += () => {};
		godDodge.PauseMenu.actionQuit += () => {};

		Time.timeScale = 1;

		GuildOfMB.GodDodge.TurnOff();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
		return SeTiMainMenu.Instance;
	}

	private static SeTiDodge instance;
	public static SeTiDodge Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiDodge();}
			
			return instance;
		}
	}

}
