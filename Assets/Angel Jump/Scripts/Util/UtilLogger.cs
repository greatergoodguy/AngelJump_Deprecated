using UnityEngine;
using System.Diagnostics;
using System.Collections;
using System.Reflection;

public static class UtilLogger {

	static bool logMasterScript = false;
	static bool logAngel = false;

	public static void Log(string message) {
		UnityEngine.Debug.Log (message);
	}
	
	public static void Log(string tag, string message) {

		if(tag.StartsWith(typeof(ActorAngel).Name) && !logAngel) {
		}
		else if(tag.StartsWith(typeof(_MasterScript).Name) && !logMasterScript) {
		}
		else {
			Log(tag + ": " + message);
		}

	}

	public static void SetLoggableMasterScript(bool isLoggable) {
		logMasterScript = isLoggable;
	}

	public static void SetLoggableJumper(bool isLoggable) {
		logAngel = isLoggable;
	}

}