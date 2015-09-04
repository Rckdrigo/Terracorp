using UnityEngine;
using System.Collections;

namespace TouchGestures{
	public class GesturesErrorHandler : MonoBehaviour {
		void Start () {
			SwipeGesture.OnSwipeDetectedRaw 	+= (swipeDirection,magnitude) => {};
			SwipeGesture.OnSwipeDetected 		+= (swipeDirection,magnitude) => {};
			SwipeGesture.OnSwipeDetectedDirection 	+= (swipeDirection) => {};

			TapGesture.OnTapDetected 			+= (tapPosition) => {};
			TapGesture.OnTapGameObjectDetected 	+= (tapObject) => {};

			DragGesture.OnDragStarted 		+= (dragPosition) => {};
			DragGesture.OnObjectSelected 	+= (dragPosition) => {};
			DragGesture.OnDragging 			+= (dragPosition) => {};
			DragGesture.OnDragEnded 		+= (dragPosition) => {};
			DragGesture.OnDraggingWorld		+= (dragPosition) => {};
		}

	}
}
