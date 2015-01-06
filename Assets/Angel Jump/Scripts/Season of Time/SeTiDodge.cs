using UnityEngine;
using System.Collections;

public class SeTiDodge : SeTi_Base {

	private static readonly string TAG = "SeTiDodge";

	MBTLMusic mbp1Music;

	GameObject goPlayer;

	private SeTiDodge() {
		mbp1Music = GuildOfMB.MBTLMusic;
	}

	public override void Enter () {
		base.Enter ();

		GuildOfMB.MBTLDodge.TurnOn();

		string playerAngelString = ConstantResources.JUMPER_ANGEL;
		goPlayer = (GameObject) Object.Instantiate(Resources.Load(playerAngelString), Vector3.zero, Quaternion.identity);
	}

	public override void Exit () {
		base.Exit ();

		GameObject.Destroy(goPlayer);
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
