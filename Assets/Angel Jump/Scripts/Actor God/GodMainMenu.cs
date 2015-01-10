using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GodMainMenu : God_Base {

	Button mbButtonPlay;
	Button mbButtonOnline;
	Button mbButtonQuit;

	void Start() {

		transform.FindChild("Canvas").gameObject.SetActive(true);

		mbButtonPlay = transform.FindChild("Canvas").FindChild("Play Button").GetComponent<Button>();
		mbButtonPlay.onClick.AddListener(actionPlay.Invoke);

		mbButtonOnline = transform.FindChild("Canvas").FindChild("Online Button").GetComponent<Button>();
		mbButtonOnline.onClick.AddListener(actionOnline.Invoke);

		mbButtonQuit = transform.FindChild("Canvas").FindChild("Quit Button").GetComponent<Button>();
		mbButtonQuit.onClick.AddListener(actionQuit.Invoke);
	}

	void Update() {
	}

	public event Action actionPlay = () => {};
	public event Action actionOnline = () => {};
	public event Action actionQuit = () => {};

}
