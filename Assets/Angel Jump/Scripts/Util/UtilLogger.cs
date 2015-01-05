using UnityEngine;
using System.Collections;

public static class UtilLogger {

	static bool logMasterScript = true;
	static bool logJumper = false;

	public static void Log(string tag, string message) {
		if(tag == "MBDWJumper" && !logJumper) {
			return;}

		if(tag == "_MasterScript" && !logMasterScript) {
			return;}

		Debug.Log (tag + ": " + message);
	}

	public static void SetLoggableMasterScript(bool isLoggable) {
		logMasterScript = isLoggable;
	}

	public static void SetLoggableJumper(bool isLoggable) {
		logJumper = isLoggable;
	}

}