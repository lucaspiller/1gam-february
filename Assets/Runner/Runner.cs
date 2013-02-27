using UnityEngine;

public class Runner : MonoBehaviour {
	public static float distanceTraveled;
	public float acceleration;
	public Vector3 jumpVelocity;
	public float minVelocityX;
	public float gameOverY;
	public ParticleSystem particles;
	private bool touchingPlatform;
	private Vector3 startPosition;
	
	void Start () {
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		gameObject.active = false;
	}

	void Update () {
		if (touchingPlatform) {
			if (Input.GetButtonDown("Jump")) {
				rigidbody.AddForce(jumpVelocity, ForceMode.VelocityChange);
				touchingPlatform = false;
			}
		} else {
			if (Input.GetButtonDown("Jump")) {
				rigidbody.AddForce(0f, 1f, 0f, ForceMode.VelocityChange);
			}
			if (rigidbody.velocity.x < minVelocityX) {
				rigidbody.AddForce(minVelocityX, 0f, 0f, ForceMode.VelocityChange);
			}
		}
		
		distanceTraveled = transform.localPosition.x;
		ScoreManager.SetDistance(distanceTraveled);
		
		if(transform.localPosition.y < gameOverY){
			GameEventManager.TriggerGameOver();
		}
	}
	
	void FixedUpdate () {
		if (touchingPlatform) {
			rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
		}
	}

	void OnCollisionEnter (Collision collision) {
		particles.Emit(Mathf.RoundToInt(collision.relativeVelocity.magnitude));
		touchingPlatform = true;
	}

	void OnCollisionExit () {
		touchingPlatform = false;
	}
	
	private void GameStart () {
		distanceTraveled = 0f;
		transform.localPosition = startPosition;
		gameObject.active = true;
		enabled = true;
	}
	
	private void GameOver () {
		enabled = false;
	}
}