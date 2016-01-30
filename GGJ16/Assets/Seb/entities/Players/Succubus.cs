using UnityEngine;
using System.Collections;

public class NewBehaviourScript : Entities {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Att_" + joystick)) {
			debug = "Att_" + state;
		}
		if (Input.GetAxisRaw ("Spe_" + joystick) && state == "default") {
			debug = "Spe_";
		}
		if (Input.GetAxisRaw ("Act_" + joystick)) {
			debug = "Act_" + state;
		}
	}
}
