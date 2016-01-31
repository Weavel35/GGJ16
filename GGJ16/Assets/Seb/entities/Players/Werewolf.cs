using UnityEngine;
using System.Collections;

public class Werewolf : MonoBehaviour {
	public Animator anim;
	//public MonoBehaviour playerAttacks;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Spe_2")) {
			anim.SetBool("Spe",true);
		}
	}

}
