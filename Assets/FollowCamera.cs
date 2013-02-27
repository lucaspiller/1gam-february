using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject target;
	
	private Vector3 offset;
	private Vector3 startPosition = Vector3.zero;
	private float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero;

	
	void Start () {
		offset = target.transform.localPosition - transform.localPosition;
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
	}
	
	void FixedUpdate () {
		Vector3 targetPosition = (target.transform.position - offset);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                                 ref velocity, smoothTime);
	}
	
	public void GameStart() {		
		enabled = true;
		transform.position = startPosition;
	}
	
	public void GameOver() {
		enabled = false;	
	}
}
