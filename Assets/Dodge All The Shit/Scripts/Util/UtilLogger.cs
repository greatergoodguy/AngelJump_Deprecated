using UnityEngine;
using System.Collections;

public static class UtilLogger {

	public static void Log(string tag, string message) {
		Debug.Log (tag + ": " + message);
	}

}