using UnityEngine;
using System.Collections;
using TouchGestures;

public class RunnerController : Character2D {

	public Transform core;
	public static float coreDistance;
	
	Vector2 initialPos;
	SpriteRenderer renderer;

	public float jumpSpeed = 15.0F;
	/*void OnDrawGizmos(){
		if(Vector3.Angle(transform.position,Vector3.up) < 15)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;

		Gizmos.DrawRay(transform.position,Physics2D.gravity*100);
		Gizmos.DrawWireSphere(transform.position,_height*0.15f);

		coreDistance = Vector2.Distance(transform.position,core.position);
	}*/
	
	new void Start(){
		base.Start();
		RunnerAnimation.Instance.Dead += Die;
		GameStateMachine.Instance.Reset += Reset;
		RunnerAnimation.Instance.Crash += Crash;
		RunnerAnimation.Instance.Land += Land;
		
		initialPos = transform.position;

		renderer = GetComponent<SpriteRenderer>();
	}
	
	public void StartGame(){
		
		renderer.enabled = true;
		GetComponent<Rigidbody2D>().gravityScale = 6;
		SwipeGesture.OnSwipeDetectedDirection += HandleOnSwipeDetectedDirection;
		
		transform.rotation = Quaternion.identity;
	}

	void HandleOnSwipeDetectedDirection (SwipeDirection swipeDirection)
	{
		if(swipeDirection == SwipeDirection.Up)
			Jump();
	}
	
	new void Update() {
		base.Update();
		coreDistance = Vector2.Distance(transform.position,core.position);

		Physics2D.gravity = new Vector2(transform.position.x,transform.position.y).normalized * -9.81f * 2;
		transform.up = -Physics2D.gravity.normalized;
	}

	void Die(){
		SwipeGesture.OnSwipeDetectedDirection -= HandleOnSwipeDetectedDirection;
		if(isOnGround())
			GetComponent<Rigidbody2D>().AddForce((Vector2.up *2 + Vector2.right/2).normalized,ForceMode2D.Impulse);
	}

	void Crash(){
		transform.parent = core;
	}

	void Land(){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	public void Reset(){
		renderer.enabled = false;
		SwipeGesture.OnSwipeDetectedDirection -= HandleOnSwipeDetectedDirection;
		transform.position = initialPos;
		GetComponent<Rigidbody2D>().gravityScale = 0;
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		transform.parent = null;
		transform.rotation = Quaternion.identity;
	}

	public void Jump(){
		if(isOnGround() && !RunnerAnimation.Instance.dead){
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
			GetComponent<RunnerAnimation>().Jump();
		}

	}
	
}
	