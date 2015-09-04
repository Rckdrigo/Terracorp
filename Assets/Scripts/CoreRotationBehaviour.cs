using UnityEngine;
using System.Collections;

public class CoreRotationBehaviour : MonoBehaviour {

	[Range(10.0f,100.0f)]
	public float rotSpeed = 10;
	
	bool onPlay;

	void OnDrawGizmo(){
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position,transform.right*100);
	}
	
	void Start(){
		RunnerAnimation.Instance.Land += FirstLand;
		GameStateMachine.Instance.Reset += Reset;
		
	}
	
	void Reset(){
		onPlay = false;
		GetComponent<CoreObstacleGenerator>().StopCreating();
		RunnerAnimation.Instance.Land += FirstLand;
	}
	
	void FirstLand(){
		onPlay = true;
		RunnerAnimation.Instance.Land -= FirstLand;
		GetComponent<CoreObstacleGenerator>().StartGenerating();
	}
	
	// Update is called once per frame
	void Update () {
		if(onPlay)
			transform.Rotate(Vector3.forward,rotSpeed * Time.deltaTime);
	}
}
