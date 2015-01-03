using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class MBDWWall : MBDW_Base {

	private static readonly string TAG = "MBDWWall";

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			
			if(IsCollisionFromLeft(other)) 			{ kid.FreezeMoveRight();}
			else if(IsCollisionFromRight(other)) 	{ kid.FreezeMoveLeft();}
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();	
			if(IsCollisionFromLeft(other) || IsCollisionFromRight(other)) { kid.Unfreeze();}
		}
	}

	private bool IsCollisionFromLeft(Collider2D other) {
		if(this.PosX() > other.PosX()) {
			return true;
		}
		else {
			return false;
		}
	}

	private bool IsCollisionFromRight(Collider2D other) {
		if(this.PosX() < other.PosX()) {
			return true;
		}
		else {
			return false;
		}
	}

}
