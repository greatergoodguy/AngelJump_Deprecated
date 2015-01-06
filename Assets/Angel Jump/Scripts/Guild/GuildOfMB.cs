using UnityEngine;
using System.Collections;

public class GuildOfMB {

	private static MBTLMainMenu mbtlMainMenu;
	public static MBTLMainMenu MBTLMainMenu {
		get  { 
			if(mbtlMainMenu == null) {
				mbtlMainMenu = GameObject.Find("Main Menu").GetComponent<MBTLMainMenu>();
			} 
			return mbtlMainMenu;
		}
	}

	private static MBTLController mbtlController;
	public static MBTLController MBTLController {
		get  { 
			if(mbtlController == null) {
				mbtlController = GameObject.Find("Controller").GetComponent<MBTLController>();
			} 
			return mbtlController;
		}
	}

	private static MBTLDodge mbtlDodge;
	public static MBTLDodge MBTLDodge {
		get  { 
			if(mbtlDodge == null) {
				mbtlDodge = GameObject.Find("Dodge").GetComponent<MBTLDodge>();
			} 
			return mbtlDodge;
		}
	}

	private static MBTLDodgeNetwork mbtlDodgeNetwork;
	public static MBTLDodgeNetwork MBTLDodgeNetwork {
		get  { 
			if(mbtlDodgeNetwork == null) {
				mbtlDodgeNetwork = GameObject.Find("Dodge Network").GetComponent<MBTLDodgeNetwork>();
			} 
			return mbtlDodgeNetwork;
		}
	}

	private static MBTLMusic mbtlMusic;
	public static MBTLMusic MBTLMusic {
		get  { 
			if(mbtlMusic == null) {
				mbtlMusic = GameObject.Find("Music").GetComponent<MBTLMusic>();
			} 
			return mbtlMusic;
		}
	}

	private static MBTLPhoton mbtlPhoton;
	public static MBTLPhoton MBTLPhoton {
		get  { 
			if(mbtlPhoton == null) {
				mbtlPhoton = GameObject.Find("Photon").GetComponent<MBTLPhoton>();
			}
			return mbtlPhoton;
		}
	}
}
