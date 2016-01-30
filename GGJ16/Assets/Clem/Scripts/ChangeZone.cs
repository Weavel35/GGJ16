using UnityEngine;
using System.Collections;

public class ChangeZone : MonoBehaviour {
	
	 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.tag.Equals("Player")){
			Debug.Log("player!");
		}
	}
}
