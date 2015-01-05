using UnityEngine;
using System.Collections;

public abstract class JuSt_Base {
	public virtual void Enter(MBDWJumper.Handler handler) {}
	public virtual void Update() {}
	public virtual void Exit() {}

	public virtual bool IsFinished() { return false;}
	public virtual JuSt_Base GetNextJumperState() { return JuStMock.Instance;}
}