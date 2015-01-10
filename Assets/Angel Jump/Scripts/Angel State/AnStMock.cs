using UnityEngine;
using System.Collections;


public class AnStMock : AnSt_Base {

	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);

		handler.SetAnimation(ActorAngel.ANIMATION_MOCK);
	}

	private static AnStMock instance;
	private AnStMock() {}
	public static AnStMock Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStMock();}
			
			return instance;
		}
	}
}

