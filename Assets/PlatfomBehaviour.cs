using UnityEngine;
using System.Collections;

public class PlatfomBehaviour : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(Vector2.zero, transform.position)>RunnerController.coreDistance)
			GetComponent<Collider2D>().enabled = false;
		else
			GetComponent<Collider2D>().enabled = true;
	}
}
