using UnityEngine;
using System.Collections;

public class CoreObstacleGenerator : MonoBehaviour {

	[Range(0.5f,2f)]
	public float time = 1f;
	[System.Serializable]
	public struct Obstacle{
		public string name;
		public float distance;
	}
	public Obstacle[] obstacles;


	// Update is called once per frame
	void Start () {
		StartCoroutine(CreateObstacle());
	}

	IEnumerator CreateObstacle(){
		int random = Random.Range(0,obstacles.Length);
		GameObject temp = ObjectPool.Instance.GetGameObjectOfType(obstacles[random].name,true) as GameObject;
		temp.transform.parent = transform;
		//print (obstacles[0].distance);
		temp.transform.position = new Vector3(0,obstacles[random].distance, 0);
		temp.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
		yield return new WaitForSeconds(time);
		StartCoroutine(CreateObstacle());
	}
}
