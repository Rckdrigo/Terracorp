using UnityEngine;
using System.Collections;

public class PolarGrid : MonoBehaviour {

	public bool drawPolarGrid;
	[Range(5,45)]
	public int angleDelta = 15;
	[Range(1,100)]
	public int radiousDelta = 2;
	public Color color = new Color(1,1,1,0.2f);

	void OnDrawGizmos(){
		if(drawPolarGrid){
			
			Gizmos.color =  color; 
			
			for(int i = 0 ; i < 360; i+=angleDelta)
				Gizmos.DrawRay(Vector3.zero,new Vector3(Mathf.Cos(Mathf.PI * i/180),Mathf.Sin(Mathf.PI * i/180),0)*100);
			
			for(int i = radiousDelta; i < 50 ; i+=radiousDelta)
				Gizmos.DrawWireSphere(Vector3.zero,i);	
		}
	}
}
