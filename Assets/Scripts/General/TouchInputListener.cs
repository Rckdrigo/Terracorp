using UnityEngine;
using System.Collections;

public class TouchInputListener : Singleton<TouchInputListener> {

	public delegate void TouchListener();
	public event TouchListener OneTouchEnter;
	public event TouchListener OneTouchQuit;
	public event TouchListener OneTouch;
	
	public Touch singleTouch;
	
	bool isTouching = false;

	void Update () {
		if(Input.touchCount>0 && !isTouching){
			singleTouch = Input.GetTouch(0);
			isTouching = true;
			OneTouchEnter();
		}
		
		if(isTouching){
			OneTouch();
		}
		
		if(Input.touchCount == 0 && isTouching){
			isTouching = false;
			OneTouchQuit();
		}
	}
}
