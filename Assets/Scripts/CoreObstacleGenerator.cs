using UnityEngine;
using System.Collections;

public class CoreObstacleGenerator : MonoBehaviour {

	[System.Serializable]
	public struct ObstacleLevel{
		public ObstaclePerLevel level;
	}
	public ObstacleLevel[] obstacleLevel;
	bool isGenerating;


	void Start(){
		GameStateMachine.Instance.Reset += StopCreating;
	}
	
	void StopCreating(){
		StopAllCoroutines();
		isGenerating = false;
	}
	
	public void StartGenerating(){
		if(!isGenerating){
			for(int i = 0; i < obstacleLevel.Length; i++)
				StartCoroutine(InitialDelay(obstacleLevel[i].level));
			isGenerating = true;
		}
	}

	IEnumerator CreateObstacle(ObstaclePerLevel level){
		if(Random.Range(0,100) < level.probability){
			int random = Random.Range(0,level.obstacles.Length);
			GameObject temp = ObjectPool.Instance.GetGameObjectOfType(level.obstacles[random],true) as GameObject;

			temp.transform.parent = transform;
			temp.transform.position = level.transform.position;
			temp.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
		}
		yield return new WaitForSeconds(level.time);
		StartCoroutine(CreateObstacle(level));
	}

	IEnumerator InitialDelay(ObstaclePerLevel level){
		yield return new WaitForSeconds(level.delay);
		StartCoroutine(CreateObstacle(level));
	}
}
