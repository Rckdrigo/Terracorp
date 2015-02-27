using UnityEngine;
using System.Collections;

public class RunnerAnimation : Singleton<RunnerAnimation> {

	public delegate void StateMachine();
//	public event StateMachine Land;
	public event StateMachine Dead;
	public event StateMachine Restart;
	public event StateMachine Crash;
	
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
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3 && TouchInputListener.Instance.singleTouch.position.x < Screen.width/3)	
#endif
			if(runner.IsGrounded && !animator.GetCurrentAnimatorStateInfo(0).IsName("DudeJump"))
				animator.SetTrigger("Jump");
	}
	
	void Slide(){
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3 && TouchInputListener.Instance.singleTouch.position.x > 2 * Screen.width/3)	
			if(runner.isOnGround())
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
		Crash();
	}
	
	void Update(){
		animator.SetFloat("VSpeed",GetComponent<Rigidbody2D>().velocity.y);
		if(runner.isOnGround() && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeFall")){
			Landing();
		 }
		 
		if(runner.isOnGround() && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie")){
			Crashing();
		}

		if(Vector3.Angle(transform.position,Vector3.up) > 30)
			Die();

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

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Damage"))
			Die ();
	}
}