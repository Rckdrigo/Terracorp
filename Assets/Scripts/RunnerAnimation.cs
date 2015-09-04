using UnityEngine;
using System.Collections;

public class RunnerAnimation : Singleton<RunnerAnimation> {

	public delegate void StateMachine();
	public event StateMachine Land;
	public event StateMachine Dead;
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
		
		sliding = false;
		dead = false;

		GameStateMachine.Instance.Reset += Reset;
	}
	
	public void Jump () {
		if(runner.IsGrounded && !animator.GetCurrentAnimatorStateInfo(0).IsName("DudeJump"))
			animator.SetTrigger("Jump");
	}
	
	/*void Slide(){
		if (TouchInputListener.Instance.singleTouch.position.y < Screen.height/3 && TouchInputListener.Instance.singleTouch.position.x > 2 * Screen.width/3)	
			if(runner.isOnGround())
				if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeSlide"))
					sliding = true;
	}
	
	void StandUp(){
		if(sliding)
			sliding = false;
	}*/
	
	void Die(){
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("DudeDie") && !animator.GetCurrentAnimatorStateInfo(0).IsName("DudeCrash")){
			Dead();
			animator.SetTrigger("Die");
			dead = true;
		}
	}
	
	public void Reset(){
		//if(animator.GetCurrentAnimatorStateInfo(0).IsName("DudeCrash")){
			animator.SetTrigger("Reset");
			animator.ResetTrigger("Jump");
			dead = false;
		//}
	}
	
	void Landing(){
		animator.SetTrigger("Land");
		animator.ResetTrigger("Jump");
		Land();
	}
	
	void Crashing(){
		print ("Chocando");
		animator.SetTrigger("Land");
		animator.ResetTrigger("Die");
		Crash();
	}
	
	void Update(){
		animator.SetFloat("VSpeed",GetComponent<Rigidbody2D>().velocity.y);
		if(runner.isOnGround() && animator.GetCurrentAnimatorStateInfo(0).IsName("DudeFall")){
			Landing();
		 }

		if(Vector3.Angle(transform.position,Vector3.up) > 15)
			Die();

#if UNITY_EDITOR
		//sliding = Input.GetKey(KeyCode.DownArrow);
#endif
		//animator.SetBool("Slide",sliding);
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("Damage"))
			Die ();
	}
}