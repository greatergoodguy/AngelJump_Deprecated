using UnityEngine;
using System.Collections;

public class AnStFall : AnSt_Base {

	ActorAngel.Handler handler;

	private AnStFall() {
	}

	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);
		this.handler = handler;

		handler.SetAnimation(ActorAngel.ANIMATION_FALL);
	}

	public override void Exit () {
		base.Exit ();

	}

	private static AnStFall instance;
	public static AnStFall Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStFall();}
			
			return instance;
		}
	}
}
