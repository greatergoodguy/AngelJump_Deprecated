using UnityEngine;
using System.Collections;

public class AnStCollision : AnSt_Base {

	private static readonly float STATE_DURATION_IN_SECONDS = 1.4f;

	ActorAngel.Handler handler;

	float elapsedTime;
	bool isFinished;

	private AnStCollision() {
	}

	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);
		this.handler = handler;

		isFinished = false;
		elapsedTime = 0;

		handler.SetAnimation(ActorAngel.ANIMATION_COLLISION);
		handler.SetControllable(false);
		handler.RecoilBegin();
	}

	public override void Update () {
		base.Update ();
		elapsedTime += Time.deltaTime;
		if(elapsedTime > STATE_DURATION_IN_SECONDS) {
			isFinished = true;
		}
	}

	public override void Exit () {
		base.Exit ();
		handler.SetControllable(true);
		handler.RecoilEnd();
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override AnSt_Base GetNextAngelState () {
		return AnStAscend.Instance;
	}

	private static AnStCollision instance;
	public static AnStCollision Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStCollision();}
			
			return instance;
		}
	}
}
