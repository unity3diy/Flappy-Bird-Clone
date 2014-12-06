using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed    = 100f;
	public float forwardSpeed = 1f;

	bool didFlap = false;

	Animator animator;

	public bool dead = false;
	float deathCooldown;

	public bool godMode = false;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}
	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
					Application.LoadLevel( Application.loadedLevel );
				}
			}
		}
		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
				didFlap = true;
			}
		}
	}

	
	// Do physics engine updates here
	void FixedUpdate () {

		if(dead)
			return;

		rigidbody2D.AddForce( Vector2.right * forwardSpeed );

		if(didFlap) {
			rigidbody2D.AddForce( Vector2.up * flapSpeed );
			animator.SetTrigger("DoFlap");


			// friends blog > http://bit.ly/unity3diy


			didFlap = false;
		}

		if(rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else {
			float angle = Mathf.Lerp (0, -90, (-rigidbody2D.velocity.y / 3f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;

		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
	
}




// friends blog > http://bit.ly/unity3diy
