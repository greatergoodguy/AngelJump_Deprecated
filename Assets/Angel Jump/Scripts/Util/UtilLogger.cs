using UnityEngine;
using System.Diagnostics;
using System.Collections;
using System.Reflection;

public static class UtilLogger {

	static bool logMasterScript = true;
	static bool logJumper = false;

	public static void Log(string message) {
		StackFrame frame = new StackFrame(1);
		MethodBase method = frame.GetMethod();
		Log(method.DeclaringType.FullName, message);
	}
	
	public static void Log(string tag, string message) {
		if(tag == "ActorDWJumper" && !logJumper) {
			return;}

		if(tag == "_MasterScript" && !logMasterScript) {
			return;}

		UnityEngine.Debug.Log (tag + ": " + message);
	}

	public static void SetLoggableMasterScript(bool isLoggable) {
		logMasterScript = isLoggable;
	}

	public static void SetLoggableJumper(bool isLoggable) {
		logJumper = isLoggable;
	}

}