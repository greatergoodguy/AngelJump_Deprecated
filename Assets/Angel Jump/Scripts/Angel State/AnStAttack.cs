using UnityEngine;
using System.Collections;

public class AnStAttack : AnSt_Base {

	private static readonly float STATE_DURATION_IN_SECONDS = 1.0f;

	float elapsedTime;
	bool isFinished;

	public override void Enter (ActorAngel.Handler handler) {
		base.Enter (handler);

		handler.SetAnimation(ActorAngel.ANIMATION_ATTACK);
		handler.Attack();

		elapsedTime = 0;
		isFinished = false;
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
	}

	public override bool IsFinished () {
		return isFinished;
	}

	public override AnSt_Base GetNextAngelState () {
		return AnStAscend.Instance;
	}

	private static AnStAttack instance;
	public static AnStAttack Instance {
		get 
		{
			if (instance == null) {
				instance = new AnStAttack();}
			
			return instance;
		}
	}
}
