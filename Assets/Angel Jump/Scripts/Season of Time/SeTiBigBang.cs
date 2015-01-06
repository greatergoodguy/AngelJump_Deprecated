using UnityEngine;
using System.Collections;

public class SeTiBigBang : SeTi_Base {

	private static readonly string TAG = typeof(SeTiBigBang).Name;

	private SeTiBigBang() {
	}

	public override void Enter () {
		base.Enter ();

		GuildOfMB.MBTLMainMenu.TurnOff();;
		GuildOfMB.MBTLDodge.TurnOff();
		GuildOfMB.MBTLDodgeNetwork.TurnOff();
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
