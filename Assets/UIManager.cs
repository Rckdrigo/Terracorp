using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using TouchGestures;

public class UIManager : MonoBehaviour {
	public UnityEvent Dispatch, FinishedAnimation;

	Animator animator;

	void Start () {
		animator = GetComponent<Animator>();

		TapGesture.OnTapDetected += HandleOnTapDetected;
		GameStateMachine.Instance.Reset += HandleReset;
	}

	void HandleReset ()
	{
		animator.SetTrigger("StartGame");
	}

	void HandleOnTapDetected (Vector2 tapPosition)
	{
		animator.SetTrigger("StartGame");
		TapGesture.OnTapDetected -= HandleOnTapDetected;

	}

	public void OnFinishedAnimation(){
		FinishedAnimation.Invoke();
	}

	public void OnMachineDispach(){
		Dispatch.Invoke();
	}

}
