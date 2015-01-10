using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class ActorDWWall : ActorDW_Base {

	private static readonly string TAG = typeof(ActorDWWall).Name;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();
			
			if(IsCollisionFromLeft(other)) 			{ kid.FreezeMoveRight();}
			else if(IsCollisionFromRight(other)) 	{ kid.FreezeMoveLeft();}
		}

		if(other.tag == ConstantTags.JUMPER) {
			ActorAngel jumper = other.GetComponent<ActorAngel>();	
			
			if(IsCollisionFromLeft(other)) 			{ jumper.FreezeMoveRight();}
			else if(IsCollisionFromRight(other)) 	{ jumper.FreezeMoveLeft();}
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == ConstantTags.KID) {
			MBDWJumperPhoton kid = other.GetComponent<MBDWJumperPhoton>();	
			if(IsCollisionFromLeft(other) || IsCollisionFromRight(other)) { kid.Unfreeze();}
		}

		if(other.tag == ConstantTags.JUMPER) {
			ActorAngel jumper = other.GetComponent<ActorAngel>();	
			if(IsCollisionFromLeft(other) || IsCollisionFromRight(other)) { jumper.Unfreeze();}
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