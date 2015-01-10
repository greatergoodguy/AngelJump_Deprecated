using UnityEngine;
using System.Collections;

public class AnStBirth : AnSt_Base {
	
	private AnStBirth() {}
	
	public override void Enter (ActorAngel.Handler handler) {
		base.Enter(handler);

		handler.SetGravityEnabled(true);
		handler.SetControllable(true);

		handler.SetAnimation(ActorAngel.ANIMATION_BIRTH);
	}

	public override bool IsFinished () {
		return true;
	}

	public override AnSt_Base GetNextJumperState () {
		return AnStAscend.Instance;
	}
	
	private static AnStBirth instance;
	public static AnStBirth Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStBirth();}
			
			return instance;
		}
	}
}