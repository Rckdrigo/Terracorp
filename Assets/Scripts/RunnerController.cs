using UnityEngine;
using System.Collections;

public class RunnerController : Character2D {

	public Transform core;
	public static float coreDistance;

	public float jumpSpeed = 10.0F;
	void OnDrawGizmos(){
		if(Vector3.Angle(transform.position,Vector3.up) < 30)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;

		Gizmos.DrawRay(transform.position,Physics2D.gravity*100);
		Gizmos.DrawWireSphere(transform.position,_height*0.15f);

		coreDistance = Vector2.Distance(transform.position,core.position);
	}
	
	new void Start(){
		base.Start();
		TouchInputListener.Instance.OneTouchEnter += Jump;
		RunnerAnimation.Instance.Dead += Die;
		RunnerAnimation.Instance.Restart += Restart;
		RunnerAnimation.Instance.Crash += Crash;
	}
	
	new void Update() {
		base.Update();
		coreDistance = Vector2.Distance(transform.position,core.position);
		if (Input.GetButtonDown ("Jump"))
			Jump();

		Physics2D.gravity = new Vector2(transform.position.x,transform.position.y).normalized * -9.81f;
		transform.up = -Physics2D.gravity.normalized;
	}
	
	void Restart(){
		transform.position = initialPosition;
	}
	
	void Die(){
		if(isOnGround())
			rigidbody2D.AddForce((Vector2.up *2 + Vector2.right/2).normalized,ForceMode2D.Impulse);
	}

	void Crash(){
		transform.parent = core;
	}

	public void Jump(){
#if !UNITY_EDITOR
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3 && TouchInputListener.Instance.singleTouch.position.x < Screen.width/3)	
#endif
			if( isOnGround() && !RunnerAnimation.Instance.dead)
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
		
	}
	
}
	