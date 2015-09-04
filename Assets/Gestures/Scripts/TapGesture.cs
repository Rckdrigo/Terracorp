using UnityEngine;
using System.Collections;

namespace TouchGestures{

	[RequireComponent(typeof(GesturesErrorHandler))]
	public class TapGesture : MonoBehaviour, IGesture {

		[Range(0.01f,0.2f)]
		public float precision = 0.15f;
		public delegate void TapEvent(Vector2 tapPosition);
		public static event TapEvent OnTapDetected;
		public delegate void TapRaycastEvent(GameObject tapObject);
		public static event TapRaycastEvent OnTapGameObjectDetected;


		private Vector2 initialPosition, finalPosition;
		private bool onTap;

		void Update () {
#if !UNITY_EDITOR
			if(Input.touchCount > 0){
				switch(Input.GetTouch(0).phase)	{
				case TouchPhase.Began:
					initialPosition = Input.GetTouch(0).position;
					onTap = true;
					StartCoroutine(CheckIfGesture());
					break;

				case TouchPhase.Ended:
					onTap = false;
					finalPosition = Input.GetTouch(0).position;
					break;
				}
			}
#else
			if(Input.GetMouseButtonDown(0)){
				initialPosition = (Vector2)Input.mousePosition;
				onTap = true;
				StartCoroutine(CheckIfGesture());
			}

			if(Input.GetMouseButtonUp(0)){
				finalPosition = (Vector2)Input.mousePosition;
				onTap = false;
			}
#endif
		}

		#region Gesture implementation

		public IEnumerator CheckIfGesture (){
			yield return new WaitForSeconds(precision);
			if(!onTap  && Vector3.Distance(finalPosition,initialPosition) < 0.1f){
				OnTapDetected(finalPosition);
				//	OnTapGameObjectDetected(Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition),2).gameObject);
			}
		}

		#endregion


	}
}
