﻿using UnityEngine;
using System.Collections;

public class SeTiDodgeNetworkClient : SeTi_Base {
	
	private static readonly string TAG = "SeTiDodgeNetworkClient";
	
	
	private SeTiDodgeNetworkClient() {
	}
	
	public override void Enter () {
		base.Enter ();

		GameObject goKid = PhotonNetwork.Instantiate("Kid 2", new Vector3(10, -92, 0), Quaternion.identity, 0);
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