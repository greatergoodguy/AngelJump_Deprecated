using UnityEngine;
using System.Collections;

public class JuStAscend : JuSt_Base {

	Sprite spriteAscend;

	bool isFinished;

	MBDWJumper.Handler handler;

	private JuStAscend() {
		spriteAscend = Resources.Load<Sprite>("Angel Ascend");
	}
	
	public override void Enter (MBDWJumper.Handler handler) {
		base.Enter (handler);
		this.handler = handler;
		isFinished = false;

		handler.SetSprite(spriteAscend);
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

	public override JuSt_Base GetNextJumperState () {
		return JuStFall.Instance;
	}
	
	private static JuStAscend instance;
	public static JuStAscend Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStAscend();}
			
			return instance;
		}
	}
}
