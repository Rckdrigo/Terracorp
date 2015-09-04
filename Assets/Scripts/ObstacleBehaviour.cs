using UnityEngine;
using System.Collections;

public class ObstacleBehaviour : MonoBehaviour {

	void OnEnable(){
		GameStateMachine.Instance.Reset += Pool;
	}
		
	public void Pool(){
		ObjectPool.Instance.PoolGameObject(gameObject);
	}
}
