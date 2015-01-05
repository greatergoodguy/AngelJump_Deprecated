using UnityEngine;
using System.Collections;

public class GuildOfMB {

	private static MBTLMainMenu mbp1MainMenu;
	public static MBTLMainMenu MBP1MainMenu {
		get  { 
			if(mbp1MainMenu == null) {
				mbp1MainMenu = GameObject.Find("Main Menu").GetComponent<MBTLMainMenu>();
			} 
			return mbp1MainMenu;
		}
	}

	private static MBTLController mbp1Controller;
	public static MBTLController MBP1Controller {
		get  { 
			if(mbp1Controller == null) {
				mbp1Controller = GameObject.Find("Controller").GetComponent<MBTLController>();
			} 
			return mbp1Controller;
		}
	}

	private static MBTLDodge mbp1Dodge;
	public static MBTLDodge MBP1Dodge {
		get  { 
			if(mbp1Dodge == null) {
				mbp1Dodge = GameObject.Find("Dodge").GetComponent<MBTLDodge>();
			} 
			return mbp1Dodge;
		}
	}

	private static MBTLMusic mbp1Music;
	public static MBTLMusic MBP1Music {
		get  { 
			if(mbp1Music == null) {
				mbp1Music = GameObject.Find("Music").GetComponent<MBTLMusic>();
			} 
			return mbp1Music;
		}
	}

	private static MBTLPhoton mbp1Photon;
	public static MBTLPhoton MBP1Photon {
		get  { 
			if(mbp1Photon == null) {
				mbp1Photon = GameObject.Find("Photon").GetComponent<MBTLPhoton>();
			}
			return mbp1Photon;
		}
	}
}
