using UnityEngine;
using System.Collections;

public class CoreRotationBehaviour : MonoBehaviour {

	[Range(10.0f,100.0f)]
	public float rotSpeed = 10;
	public float angleTrigger = 30.0f;

	void OnDrawGizmo(){
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position,transform.right*100);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward,rotSpeed * Time.deltaTime);
		//print((int)(Vector3.Angle(transform.right,Vector3.right)%angleTrigger)== 0? true : false);
	}
}
