using UnityEngine;
using System.Collections;

public class _MasterScript : MonoBehaviour {

	private static readonly string TAG = "_MasterScript";
	
	SeTi_Base seasonOfTime = SeTiBigBang.Instance;
	
	void Start () {
		seasonOfTime.Enter();
		UtilLogger.Log(TAG, seasonOfTime.GetType().Name + ": Enter");
	}
	
	void Update () {
		seasonOfTime.Update();

		if(seasonOfTime.IsFinished()) {
			seasonOfTime.Exit();
			UtilLogger.Log(TAG, seasonOfTime.GetType().Name + ": Exit");
			seasonOfTime = seasonOfTime.GetNextSeason();
			seasonOfTime.Enter();
			UtilLogger.Log(TAG, seasonOfTime.GetType().Name + ": Enter");
		}
	}
}
