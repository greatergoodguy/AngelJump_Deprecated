using UnityEngine;
using System.Collections;

public class JuStFall : JuSt_Base {

	MBDWJumper.Handler handler;

	private JuStFall() {}

	public override void Enter (MBDWJumper.Handler handler) {
		base.Enter (handler);
		this.handler = handler;
	}

	public override void Exit () {
		base.Exit ();

	}

	private static JuStFall instance;
	public static JuStFall Instance {
		get 
		{
			if (instance == null) {
				instance = new JuStFall();}
			
			return instance;
		}
	}
}
