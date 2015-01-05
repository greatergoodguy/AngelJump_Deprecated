﻿using UnityEngine;
using System;
using System.Collections;

public class MBDWJumper : MBDW_BaseJumper {
	
	private static readonly string TAG = "MBDWJumper";
	
	private static readonly float GRAVITY_PIXELS_PER_SECOND_SQUARED 	= -98 * 3; 
	private static readonly float HORIZONTAL_SPEED_PIXELS_PER_SECOND 	= 300; 
	private static readonly float JUMP_VELOCITY_PIXELS_PER_SECOND 		= 280; 
	
	float velY = 0;

	bool isLookingLeft = true;

	bool canMoveLeft = true;
	bool canMoveRight = true;

	bool isGravityEnabled = false;
	bool isControllable = false;

	JuSt_Base jumperState = JuStBirth.Instance;

	MBDWJumper.Handler handler;

	void Start () {
		handler = new MBDWJumper.Handler(this);

		jumperState.Enter(handler);
		UtilLogger.Log(TAG, jumperState.GetType().Name + ": Enter");
	}
	
	void Update () {
		jumperState.Update();
		
		if(jumperState.IsFinished()) {
			jumperState.Exit();
			UtilLogger.Log(TAG, jumperState.GetType().Name + ": Exit");
			jumperState = jumperState.GetNextJumperState();
			jumperState.Enter(handler);
			UtilLogger.Log(TAG, jumperState.GetType().Name + ": Enter");
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			Reset();
		}
	}
	
	void FixedUpdate () {
		velY = velY + Time.deltaTime * GRAVITY_PIXELS_PER_SECOND_SQUARED;
		
		float deltaX = 0;
		float deltaY = 0;

		if(isGravityEnabled) {
			deltaY = (float) (velY * Time.deltaTime + (1.0 / 2.0) * Time.deltaTime * Time.deltaTime * GRAVITY_PIXELS_PER_SECOND_SQUARED);
		}

		if(isControllable) {
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
		}
		
		if(deltaX != 0 || deltaY != 0) { 
			transform.Translate(new Vector2(deltaX, deltaY));
			//transform.position += new Vector3(deltaX, deltaY, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.GROUND) {
			SwitchToJumperState(JuStJump.Instance);
		}
	}

	// ========================
	// Public Methods
	// ========================
	public void SwitchToJumperState(JuSt_Base jumperStateNew) {
		jumperState.Exit();
		UtilLogger.Log(TAG, jumperState.GetType().Name + ": Exit");

		jumperState = jumperStateNew;
		jumperState.Enter(handler);
		UtilLogger.Log(TAG, jumperState.GetType().Name + ": Enter");
	}
	
	public void Reset() {
		transform.position = Vector3.zero;
		velY = 0;
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

	public class Handler {

		MBDWJumper jumper;

		public Handler(MBDWJumper jumper) {
			this.jumper = jumper;
		}

		public float getVelY() { return jumper.velY; }

		public void SetGravityEnabled(bool isGravityEnabled) {
			jumper.isGravityEnabled = isGravityEnabled;
		}

		public void SetControllable(bool isControllable) {
			jumper.isControllable = isControllable;
		}

		public void Jump() {
			jumper.velY = JUMP_VELOCITY_PIXELS_PER_SECOND;
		}
	}
}