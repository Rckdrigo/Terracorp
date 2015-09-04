using UnityEngine;
using System.Collections;

public class CoreObstacleGenerator : MonoBehaviour {

	void Start(){
		GameStateMachine.Instance.Reset += StopCreating;
	}
	
	public void StopCreating(){
		StopAllCoroutines();
	}
	
	public void StartGenerating(){
		StartCoroutine(InitialDelay());
	}

	IEnumerator CreateObstacle(){
		ObjectPool.Instance.GetGameObjectOfType("Obstacle "+Random.Range(0,8),true);
		yield return new WaitForSeconds(1);
		StartCoroutine(CreateObstacle());
	}

	IEnumerator InitialDelay(){
		yield return new WaitForSeconds(2);
		StartCoroutine(CreateObstacle());
	}
}
