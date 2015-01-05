using UnityEngine;
using System.Collections;

public abstract class SeTi_Base {

	public virtual void Enter() {}
	public virtual void Update() {}
	public virtual void Exit() {}

	public virtual bool IsFinished() { return false;}
	public virtual SeTi_Base GetNextSeason() { return SeTiMock.Instance;}
	
}