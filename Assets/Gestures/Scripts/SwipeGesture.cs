using UnityEngine;
using System.Collections;

namespace TouchGestures{
	[RequireComponent(typeof(GesturesErrorHandler))]
	public class SwipeGesture : MonoBehaviour, IGesture {

		[Range(0.00f,0.2f)]
		public float timePrecision = 0.045f;
		[Range(0,200)]
		public float lengthPrecision = 50f;

		public delegate void SwipeEvent(Vector2 swipeDirection, float magnitude);
		public delegate void SwipeEnumEvent(SwipeDirection swipeDirection);
		public static event SwipeEvent OnSwipeDetected;
		public static event SwipeEvent OnSwipeDetectedRaw;
		public static event SwipeEnumEvent OnSwipeDetectedDirection;

		public static SwipeDirection swipeDirection;

		private bool onMovement;
		private Vector2 initialPosition, finalPosition; 
		private Vector2 swipeDirectionVector;
		private Vector2 swipeRawDirectionVector;

		void Start(){
			onMovement = false;
		}

		void Update () {
			#if !UNITY_EDITOR
			if(Input.touchCount > 0){
				if(Input.GetTouch(0).phase == TouchPhase.Moved) {
					if(!onMovement){
						initialPosition = Input.GetTouch(0).position;
						StopAllCoroutines();
						StartCoroutine(CheckIfGesture());
						onMovement = true;
					}

				}
				
				finalPosition = Input.GetTouch(0).position;
			}
			#else
				if(Input.GetMouseButton(0)){
					if(!onMovement){
						initialPosition = (Vector2)Input.mousePosition;
						StopAllCoroutines();
						StartCoroutine(CheckIfGesture());
						onMovement = true;
					}
					finalPosition = (Vector2)Input.mousePosition;
				}
			#endif
		}

		
		#region Gesture implementation

		public IEnumerator CheckIfGesture(){
			yield return new WaitForSeconds(timePrecision);
		//#if UNITY_EDITOR
		//	finalPosition = (Vector2)Input.mousePosition;
		//#else
		//	finalPosition = Input.GetTouch(0).position;
		//#endif
			if(Vector3.Distance(finalPosition,initialPosition) > lengthPrecision){
				Vector2 direction = (finalPosition - initialPosition);
				swipeRawDirectionVector = direction;
				swipeDirectionVector = new Vector2(Mathf.Round(Vector2.Dot(direction.normalized,Vector2.right)),
				                                   Mathf.Round(Vector2.Dot(direction.normalized,Vector2.up)));
				OnSwipeDetectedRaw(swipeRawDirectionVector,(finalPosition - initialPosition).magnitude);
				OnSwipeDetected(swipeDirectionVector,(finalPosition - initialPosition).magnitude);

				GetDirection(swipeRawDirectionVector);
				OnSwipeDetectedDirection(swipeDirection);

			}

			onMovement = false;
		}

		public void GetDirection(Vector2 direction){
			if(Vector2.Dot(swipeRawDirectionVector.normalized,Vector2.up) > 0.5f)
				swipeDirection = SwipeDirection.Up;
			if(Vector2.Dot(swipeRawDirectionVector.normalized,Vector2.down) > 0.5f)
				swipeDirection = SwipeDirection.Down;
			if(Vector2.Dot(swipeRawDirectionVector.normalized,Vector2.right) > 0.5f)
				swipeDirection = SwipeDirection.Right;
			if(Vector2.Dot(swipeRawDirectionVector.normalized,Vector2.left) > 0.5f)
				swipeDirection = SwipeDirection.Left;
		}

		#endregion


	}
}