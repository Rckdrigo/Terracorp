using UnityEngine;
using System.Collections;

public class RunnerAnimation : Singleton<RunnerAnimation> {

	public delegate void StateMachine();
//	public event StateMachine Land;
	public event StateMachine Dead;
	public event StateMachine Restart;
	
	[HideInInspector()]
	public bool dead;
	[HideInInspector()]
	public bool sliding;
	
	Animator animator;
	RunnerController runner;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		runner = GetComponent<RunnerController>();
		
		TouchInputListener.Instance.OneTouchEnter += Jump;
		TouchInputListener.Instance.OneTouch += Slide;
		TouchInputListener.Instance.OneTouchQuit += StandUp;
		
		sliding = false;
		dead = false;
	}
	
	void Jump () {
#if !UNITY_EDITOR
		if (TouchInputListener.Instance.singleTouch.position.y > 2 * Screen.height/3)
#endif
			if(runner.IsGrounded && !animator.GetCurrentAnimatorStateInfo(0).IsName("DudeJump"))
				animator.SetTrigger("Jump");
	}
	
	void Slide(){
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3)
			if(runner.IsGrounded)
				if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeSlide"))
					sliding = true;
	}
	
	void StandUp(){
		if(sliding)
			sliding = false;
	}
	
	void Die(){
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie") && !animator.GetCurrentAnimatorStateInfo(0).IsName("DudeCrash")){
			Dead();
			animator.SetTrigger("Die");
			dead = true;
		}
	}
	
	void Reset(){
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("DudeCrash")){
			Restart();
			animator.SetTrigger("Reset");
			animator.ResetTrigger("Jump");
			dead = false;
		}
	}
	
	void Landing(){
		animator.SetTrigger("Land");
		animator.ResetTrigger("Jump");
	}
	
	void Crashing(){
		animator.SetTrigger("Land");
		animator.ResetTrigger("Die");
	}
	
	void Update(){
		animator.SetFloat("VSpeed",rigidbody2D.velocity.y);
		if(runner.IsGrounded && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeFall")){
			Landing();
		 }
		 
		if(runner.IsGrounded && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie") && rigidbody2D.velocity.y <0){
			Crashing();
		}
		 
#if UNITY_EDITOR
		if(Input.GetButtonDown("Jump"))
			Jump();
		if(Input.GetKeyDown(KeyCode.D))
			Die();
		if(Input.GetKeyDown(KeyCode.R))
			Reset();
		//sliding = Input.GetKey(KeyCode.DownArrow);
#endif
		animator.SetBool("Slide",sliding);
	}
}
