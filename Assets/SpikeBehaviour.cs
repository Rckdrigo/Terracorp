using UnityEngine;
using System.Collections;

public class SpikeBehaviour : MonoBehaviour {
	
	void OnEnable () {
		transform.parent = GameObject.FindWithTag("Core").transform;
	}

	void Update(){
		if(Vector3.Dot(transform.up,Vector3.left)>0.9f)
			GetComponent<ObstacleBehaviour>().Pool();
	}
}
