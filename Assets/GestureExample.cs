using UnityEngine;
using System.Collections;
using TouchGestures;

public class GestureExample : MonoBehaviour {

	void Start () {
		SwipeGesture.OnSwipeDetected += HandleOnSwipeDetected;
		SwipeGesture.OnSwipeDetectedDirection += HandleOnSwipeDetectedDirection;
	}

	void HandleOnSwipeDetectedDirection (SwipeDirection swipeDirection)
	{

		if(swipeDirection == SwipeDirection.Right)
			print ("me voy a la derecha");

		if(swipeDirection == SwipeDirection.Left)
			print ("me voy a la izquierda");
	}
	
	void HandleOnSwipeDetected (Vector2 swipeDirection, float magnitude)
	{
		//Debug.Log("Swipe direction " + swipeDirection);
	
	}
	
}
