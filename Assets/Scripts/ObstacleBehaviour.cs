﻿using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position,transform.up*100);
	}

	void Start(){
		GameStateMachine.Instance.Reset += Pool;
	}

	void Update () {
		if(Vector3.Angle(transform.up,Vector3.right) > 90 && Vector3.Angle(transform.up,Vector3.right) < 135 && transform.up.y < 0)
			Pool();
	}
	
	void Pool(){
		ObjectPool.Instance.PoolGameObject(gameObject);
	}
}
