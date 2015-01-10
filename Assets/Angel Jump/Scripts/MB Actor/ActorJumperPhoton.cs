using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class ActorJumperPhoton : Actor_Base {

	private static readonly string TAG = "MBDWJumperPhoton";

	[Range(-10, 0)] public float gravityUnitsPerSecondSquared 	= -6.05f;
	[Range(1, 10)] public float horizontalSpeedUnitsPerSecond 	= 5.52f;
	[Range(1, 10)] public float jumpVelocityUnitsPerSecond 		= 6.82f;

	float velY = 0;

	private bool canMoveLeft = true;
	private bool canMoveRight = true;

	PhotonView photonView;

	void Start () {
		photonView = GetComponent<PhotonView>();
	}

	void Update () {
		if(photonView.isMine) {
			if(Input.GetKeyDown(KeyCode.Escape)) {
				Reset();
			}
		}
	}

	void FixedUpdate () {
		velY = velY + Time.deltaTime * gravityUnitsPerSecondSquared;

		float deltaX = 0;
		float deltaY = (float) (velY * Time.deltaTime + (1.0 / 2.0) * Time.deltaTime * Time.deltaTime * gravityUnitsPerSecondSquared);

		float horizontalAxis = Input.GetAxis("Horizontal");

		if(photonView.isMine) {
			if(Input.GetKey(KeyCode.LeftArrow) && canMoveLeft) { 
				if(horizontalAxis > 0) {
					horizontalAxis = 0;}
				deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;
			}
			if(Input.GetKey(KeyCode.RightArrow) && canMoveRight) { 
				if(horizontalAxis < 0) {
					horizontalAxis = 0;}
				deltaX = horizontalSpeedUnitsPerSecond * Time.deltaTime * horizontalAxis;
			}
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
		velY = jumpVelocityUnitsPerSecond;
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
