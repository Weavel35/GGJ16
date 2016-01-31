using UnityEngine;
using System.Collections;

public class Zombie : Entities {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Spe_4")) {
			anim.SetBool("Spe",true);
		}
	}
}
