using UnityEngine;
using System.Collections;

namespace TouchGestures{
	[RequireComponent(typeof(GesturesErrorHandler))]
	public class DragGesture : MonoBehaviour, IGesture {
		[Range(0,5)]
		public float radiusOfDragSelection;

		public delegate void DragEvent(Vector2 dragPosition);
		public static event DragEvent OnDragStarted;
		public static event DragEvent OnDragging;
		public static event DragEvent OnDraggingWorld;
		public static event DragEvent OnDragEnded;

		public delegate void DragSelectionEvent(GameObject objectSelected);
		public static event DragSelectionEvent OnObjectSelected;

		private Vector2 initialPosition, actualPosition, worldActualPosition; 

		void FixedUpdate () {
			#if !UNITY_EDITOR
			if(Input.touchCount > 0){
				switch(Input.GetTouch(0).phase){
				case TouchPhase.Began:
					initialPosition = Input.GetTouch(0).position;
					actualPosition = initialPosition;
					worldActualPosition =(Vector2)Camera.main.ScreenToWorldPoint(actualPosition);
					Collider2D obj = Physics2D.OverlapCircle(worldActualPosition,radiusOfDragSelection);
					if(obj != null){
						OnDragStarted(actualPosition);
						OnObjectSelected(obj.gameObject);
					}
					break;

				case TouchPhase.Moved:
					actualPosition = Input.GetTouch(0).position;
					OnDragging(actualPosition);
					worldActualPosition =(Vector2)Camera.main.ScreenToWorldPoint(actualPosition);
					break;

				case TouchPhase.Stationary:
					actualPosition = Input.GetTouch(0).position;
					OnDragging(actualPosition);
					break;

				case TouchPhase.Ended:
					OnDragEnded(actualPosition);
					break;

				case TouchPhase.Canceled:
					OnDragEnded(actualPosition);
					break;
				}
			}
			#else
				if(Input.GetMouseButtonDown(0)){
					initialPosition = Input.mousePosition;
					actualPosition = initialPosition;

					worldActualPosition =(Vector2)Camera.main.ScreenToWorldPoint(actualPosition);
					Collider2D obj = Physics2D.OverlapCircle(worldActualPosition,radiusOfDragSelection);
					if(obj != null){
						OnDragStarted(actualPosition);
						OnObjectSelected(obj.gameObject);
					}
				}

				else if(Input.GetMouseButton(0)){
					actualPosition =  Input.mousePosition;
					OnDragging(actualPosition);
				}
				else if(Input.GetMouseButtonUp(0)){
					OnDragEnded(actualPosition);
				}
				else if(new Rect(0,0,1,1).Contains(Camera.main.ScreenToViewportPoint(Input.mousePosition)) && Input.GetMouseButton(0))
					OnDragEnded(actualPosition);
			#endif
		}

		#region Gesture implementation

		public IEnumerator CheckIfGesture ()
		{
			yield return null;
		}

		#endregion



	}
}