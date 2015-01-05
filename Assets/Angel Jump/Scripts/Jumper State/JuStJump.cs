using UnityEngine;
using System.Collections;

public class JuStJump : JuSt_Base {
		
	private JuStJump() {}
	
	public override void Enter (MBDWJumper.Handler handler) {
		base.Enter (handler);

		handler.Jump();
	}

	public override bool IsFinished () {
		return true;
	}

	public override JuSt_Base GetNextJumperState () {
		return JuStAscend.Instance;
	}
	
	private static JuStJump instance;
	public static JuStJump Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStJump();}
			
			return instance;
		}
	}
}
