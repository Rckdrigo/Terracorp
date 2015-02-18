using UnityEngine;
using System.Collections;

public class CoreRotationBehaviour : MonoBehaviour {

	[Range(10.0f,50.0f)]
	public float rotSpeed = 10;
	public float angleTrigger = 30.0f;

	void Start(){
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position,transform.right*100);

		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(0),0,0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 15/180),Mathf.Sin(Mathf.PI * 15/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 30/180),Mathf.Sin(Mathf.PI * 30/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 45/180),Mathf.Sin(Mathf.PI * 45/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 60/180),Mathf.Sin(Mathf.PI * 60/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 75/180),Mathf.Sin(Mathf.PI * 75/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 90/180),Mathf.Sin(Mathf.PI * 90/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 105/180),Mathf.Sin(Mathf.PI * 105/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 120/180),Mathf.Sin(Mathf.PI * 120/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 135/180),Mathf.Sin(Mathf.PI * 135/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 150/180),Mathf.Sin(Mathf.PI * 150/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * 165/180),Mathf.Sin(Mathf.PI * 165/180),0)*100);
		Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI),Mathf.Sin(Mathf.PI),0)*100);


		//for(int i = 0; i <= 2; i += 1/6){
		//	Gizmos.DrawRay(transform.position,new Vector3(Mathf.Cos(Mathf.PI * i),Mathf.Sin(Mathf.PI * i),0)*20);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward,rotSpeed * Time.deltaTime);
		//print((int)(Vector3.Angle(transform.right,Vector3.right)%angleTrigger)== 0? true : false);
	}
}
