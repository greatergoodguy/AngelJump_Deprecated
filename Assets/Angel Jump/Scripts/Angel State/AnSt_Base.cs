using UnityEngine;
using System.Collections;

public abstract class AnSt_Base {
	public virtual void Enter(ActorAngel.Handler handler) {}
	public virtual void Update() {}
	public virtual void Exit() {}

	public virtual bool IsFinished() { return false;}
	public virtual AnSt_Base GetNextJumperState() { return AnStMock.Instance;}
}