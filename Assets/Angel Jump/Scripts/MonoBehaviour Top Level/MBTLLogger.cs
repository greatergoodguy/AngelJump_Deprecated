using UnityEngine;
using System.Collections;

public class MBTLLogger : MBTL_Base {

	private static readonly string TAG = typeof(MBTLLogger).Name;

	public bool logMasterScript 	= true;
	public bool logJumper 			= false;

	bool logMasterScriptClone;
	bool logJumperClone;

	void Start() {
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
