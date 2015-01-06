using UnityEngine;
using UnityEngine.Sprites;
using System;
using System.Collections;

public class MBDWJumper : MBDW_BaseJumper {
	
	private static readonly string TAG = "MBDWJumper";
	
	[Range(-10, 0)] public float gravityUnitsPerSecondSquared 	= -6.05f;
	[Range(1, 10)] public float horizontalSpeedUnitsPerSecond 	= 5.52f;
	[Range(1, 10)] public float jumpVelocityUnitsPerSecond 		= 6.82f;
	
	float velY = 0;

	bool isLookingRight = true;

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
		velY = velY + Time.deltaTime * gravityUnitsPerSecondSquared;
		
		float deltaX = 0;
		float deltaY = 0;

		if(isGravityEnabled) {
			deltaY = (float) (velY * Time.deltaTime + (1.0 / 2.0) * Time.deltaTime * Time.deltaTime * gravityUnitsPerSecondSquared);
		}

		if(isControllable) {
		float horizontalAxis = Input.GetAxis("Horizontal");
			if(Input.GetKey(KeyCode.LeftArrow) && canMoveLeft) { 
				if(horizontalAxis > 0) {
					horizontalAxis = 0;}
				deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;

				if(isLookingRight) {
					FlipLookDirection();
				} 
			}
			if(Input.GetKey(KeyCode.RightArrow) && canMoveRight) { 
				if(horizontalAxis < 0) {
					horizontalAxis = 0;}
				deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;

				if(!isLookingRight) {
					FlipLookDirection();
				}
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

	void FlipLookDirection() {
		isLookingRight = !isLookingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
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

	public class Handler {

		MBDWJumper jumper;

		public Handler(MBDWJumper jumper) {
			this.jumper = jumper;
		}

		public void SetSprite(Sprite newSprite) {
			SpriteRenderer spriteRenderer = jumper.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = newSprite;
		}

		public float getVelY() { return jumper.velY; }

		public void SetGravityEnabled(bool isGravityEnabled) {
			jumper.isGravityEnabled = isGravityEnabled;
		}

		public void SetControllable(bool isControllable) {
			jumper.isControllable = isControllable;
		}

		public void Jump() {
			jumper.velY = jumper.jumpVelocityUnitsPerSecond;
		}
	}
}
