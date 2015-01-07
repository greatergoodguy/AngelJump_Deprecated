using UnityEngine;
using System.Collections;

public class JuStBirth : JuSt_Base {
	
	private JuStBirth() {}
	
	public override void Enter (ActorDWJumper.Handler handler) {
		base.Enter(handler);

		handler.SetGravityEnabled(true);
		handler.SetControllable(true);
	}

	public override bool IsFinished () {
		return true;
	}

	public override JuSt_Base GetNextJumperState () {
		return JuStAscend.Instance;
	}
	
	private static JuStBirth instance;
	public static JuStBirth Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStBirth();}
			
			return instance;
		}
	}
}
