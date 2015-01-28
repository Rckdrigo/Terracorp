using UnityEngine;
using System.Collections;

public class TouchInputListener : Singleton<TouchInputListener> {

	public delegate void TouchListener();
	public event TouchListener OneTouch;
	
	public Touch singleTouch;
	public Touch secondTouch;

	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0){
			singleTouch = Input.GetTouch(0);
			OneTouch();
		}
	}
}
