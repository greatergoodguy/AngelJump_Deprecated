using UnityEngine;
using System.Collections;

public class GodMusic : God_Base {

	private AudioSource bgm;
	
	void Start () {
		bgm = transform.GetComponent<AudioSource>();
	}

	public void BGM_Play() {
		bgm.Play();
	}

	public void BGM_Stop() {
		bgm.Stop();
	}
}
