using UnityEngine;
using System.Collections;

public class PanelBehaviour : MonoBehaviour {

	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	public void ToogleAnim () {
		anim.SetBool("ToogleBoard" , !anim.GetBool("ToogleBoard"));
	}
}
