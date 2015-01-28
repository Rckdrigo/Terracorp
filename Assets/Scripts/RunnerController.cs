using UnityEngine;
using System.Collections;

public class RunnerController : Singleton<RunnerController> {

	public float jumpSpeed = 10.0F;
	public float gravity = 10.0F;
	public bool isGrounded;
	
	[HideInInspector()]
	public Vector3 moveDirection;
	private CharacterController controller;
	
	void Start(){
		controller = GetComponent<CharacterController>();
		TouchInputListener.Instance.OneTouch += Jump;
		RunnerAnimation.Instance.Land += Land;
		moveDirection = Vector3.zero;
		isGrounded = controller.isGrounded;
	}
	
	void Update() {
		isGrounded = controller.isGrounded;
		if (!controller.isGrounded)
			moveDirection.y -= gravity * Time.deltaTime;
			
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	void Jump(){
		if (controller.isGrounded && TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3){
			moveDirection.y = jumpSpeed;
			print ("Jumping");
		}
	}
	
	void Land(){
		moveDirection.y = 0;
	}
	
	void StandUp(){
		moveDirection.y = 0;
	}
}
	