using UnityEngine;
using System.Collections;

public class SeTiMainMenu : SeTi_Base {

	bool isFinished;
	SeTi_Base nextSeTi = SeTiMock.Instance;

	MBTLMainMenu mainMenu;
	MBTLPhoton photon;

	private SeTiMainMenu() {
		mainMenu = GuildOfMB.MBP1MainMenu;
		mainMenu.TurnOn();

		photon = GuildOfMB.MBP1Photon;
	}

	public override void Enter () {
		base.Enter ();

		isFinished = false;

		mainMenu.actionPlay += () => {
			isFinished = true;
			nextSeTi = SeTiDodge.Instance;
		};

		mainMenu.actionOnline += () => {
			photon.StartOnlineGame();
		};

		mainMenu.actionQuit += () => {
			Application.Quit();
		};

		photon.actionRoomJoined += () => {
			isFinished = true;
			nextSeTi = SeTiDodgeNetwork.Instance;
		};
	}

	public override void Exit () {
		base.Exit ();

		mainMenu.actionPlay += () => {};
		mainMenu.actionOnline += () => {};
		mainMenu.actionQuit += () => {};
		mainMenu.TurnOff();

		photon.actionRoomJoined += () => {};
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
		return nextSeTi;
	}

	private static SeTiMainMenu instance;
	public static SeTiMainMenu Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiMainMenu();}
			
			return instance;
		}
	}
}