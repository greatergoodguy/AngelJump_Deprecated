using UnityEngine;
using System.Collections;

public class MBDWJumper : MBDW_Base {
	
	private static readonly string TAG = "MBDWJumper";
	
	private static readonly float GRAVITY_PIXELS_PER_SECOND_SQUARED = -98 * 3; 
	private static readonly float HORIZONTAL_SPEED_PIXELS_PER_SECOND = 300; 
	
	float velY = 0;
	float bounceVel = 0;
	
	private bool canMoveLeft = true;
	private bool canMoveRight = true;

	void Start () {
		BounceMode3();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			BounceMode1();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)) {
			BounceMode2();
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3)) {
			BounceMode3();
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Reset();
		}
	}
	
	void BounceMode1() {
		bounceVel = 100;
	}
	
	void BounceMode2() {
		bounceVel = 140;
	}
	
	void BounceMode3() {
		bounceVel = 280;
	}
	
	void FixedUpdate () {
		velY = velY + Time.deltaTime * GRAVITY_PIXELS_PER_SECOND_SQUARED;
		
		float deltaX = 0;
		float deltaY = (float) (velY * Time.deltaTime + (1.0 / 2.0) * Time.deltaTime * Time.deltaTime * GRAVITY_PIXELS_PER_SECOND_SQUARED);
		
		float horizontalAxis = Input.GetAxis("Horizontal");

		if(Input.GetKey(KeyCode.LeftArrow) && canMoveLeft) { 
			if(horizontalAxis > 0) {
				horizontalAxis = 0;}
			deltaX = HORIZONTAL_SPEED_PIXELS_PER_SECOND * Time.deltaTime * horizontalAxis;
		}
		if(Input.GetKey(KeyCode.RightArrow) && canMoveRight) { 
			if(horizontalAxis < 0) {
				horizontalAxis = 0;}
			deltaX = HORIZONTAL_SPEED_PIXELS_PER_SECOND * Time.deltaTime * horizontalAxis;
		}
		
		if(deltaX != 0 || deltaY != 0) { 
			transform.Translate(new Vector2(deltaX, deltaY));
			//transform.position += new Vector3(deltaX, deltaY, 0);
		}
	}
	
	public void Reset() {
		transform.position = Vector3.zero;
		velY = 0;
	}
	
	public void Bounce() {
		velY = bounceVel;
	}
	
	public void FreezeMoveLeft() {
		canMoveLeft = false;
	}
	
	public void FreezeMoveRight() {
		canMoveRight = false;
	}
	
	public void Unfreeze() {
		canMoveLeft = true;
		canMoveRight = true;
	}
	
	public void Injure() {
		velY = 30;
	}
}
