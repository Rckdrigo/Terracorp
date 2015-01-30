using UnityEngine;
using System.Collections;

public class RunnerController : Character2D {

	public float jumpSpeed = 10.0F;
	
	void Start(){
		TouchInputListener.Instance.OneTouch += Jump;
	}
	
	new void Update() {
		base.Update();
		
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			Jump();
		}
	}
	
	void LateUpdate(){
	}
	
	public void Jump(){
		/**DEVELOPMENT**/ 
		//if (controller.isGrounded && TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)		
		if( isOnGround()){
			print (IsGrounded);
			rigidbody2D.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
		}
	}
	
}
	