using UnityEngine;
using System.Collections;

public class GuildOfMB {

	private static GodMainMenu godMainMenu;
	public static GodMainMenu GodMainMenu {
		get  { 
			if(godMainMenu == null) {
				godMainMenu = GameObject.Find("Main Menu").GetComponent<GodMainMenu>();
			} 
			return godMainMenu;
		}
	}

	private static GodController godController;
	public static GodController GodController {
		get  { 
			if(godController == null) {
				godController = GameObject.Find("Controller").GetComponent<GodController>();
			} 
			return godController;
		}
	}

	private static GodDodge godDodge;
	public static GodDodge GodDodge {
		get  { 
			if(godDodge == null) {
				godDodge = GameObject.Find("Dodge").GetComponent<GodDodge>();
			} 
			return godDodge;
		}
	}

	private static GodDodgeNetwork godDodgeNetwork;
	public static GodDodgeNetwork GodDodgeNetwork {
		get  { 
			if(godDodgeNetwork == null) {
				godDodgeNetwork = GameObject.Find("Dodge Network").GetComponent<GodDodgeNetwork>();
			} 
			return godDodgeNetwork;
		}
	}

	private static GodMusic godMusic;
	public static GodMusic GodMusic {
		get  { 
			if(godMusic == null) {
				godMusic = GameObject.Find("Music").GetComponent<GodMusic>();
			} 
			return godMusic;
		}
	}

	private static GodPhoton godPhoton;
	public static GodPhoton GodPhoton {
		get  { 
			if(godPhoton == null) {
				godPhoton = GameObject.Find("Photon").GetComponent<GodPhoton>();
			}
			return godPhoton;
		}
	}
}
