﻿using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

[RequireComponent(typeof(PhotonView))]
public class SyncAngel : Photon.MonoBehaviour
{
	private Vector3 latestCorrectPos;
	private Vector3 onUpdatePos;
	private float fraction;

	private Vector3 angelVisualLatestCorrectPos;
	private Vector3 angelVisualOnUpdate;

	Transform tAngelVisual;

	Animator animator;
	int animation;

	public void Awake() {
		if (photonView.isMine) {
			this.enabled = false;   // due to this, Update() is not called on the owner client.
		}
		
		latestCorrectPos = transform.position;
		onUpdatePos = transform.position;

		tAngelVisual = transform.FindChild("Angel Visual");
		animator = tAngelVisual.GetComponent<Animator>();
	}
	
	/// <summary>
	/// While script is observed (in a PhotonView), this is called by PUN with a stream to write or read.
	/// </summary>
	/// <remarks>
	/// The property stream.isWriting is true for the owner of a PhotonView. This is the only client that
	/// should write into the stream. Others will receive the content written by the owner and can read it.
	/// 
	/// Note: Send only what you actually want to consume/use, too!
	/// Note: If the owner doesn't write something into the stream, PUN won't send anything.
	/// </remarks>
	/// <param name="stream">Read or write stream to pass state of this GameObject (or whatever else).</param>
	/// <param name="info">Some info about the sender of this stream, who is the owner of this PhotonView (and GameObject).</param>
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 pos = transform.localPosition;
			Quaternion rot = tAngelVisual.localRotation;
			stream.Serialize(ref pos);
			stream.Serialize(ref rot);

			stream.SendNext(animator.GetInteger("Animation"));
		}
		else
		{
			// Receive latest state information
			Vector3 pos = Vector3.zero;
			Quaternion rot = Quaternion.identity;
			
			stream.Serialize(ref pos);
			stream.Serialize(ref rot);
			
			latestCorrectPos = pos;                 // save this to move towards it in FixedUpdate()
			onUpdatePos = transform.localPosition;  // we interpolate from here to latestCorrectPos
			fraction = 0;                           // reset the fraction we alreay moved. see Update()
			
			tAngelVisual.localRotation = rot;          // this sample doesn't smooth rotation

			animation = (int) stream.ReceiveNext();
		}
	}
	
	public void Update()
	{
		// We get 10 updates per sec. sometimes a few less or one or two more, depending on variation of lag.
		// Due to that we want to reach the correct position in a little over 100ms. This way, we usually avoid a stop.
		// Lerp() gets a fraction value between 0 and 1. This is how far we went from A to B.
		//
		// Our fraction variable would reach 1 in 100ms if we multiply deltaTime by 10.
		// We want it to take a bit longer, so we multiply with 9 instead.
		
		fraction = fraction + Time.deltaTime * 9;
		transform.localPosition = Vector3.Lerp(onUpdatePos, latestCorrectPos, fraction);    // set our pos between A and B


	}
}
