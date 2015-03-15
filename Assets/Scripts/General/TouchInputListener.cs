using UnityEngine;
using System.Collections;

public class TouchInputListener : Singleton<TouchInputListener> {

	public delegate void TouchListener();
	public event TouchListener OneTouchEnter;
	public event TouchListener OneTouchQuit;
	public event TouchListener OneTouch;
	
	public Touch singleTouch;

	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0){
			
			print ("Is Touching: " + Input.GetTouch(0).phase);
			singleTouch = Input.GetTouch(0);
			switch(Input.GetTouch(0).phase){
				case TouchPhase.Began:
				OneTouchEnter();
				break;
				
				case TouchPhase.Ended:
				OneTouchQuit();
				break;
				
				case TouchPhase.Moved:
				OneTouch();
				break;
				
			    case TouchPhase.Stationary:
				OneTouch();
				break;
				
				default:
				break;
			}
		
			
		}
	}
}
