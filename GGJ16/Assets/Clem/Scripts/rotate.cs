using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public float changeTime = 1f;
	private float nextTime;
	// Use this for initialization
	void Start () {
		nextTime = Time.time+changeTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>nextTime) {
			this.transform.Rotate(new Vector3(0f, 0f,( 72f/360f)/Time.deltaTime));
			nextTime = Time.time+changeTime;
		}
	}
}
