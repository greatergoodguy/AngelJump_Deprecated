using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GodMainMenu : God_Base {
	
	void Start() {

		transform.FindChild("Canvas").gameObject.SetActive(true);

		Button mbButtonPlay = transform.FindChild("Canvas/Play Button").GetComponent<Button>();
		mbButtonPlay.onClick.AddListener(actionPlay.Invoke);

		Button mbButtonOnline = transform.FindChild("Canvas/Online Button").GetComponent<Button>();
		mbButtonOnline.onClick.AddListener(actionOnline.Invoke);

		Button mbButtonQuit = transform.FindChild("Canvas").FindChild("Quit Button").GetComponent<Button>();
		mbButtonQuit.onClick.AddListener(actionQuit.Invoke);
	}

	void Update() {
	}

	public event Action actionPlay = () => {};
	public event Action actionOnline = () => {};
	public event Action actionQuit = () => {};

}
