using UnityEngine;
using System.Collections;

public class GameStateMachine : Singleton<GameStateMachine> {
	
	public GameObject pauseButton, playButton, resetButton;
	
	public delegate void StateMachine();
	public event StateMachine Reset;
	
	public void PauseToogle(){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		
		resetButton.SetActive((Time.timeScale == 1) ?  false: true);
	}
	
	void Start(){
		resetButton.SetActive(false);
		pauseButton.SetActive(false);
		playButton.SetActive(true);
		RunnerAnimation.Instance.Crash += LostGame;
	}
	
	public void StartGame(){
		pauseButton.SetActive(true);
		playButton.SetActive(false);
		resetButton.SetActive(false);
		
	}
	
	void LostGame(){
		resetButton.SetActive(true);
		pauseButton.SetActive(false);
		playButton.SetActive(false);
	}
	
	public void InitialSet(){
		Reset();
		resetButton.SetActive(false);
		pauseButton.SetActive(false);
		playButton.SetActive(true);
		
		Time.timeScale = 1;
	}
}
