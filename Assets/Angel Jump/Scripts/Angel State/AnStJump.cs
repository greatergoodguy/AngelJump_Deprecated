using UnityEngine;
using System.Collections;

public class AnStJump : AnSt_Base {
		
	private AnStJump() {}
	
	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);

		handler.Jump();
		handler.SetAnimation(ActorAngel.ANIMATION_JUMP);
	}

	public override bool IsFinished () {
		return true;
	}

	public override AnSt_Base GetNextAngelState () {
		return AnStAscend.Instance;
	}
	
	private static AnStJump instance;
	public static AnStJump Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStJump();}
			
			return instance;
		}
	}
}
