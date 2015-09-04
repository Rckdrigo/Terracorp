using UnityEngine;
using System.Collections;

public class GameStateMachine : Singleton<GameStateMachine> {

	public delegate void StateMachine();
	public event StateMachine Reset;


	public void PauseToogle(){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
	}
	
	void Start(){
		RunnerAnimation.Instance.Crash += HandleCrash;
	}

	void HandleCrash ()
	{
		Reset();
	}

	public void InitialSet(){
		Reset();
		
		Time.timeScale = 1;
	}
}
