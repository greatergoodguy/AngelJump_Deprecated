using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class SyncAnimator : Photon.MonoBehaviour {

	Animator animator;
	int animation;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			UtilLogger.Log("SyncAnimator", "OnPhotonSerializeView(): " + animator.GetInteger("Animation"));
			stream.SendNext(animator.GetInteger("Animation"));
		}
		else {
			animation = (int) stream.ReceiveNext();
		}
	}

	void Update() {
		if (!photonView.isMine) {
			animator.SetInteger("Animation", animation);
		}
	}


}
