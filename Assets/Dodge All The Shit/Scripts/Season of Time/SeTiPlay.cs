using UnityEngine;
using System.Collections;

public class SeTiPlay : SeTi_Base {

	private static readonly string TAG = "SeTiPlay";
	
	MBTLController controller;

	private SeTiPlay() {
		controller = GuildOfMB.MBP1Controller;
	}

	public override void Enter () {
		base.Enter ();

		controller.actionKeyDownEscape += () => {
			UtilLogger.Log(TAG, "Enter() - actionKeyDownEscape");
		};
	}

	public override void Exit () {
		base.Exit ();

		controller.actionKeyDownEscape += () => {};
	}

	private static SeTiPlay instance;
	public static SeTiPlay Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiPlay();}
			
			return instance;
		}
	}
}
