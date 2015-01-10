using UnityEngine;
using System.Collections;

public class BadiWhale : MonoBehaviour {

	Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Injure() {
		animator.SetBool("Is Injured", true);
		StartCoroutine(GetCoroutineChangeStateToWalk(1));
	}

	public IEnumerator GetCoroutineChangeStateToWalk(float seconds) {
		yield return new WaitForSeconds(seconds);
		animator.SetBool("Is Injured", false);
	}
}
