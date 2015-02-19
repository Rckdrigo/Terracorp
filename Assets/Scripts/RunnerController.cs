using UnityEngine;
using System.Collections;

public class RunnerController : Character2D {

	public float jumpSpeed = 10.0F;
	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position,transform.up*100);
	}
	
	new void Start(){
		base.Start();
		TouchInputListener.Instance.OneTouchEnter += Jump;
		RunnerAnimation.Instance.Dead += Die;
		RunnerAnimation.Instance.Restart += Restart;
	}
	
	new void Update() {
		base.Update();

		if(Input.GetButtonDown("Jump"))
			Jump ();
	}
	
	void Restart(){
		transform.position = initialPosition;
	}
	
	void Die(){
		if( isOnGround())
			rigidbody2D.AddForce((Vector2.up *3 + Vector2.right/2).normalized*10,ForceMode2D.Impulse);
	}
	
	public void Jump(){
#if !UNITY_EDITOR
		if (TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)	
#endif
			if( isOnGround() && !RunnerAnimation.Instance.dead)
				rigidbody2D.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
		
	}
	
}
	