using UnityEngine;
using System;
using System.Collections;

public class GodPhoton : God_Base {

	private static readonly string TAG = typeof(GodPhoton).Name;

	private static readonly string ROOM_NAME = "Angel Jump";
	
	public static bool isConnectedToPhoton {
		get; private set;
	}

	void Awake() {
		PhotonNetwork.ConnectUsingSettings("v1.0");
	}

	public void StartOnlineGame() {
		PhotonNetwork.CreateRoom(ROOM_NAME);
	}

	public void OnConnectedToPhoton() {
		UtilLogger.Log(TAG, "OnConnectedToPhoton()");
		isConnectedToPhoton = true;
	}

	public void OnFailedToConnectToPhoton() {
		UtilLogger.Log(TAG, "OnFailedToConnectToPhoton()");
		isConnectedToPhoton = false;
	}

	public void OnCreatedRoom() {
		UtilLogger.Log(TAG, "OnCreatedRoom()");
	}

	public void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
		UtilLogger.Log(TAG, "OnPhotonCreateRoomFailed()");

		if(codeAndMsg.Length == 1) {
			int errorCode = (int) codeAndMsg[0];
			UtilLogger.Log(TAG, "OnPhotonCreateRoomFailed(): " + errorCode);
		}
		if(codeAndMsg.Length == 2) {
			int errorCode = (int) codeAndMsg[0];
			string debugMessage = (string) codeAndMsg[1];
			UtilLogger.Log(TAG, "OnPhotonCreateRoomFailed(): " + errorCode + ", " + debugMessage);
		}

		PhotonNetwork.JoinRoom(ROOM_NAME);
	}

	public void OnJoinedRoom() {
		UtilLogger.Log(TAG, "OnJoinedRoom()");
		actionRoomJoined();
	}

	public void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
		UtilLogger.Log(TAG, "OnPhotonJoinRoomFailed()");
		
		if(codeAndMsg.Length == 1) {
			int errorCode = (int) codeAndMsg[0];
			UtilLogger.Log(TAG, "OnPhotonJoinRoomFailed(): " + errorCode);
		}
		if(codeAndMsg.Length == 2) {
			int errorCode = (int) codeAndMsg[0];
			string debugMessage = (string) codeAndMsg[1];
			UtilLogger.Log(TAG, "OnPhotonJoinRoomFailed(): " + errorCode + ", " + debugMessage);
		}
	}

	public event Action actionRoomJoined = () => {};
}
