using UnityEngine;
using System.Collections;

public class Succubus : Entities {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Spe_" + joystick) && state == "default") {
			debug = "Spe_";
		}


	}

    
}
