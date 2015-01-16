using UnityEngine;
using UnityEngine.Sprites;
using System;
using System.Collections;

[RequireComponent (typeof (PhotonView))]
[RequireComponent (typeof (SyncAngel))]
public class ActorAngel : Actor_Base {

	public static readonly int ANIMATION_BIRTH 		= 0;
	public static readonly int ANIMATION_JUMP 		= 1;
	public static readonly int ANIMATION_COLLISION 	= 2;
	public static readonly int ANIMATION_FALL 		= 3;
	public static readonly int ANIMATION_ASCEND 	= 4;
	public static readonly int ANIMATION_ATTACK 	= 5;
	public static readonly int ANIMATION_MOCK 		= -1;
	
	private static readonly string TAG = typeof(ActorAngel).Name;

	[Range(-10, 0)] public float gravityUnitsPerSecondSquared 		= -6.05f;
	[Range(1, 10)] public float horizontalSpeedUnitsPerSecond 		= 5.52f;
	[Range(1, 10)] public float jumpSpeedUnitsPerSecond 			= 6.82f;
	[Range(1, 10)] public float bounceCollisionSpeedUnitsPerSecond 	= 2.82f;
	[Range(1, 10)] public float bounceAttackSpeedUnitsPerSecond 	= 5.82f;
	[Range(1, 10)] public float recoilSpeedUnitsPerSecond 			= 2.82f;

	public bool IsControllable {
		get {
			if(isOnline) {
				return isControllableInput && photonView.isMine;
			}
			else {
				return isControllableInput;
			}
		}
	}

	public bool IsOnlineButOwnerIsOther {
		get {
			return isOnline && !photonView.isMine;
		}
	}

	public bool isOnline;

	int points = 0;

	float velX = 0;
	float velY = 0;
//	if(logMasterScriptClone != logMasterScript) {
//		logMasterScriptClone = logMasterScript;
//		UtilLogger.SetLoggableMasterScript(logMasterScript);
//	}

	bool isLookingRight = true;

	bool canMoveLeft = true;
	bool canMoveRight = true;

	bool isGravityEnabled = false;
	bool isControllableInput = false;

	AnSt_Base angelState = AnStBirth.Instance;

	ActorAngel.Handler handler;

	ActorAngelVisual angelVisual;
	ActorAngelUI angelUI;

	PhotonView photonView;
	Animator animator;
	SyncAngel syncAngel;

	void Awake() {
		angelVisual = transform.FindChild("Angel Visual").GetComponent<ActorAngelVisual>();
		angelUI = transform.FindChild("Angel UI").GetComponent<ActorAngelUI>();

		photonView = GetComponent<PhotonView>();
		animator = angelVisual.GetComponent<Animator>();
		syncAngel = GetComponent<SyncAngel>();

	}

	void Start () {
		handler = new ActorAngel.Handler(this);

		angelState.Enter(handler);
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
	}
	
	void Update () {
		if(IsOnlineButOwnerIsOther) {
			return;
		}

		UtilLogger.Log(TAG, "Update() - IsOnlineButOwnerIsOther: " + IsOnlineButOwnerIsOther);
//		UtilLogger.Log(TAG, "Update() - photonView.isMine: " + photonView.isMine);

		angelState.Update();
		
		if(angelState.IsFinished()) {
			angelState.Exit();
			UtilLogger.Log(TAG, angelState.GetType().Name + ": Exit");
			angelState = angelState.GetNextAngelState();
			angelState.Enter(handler);
			UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
		}

		if(Input.GetKeyDown(KeyCode.Space) && IsControllable) {
			SwitchToAngelState(AnStAttack.Instance);
		}
	}
	
	void FixedUpdate ()  {
		if(IsOnlineButOwnerIsOther) {
			return;
		}

		velY = velY + Time.deltaTime * gravityUnitsPerSecondSquared;
		
		float deltaX = 0;
		float deltaY = 0;
		
		if(isGravityEnabled) {
			deltaY = (float) (velY * Time.deltaTime + (1.0 / 2.0) * Time.deltaTime * Time.deltaTime * gravityUnitsPerSecondSquared);
		}
		
		if(IsControllable) {
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
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == ConstantTags.GROUND && angelState == AnStFall.Instance) {
			SwitchToAngelState(AnStJump.Instance);
		}
		else if(other.tag == ConstantTags.GROUND && angelState == AnStAttack.Instance) {
			//velY = bounceAttackSpeedUnitsPerSecond;
			handler.Jump();
		}
		else if(other.tag == ConstantTags.GROUND) {
			Bounce();
		}
		else if(other.tag == ConstantTags.COIN) {
			points += 10;

			ActorCoin coin = other.GetComponent<ActorCoin>();
			coin.Destroy();

			angelUI.UpdatePoints(points);
		}
		else if(other.tag == ConstantTags.BADI_WHALE) {
			BadiWhale badiWhale = other.GetComponent<BadiWhale>();
			badiWhale.Injure();

			SwitchToAngelState(AnStCollision.Instance);
		}
	}

	void Bounce() {
		velY = bounceCollisionSpeedUnitsPerSecond;
	}

	void FlipLookDirection() {
		isLookingRight = !isLookingRight;

		Vector3 theScale = angelVisual.transform.localScale;
		theScale.x *= -1;
		angelVisual.transform.localScale = theScale;
	}

	// ========================
	// Public Methods
	// ========================
	public override void Reset() {
		
		AnSt_Base angelState = AnStBirth.Instance;
		
		transform.position = Vector3.zero;
		velX = 0;
		velY = 0;
	}

	public void SwitchToAngelState(AnSt_Base angelStateNew) {
		angelState.Exit();
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Exit");

		angelState = angelStateNew;
		angelState.Enter(handler);
		UtilLogger.Log(TAG, angelState.GetType().Name + ": Enter");
	}

	public void ToggleUI() {
		angelUI.ToggleOnOff();
	}

	public void SetOnline(bool isOnline) {
		this.isOnline = isOnline;

		syncAngel.enabled = isOnline;
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

		public void SetControllableInput(bool isControllableInput) {
			angel.isControllableInput = isControllableInput;
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

		public void Attack() {
		}

		public void ShootAttackBlade() {

		}
	}
}
