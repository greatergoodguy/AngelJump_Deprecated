using UnityEngine;
using UnityEngine.Sprites;
using System;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class ActorAngel : Actor_Base {

	public static readonly int ANIMATION_BIRTH 		= 0;
	public static readonly int ANIMATION_JUMP 		= 1;
	public static readonly int ANIMATION_COLLISION 	= 2;
	public static readonly int ANIMATION_FALL 		= 3;
	public static readonly int ANIMATION_ASCEND 	= 4;
	public static readonly int ANIMATION_MOCK 		= -1;
	
	private static readonly string TAG = typeof(ActorAngel).Name;
	
	[Range(-10, 0)] public float gravityUnitsPerSecondSquared 	= -6.05f;
	[Range(1, 10)] public float horizontalSpeedUnitsPerSecond 	= 5.52f;
	[Range(1, 10)] public float jumpSpeedUnitsPerSecond 		= 6.82f;
	[Range(1, 10)] public float bounceSpeedUnitsPerSecond 	= 2.82f;
	[Range(1, 10)] public float recoilSpeedUnitsPerSecond 	= 2.82f;

	float velX = 0;
	float velY = 0;

	bool isLookingRight = true;

	bool canMoveLeft = true;
	bool canMoveRight = true;

	bool isGravityEnabled = false;
	bool isControllable = false;

	AnSt_Base angelState = AnStBirth.Instance;

	ActorAngel.Handler handler;

	Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void Start () {
		handler = new ActorAngel.Handler(this);

		angelState.Enter(handler);
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
	}
	
	void Update () {
		angelState.Update();
		
		if(angelState.IsFinished()) {
			angelState.Exit();
			UtilLogger.Log(TAG, angelState.GetType().Name + ": Exit");
			angelState = angelState.GetNextJumperState();
			angelState.Enter(handler);
			UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
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
			if(canMoveLeft) { 

				if(Input.GetKey(KeyCode.LeftArrow)) {
					if(horizontalAxis > 0) {
						horizontalAxis = 0;}
					deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;
					if(isLookingRight) {
						FlipLookDirection();
					} 
				}
			}
			if(canMoveRight) { 
				if(Input.GetKey(KeyCode.RightArrow)) {
					if(horizontalAxis < 0) {
						horizontalAxis = 0;}
					deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;
					deltaX += velX * Time.deltaTime;
					if(!isLookingRight) {
						FlipLookDirection();
					}
				}
			}
		}

		if(!canMoveLeft && velX < 0) {}
		else if(!canMoveRight && velX > 0) {}
		else {
			deltaX += velX * Time.deltaTime;
		}

		if(deltaX != 0 || deltaY != 0) { 
			transform.Translate(new Vector2(deltaX, deltaY));
			//transform.position += new Vector3(deltaX, deltaY, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.GROUND && angelState != AnStCollision.Instance) {
			SwitchToAngelState(AnStJump.Instance);
		}
		else if(other.tag == ConstantTags.GROUND) {
			Bounce();
		}
		else if(other.tag == ConstantTags.BADI_WHALE) {
			BadiWhale badiWhale = other.GetComponent<BadiWhale>();
			badiWhale.Injure();

			SwitchToAngelState(AnStCollision.Instance);
		}
	}

	void Bounce() {
		velY = bounceSpeedUnitsPerSecond;
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
	public void SwitchToAngelState(AnSt_Base angelStateNew) {
		angelState.Exit();
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Exit");

		angelState = angelStateNew;
		angelState.Enter(handler);
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
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

		ActorAngel angel;

		public Handler(ActorAngel angel) {
			this.angel = angel;
		}

		public void SetAnimation(int animation) {
			angel.animator.SetInteger("Animation", animation);
		}

		public float getVelY() { return angel.velY; }

		public void SetGravityEnabled(bool isGravityEnabled) {
			angel.isGravityEnabled = isGravityEnabled;
		}

		public void SetControllable(bool isControllable) {
			angel.isControllable = isControllable;
		}

		public void Jump() {
			angel.velY = angel.jumpSpeedUnitsPerSecond;
		}

		public void RecoilBegin() {
			if(angel.isLookingRight) {
				angel.velX = -angel.recoilSpeedUnitsPerSecond;}
			else {
				angel.velX = angel.recoilSpeedUnitsPerSecond;}

			angel.velY = angel.velY/2;
		}

		public void RecoilEnd() {
			angel.velX = 0;
		}
	}
}
