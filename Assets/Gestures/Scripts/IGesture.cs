using UnityEngine;
using System.Collections;

namespace TouchGestures{
	public interface IGesture {
		IEnumerator CheckIfGesture();
	}
}
