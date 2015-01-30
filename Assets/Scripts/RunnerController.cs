using UnityEngine;
using System.Collections;

public class RunnerController : Character2D {

	public float jumpSpeed = 10.0F;
	
	void Start(){
		base.Start();
		TouchInputListener.Instance.OneTouch += Jump;
		RunnerAnimation.Instance.Dead += Die;
		RunnerAnimation.Instance.Restart += Restart;
	}
	
	new void Update() {
		base.Update();
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Jump();
		}
	}
	
	void Restart(){
		transform.position = initialPosition;
	}
	
	void Die(){
		rigidbody2D.AddForce((Vector2.up *3 + Vector2.right/2).normalized*3,ForceMode2D.Impulse);
	}
	
	public void Jump(){
		/**DEVELOPMENT**/ 
		//if (controller.isGrounded && TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)		
		if( isOnGround()){
			rigidbody2D.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
		}
	}
	
}
	