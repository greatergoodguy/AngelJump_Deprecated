using UnityEngine;
using System.Collections;

public class SeTiDodgeNetworkClient : SeTi_Base {
	
	private static readonly string TAG = "SeTiDodgeNetworkClient";
	
	
	private SeTiDodgeNetworkClient() {
	}
	
	public override void Enter () {
		base.Enter ();

		PhotonNetwork.Instantiate(ConstantResources.ANGEL, new Vector3(0, 0, 0), Quaternion.identity, 0);
	}
	
	public override void Exit () {
		base.Exit ();
	}
	
	private static SeTiDodgeNetworkClient instance;
	public static SeTiDodgeNetworkClient Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiDodgeNetworkClient();}
			
			return instance;
		}
	}
}
