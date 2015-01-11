using UnityEngine;
using System.Collections;

public class GodLogger : God_Base {

	private static readonly string TAG = typeof(GodLogger).Name;

	public bool logMasterScript 	= false;
	public bool logJumper 			= false;

	bool logMasterScriptClone;
	bool logJumperClone;

	void Awake() {
		logMasterScriptClone = logMasterScript;
		logJumperClone = logJumperClone;
	}

	void Update() {
		if(logMasterScriptClone != logMasterScript) {
			logMasterScriptClone = logMasterScript;
			UtilLogger.SetLoggableMasterScript(logMasterScript);
		}

		if(logJumperClone != logJumper) {
			logJumperClone = logJumper;
			UtilLogger.SetLoggableJumper(logJumper);
		}

	}
}
