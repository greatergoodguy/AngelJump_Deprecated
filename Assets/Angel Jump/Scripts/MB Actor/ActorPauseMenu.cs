using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ActorPauseMenu : Actor_Base {

	// Use this for initialization
	void Start () {
		transform.FindChild("Canvas").gameObject.SetActive(true);

		Button mbButtonPlay = transform.FindChild("Canvas/Resume Button").GetComponent<Button>();
		mbButtonPlay.onClick.AddListener(actionResume.Invoke);
		
		Button mbButtonOnline = transform.FindChild("Canvas/Quit Button").GetComponent<Button>();
		mbButtonOnline.onClick.AddListener(actionQuit.Invoke);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public event Action actionResume = () => {};
	public event Action actionQuit = () => {};
}
