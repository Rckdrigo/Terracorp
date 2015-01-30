using UnityEngine;
using System.Collections;

public class RunnerAnimation : Singleton<RunnerAnimation> {

	public delegate void Landing();
	public event Landing Land;
	
	Animator animator;
	RunnerController runner;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		runner = GetComponent<RunnerController>();
		
		TouchInputListener.Instance.OneTouch += Jump;
		TouchInputListener.Instance.OneTouch += Slide;
	}
	
	void Jump () {
		/**DEVELOPMENT**/ 
		//if (RunnerController.Instance.isGrounded && TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeJump"))
				animator.SetTrigger("Jump");
	}
	
	void Slide(){
		/**DEVELOPMENT**/ 
		//if (RunnerController.Instance.isGrounded && TouchInputListener.Instance.singleTouch.position.y < Screen.height/3)
		if(runner.IsGrounded)
			if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeSlide"))
				animator.SetBool("Slide",true);

	}
	
	void Die(){
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie"))
			animator.SetTrigger("Die");
	}
	
	void Reset(){
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie"))
			animator.SetTrigger("Reset");
	}
	
	void Update(){
	
		animator.SetFloat("VSpeed",rigidbody2D.velocity.y);
		if(runner.IsGrounded && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeFall")){
			animator.SetTrigger("Land");
			animator.ResetTrigger("Jump");
			//Land();
		 }
		 
		/**DEVELOPMENT**/ 
		if(Input.GetKeyDown(KeyCode.UpArrow))
			Jump();
		if(Input.GetKeyDown(KeyCode.D))
			Die();
		if(Input.GetKeyDown(KeyCode.R))
			Reset();
		animator.SetBool("Slide",Input.GetKey(KeyCode.DownArrow));
		/****/
	}
}
