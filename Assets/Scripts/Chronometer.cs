using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Chronometer : Singleton<Chronometer> {

	public Text timer;
	private float time;
	public float ActualTime {get {return time;}}

	public void StartTimer(){
		StopAllCoroutines();
		time = 0;
		StartCoroutine(Timer());
	}


	public void PauseTimer(){
		StopAllCoroutines();
	}

	public void ResumeTimer(){
		StopAllCoroutines();
		StartCoroutine(Timer());
	}

	public void StopTimer(){
		StopAllCoroutines();
		time = 0;
	}

	IEnumerator Timer(){
		time = 0;
		while(true){
			yield return new WaitForEndOfFrame();
			time += Time.smoothDeltaTime;
			timer.text = ""+time.ToString("00:00") + " s";
		}
	}	
}
