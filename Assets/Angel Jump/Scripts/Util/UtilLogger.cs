using UnityEngine;
using System.Diagnostics;
using System.Collections;
using System.Reflection;

public static class UtilLogger {

	static bool logAll 			= true;
	static bool logMasterScript = false;
	static bool logAngel 		= false;

	public static void Log(string message) {
		UnityEngine.Debug.Log (message);
	}
	
	public static void Log(string tag, string message) {

		if(tag.StartsWith(typeof(ActorAngel).Name) && !logAngel) {
		}
		if(tag.StartsWith(typeof(ActorAngel).Name)) {
			Log(tag + ": " + message);
		}
		else if(tag.StartsWith(typeof(_MasterScript).Name) && !logMasterScript) {
		}
		else if(tag.StartsWith(typeof(_MasterScript).Name)) {
			Log(tag + ": " + message);
		}
		else if(!logAll) {
		}
		else {
			Log(tag + ": " + message);
		}
	}

	public static void SetLoggableAll(bool isLoggable) {
		logAll = isLoggable;
	}

	public static void SetLoggableMasterScript(bool isLoggable) {
		logMasterScript = isLoggable;
	}

	public static void SetLoggableAngel(bool isLoggable) {
		logAngel = isLoggable;
	}

}