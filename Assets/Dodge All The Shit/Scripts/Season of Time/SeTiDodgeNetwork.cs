using UnityEngine;
using System.Collections;

public class SeTiDodgeNetwork : SeTi_Base {
	
	private static readonly string TAG = "SeTiDodgeNetwork";
	
	MBTLMusic mbp1Music;

	bool isFinished = false;
	SeTi_Base nextSeti = SeTiMock.Instance;
	
	private SeTiDodgeNetwork() {
		mbp1Music = GuildOfMB.MBP1Music;
	}
	
	public override void Enter () {
		base.Enter ();
	
		if(PhotonNetwork.isMasterClient) {
			UtilLogger.Log(TAG, "Enter(): " + "Master");
			isFinished = true;
			nextSeti = SeTiDodgeNetworkMaster.Instance;
		}
		else {
			UtilLogger.Log(TAG, "Enter(): " + "Client");
			isFinished = true;
			nextSeti = SeTiDodgeNetworkClient.Instance;
		}

		//mbp1Music.BGM_Play();
	}
	
	public override void Exit () {
		base.Exit ();
		
		//mbp1Music.BGM_Stop();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override SeTi_Base GetNextSeason () {
		return nextSeti;
	}
	
	private static SeTiDodgeNetwork instance;
	public static SeTiDodgeNetwork Instance {
		get 
		{
			if (instance == null) {
				instance = new SeTiDodgeNetwork();}
			
			return instance;
		}
	}

}
