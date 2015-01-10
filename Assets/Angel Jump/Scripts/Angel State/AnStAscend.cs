using UnityEngine;
using System.Collections;

public class AnStAscend : AnSt_Base {

	bool isFinished;

	ActorAngel.Handler handler;

	private AnStAscend() {
	}
	
	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);
		this.handler = handler;
		isFinished = false;

		handler.SetAnimation(ActorAngel.ANIMATION_ASCEND);
	}

	public override void Update () {
		base.Update ();

		if(handler.getVelY() <= 0) {
			isFinished = true;
		}
	}
	
	public override void Exit () {
		base.Exit ();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override AnSt_Base GetNextJumperState () {
		return AnStFall.Instance;
	}
	
	private static AnStAscend instance;
	public static AnStAscend Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStAscend();}
			
			return instance;
		}
	}
}
