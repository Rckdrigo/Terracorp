using UnityEngine;
using System.Collections;

public class RunnerController : Character2D {

	public float jumpSpeed = 10.0F;
	void OnDrawGizmos(){
		if(Vector3.Angle(transform.position,Vector3.up) < 30)
			Gizmos.color = Color.green;
		else
			Gizmos.color = Color.red;

		Gizmos.DrawRay(transform.position,Physics2D.gravity*100);
	}
	
	new void Start(){
		base.Start();
		TouchInputListener.Instance.OneTouchEnter += Jump;
		RunnerAnimation.Instance.Dead += Die;
		RunnerAnimation.Instance.Restart += Restart;
	}
	
	new void Update() {
		base.Update();

		if(Vector3.Angle(transform.position,Vector3.up) < 30)
			Physics2D.gravity = new Vector2(transform.position.x,transform.position.y).normalized * -9.81f;
		else
			Physics2D.gravity = new Vector2(0,-9.8f);
		transform.up = -Physics2D.gravity.normalized;
		if(isOnGround()){
			
			rigidbody2D.gravityScale = 0;
		}else
			rigidbody2D.gravityScale = 5.1f;
	}
	
	void Restart(){
		transform.position = initialPosition;
	}
	
	void Die(){
		if( isOnGround())
			rigidbody2D.AddForce((Vector2.up *3 + Vector2.right/2).normalized*10,ForceMode2D.Impulse);
	}
	
	public void Jump(){
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3 && TouchInputListener.Instance.singleTouch.position.x < Screen.width/3)	
			if( isOnGround() && !RunnerAnimation.Instance.dead)
				rigidbody2D.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
		
	}
	
}
	