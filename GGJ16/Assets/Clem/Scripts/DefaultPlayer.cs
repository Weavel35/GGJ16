using UnityEngine;


public class DefaultPlayer : MonoBehaviour {

	//Position
	
	public bool isTeleported { get; set; }
	public Collider2D tpOrigin { get; set; }
	private Vector2 Spawn;

	


	// Use this for initialization
	void Start () {
		Spawn = this.transform.position; 
		isTeleported = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
