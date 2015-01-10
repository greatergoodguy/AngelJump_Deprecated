using UnityEngine;
using System.Collections;

public class SeTiBigBang : SeTi_Base {

	private static readonly string TAG = typeof(SeTiBigBang).Name;

	private SeTiBigBang() {
	}

	public override void Enter () {
		base.Enter ();

		GuildOfMB.GodMainMenu.TurnOff();;
		GuildOfMB.GodDodge.TurnOff();
		GuildOfMB.GodDodgeNetwork.TurnOff();
	}

	public override bool IsFinished () {
		return true;
	}

	public override SeTi_Base GetNextSeason () {
		if (PhotonNetwork.connected) {
			return SeTiDodgeNetwork.Instance;
		}
		else {
			return SeTiMainMenu.Instance;
			//return SeTiDodge.Instance;
		}
	}

	private static SeTiBigBang instance;
	public static SeTiBigBang Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiBigBang();}
			
			return instance;
		}
	}
}
