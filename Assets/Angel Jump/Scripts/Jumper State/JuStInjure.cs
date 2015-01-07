using UnityEngine;
using System.Collections;

public class JuStInjure : JuSt_Base {

	private static readonly float STATE_DURATION_IN_SECONDS = 3;

	ActorDWJumper.Handler handler;

	Sprite spriteStill;

	float elapsedTime;
	bool isFinished;

	private JuStInjure() {
		spriteStill = Resources.Load<Sprite>("Angel Still");
	}

	public override void Enter (ActorDWJumper.Handler handler) {
		base.Enter (handler);
		this.handler = handler;

		handler.SetSprite(spriteStill);
		isFinished = false;
		elapsedTime = 0;
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

	public override JuSt_Base GetNextJumperState () {
		return JuStAscend.Instance;
	}

	private static JuStInjure instance;
	public static JuStInjure Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStInjure();}
			
			return instance;
		}
	}
}
