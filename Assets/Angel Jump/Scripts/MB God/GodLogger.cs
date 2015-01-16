using UnityEngine;
using System.Collections;

public class GodLogger : God_Base {

	private static readonly string TAG = typeof(GodLogger).Name;

	public bool logAll				= true;
	public bool logMasterScript 	= false;
	public bool logAngel 			= false;

	bool logAllClone;
	bool logMasterScriptClone;
	bool logAngelClone;

	void Awake() {
		logAllClone = logAll;
		logMasterScriptClone = logMasterScript;
		logAngelClone = logAngelClone;

		UtilLogger.SetLoggableAll(logAll);
		UtilLogger.SetLoggableMasterScript(logMasterScript);
		UtilLogger.SetLoggableAngel(logAngel);
	}

	void Update() {
		if(logAllClone != logAll) {
			logAllClone = logAll;
		}

		if(logMasterScriptClone != logMasterScript) {
			logMasterScriptClone = logMasterScript;
			UtilLogger.SetLoggableMasterScript(logMasterScript);
		}

		if(logAngelClone != logAngel) {
			logAngelClone = logAngel;
			UtilLogger.SetLoggableAngel(logAngel);
		}

	}
}
