using UnityEngine;
using System.Collections;

public class Vampire : MonoBehaviour {

	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Spe_1")) {
			anim.SetBool("Spe",true);
		}
	}
}
