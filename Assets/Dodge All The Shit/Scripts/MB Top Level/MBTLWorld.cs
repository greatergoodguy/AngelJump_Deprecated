using UnityEngine;
using System.Collections;

public class MBTLWorld : MBTL_Base {

	MBP2Menu mbp2Menu;
	public MBP2Menu MBP2Menu {
		get {
			return mbp2Menu;
		}
	}

	void Start () {
		transform.FindChild("Continent").gameObject.SetActive(true);

		mbp2Menu = transform.FindChild("Continent").FindChild("Menu").gameObject.GetComponent<MBP2Menu>();
	}

	void Update () {
	}

}
