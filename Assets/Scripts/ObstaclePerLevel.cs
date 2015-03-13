using UnityEngine;
using System.Collections;

public class ObstaclePerLevel : MonoBehaviour {
	public string[] obstacles;

	[Range(0,100)]
	public int probability = 50;

	[Range(0.5f,2f)]
	public float time = 1f;

	public float delay = 0f;
}
