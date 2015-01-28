using UnityEngine;
using System.Collections;

public class RunnerAnimation : Singleton<RunnerAnimation> {

	public delegate void Landing();
	public event Landing Land;
	
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		
		TouchInputListener.Instance.OneTouch += Jump;
		TouchInputListener.Instance.OneTouch += Slide;
	}
	
	void Jump () {
		if (RunnerController.Instance.isGrounded && TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)
			if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeJump"))
				animator.SetTrigger("Jump");
	}
	
	void Slide(){
		if (RunnerController.Instance.isGrounded && TouchInputListener.Instance.singleTouch.position.y < Screen.height/3)
			if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeSlide"))
				animator.SetTrigger("Slide");

	}
	
	void StandUp(){
		animator.ResetTrigger("Slide");
	}
	
	public void Die(){
		print("Hola");
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie"))
			animator.SetTrigger("Die");
		else
			animator.SetTrigger("Reset");
			
	}
	
	void Update(){
		animator.SetFloat("VSpeed",GetComponent<RunnerController>().moveDirection.y);
		if(RunnerController.Instance.isGrounded && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeFall")){
			animator.SetTrigger("Land");
			animator.ResetTrigger("Jump");
			Land();
		 }
	}
}
