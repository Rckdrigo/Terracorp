using UnityEngine;
using System.Collections;

public class PlatfomBehaviour : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(Vector2.zero, transform.position)>RunnerController.coreDistance)
			collider2D.enabled = false;
		else
			collider2D.enabled = true;
	}
}
