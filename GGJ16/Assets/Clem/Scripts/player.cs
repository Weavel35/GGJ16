using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public bool isTeleported { get; set; }
	public Collider2D tpOrigin { get; set; }

	// Use this for initialization
	void Start () {
		isTeleported = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
