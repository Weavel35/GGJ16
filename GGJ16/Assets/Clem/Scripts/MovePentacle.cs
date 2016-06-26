using UnityEngine;
using System.Collections;

public class MovePentacle : MonoBehaviour {
	
	public float lerpSpeed = 0.1f;
	public Transform[] waypoints;
	private int numPoint = 0;
	private float startTime;
	private float journeyLength;
	// Use this for initialization
	void Start () {
		startTime =Time.time;
		this.transform.position = waypoints[0].position;
		 journeyLength = Vector3.Distance(waypoints[0].position, waypoints[1].position);
	}
	
	// Update is called once per frame
	void Update () {

		

		float distCovered = (Time.time - startTime) * lerpSpeed;
        float fracJourney = distCovered / journeyLength;

		if(fracJourney>=1f) {
			startTime = Time.time;
			numPoint = (numPoint+1)%waypoints.Length;
			distCovered = (Time.time - startTime) * lerpSpeed;
			fracJourney = distCovered / journeyLength;
		} 

        transform.position = Vector3.Lerp(waypoints[0].position, waypoints[1].position, fracJourney);

		this.transform.position = Vector3.Lerp(waypoints[numPoint%waypoints.Length].position,waypoints[(numPoint+1)%waypoints.Length].position, fracJourney);
	}
}
