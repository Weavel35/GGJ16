using UnityEngine;
using System.Collections;

public class ChangeZone : MonoBehaviour {
	
	public ChangeZone Destination;
	public Collider2D thisCollider { get; set; }
	// Use this for initialization
	void Start () {
		if(Destination == null)
			Debug.LogError("pas de destionation", this.gameObject);
		thisCollider = this.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		
		if(coll.tag.Equals("Player")){
			Debug.Log("player!");
		}
		player collisionPlayer = coll.GetComponent<player>();
		if(collisionPlayer!=null)
			if(!collisionPlayer.isTeleported ) {
				collisionPlayer.isTeleported=true;
				collisionPlayer.tpOrigin = thisCollider;
				
				collisionPlayer.transform.position=Destination.transform.position;
			}
	}

	void OnTriggerExit2D(Collider2D coll) {
		player collisionPlayer = coll.GetComponent<player>();
		if(collisionPlayer!=null)
			if(collisionPlayer.isTeleported && !collisionPlayer.tpOrigin.Equals(thisCollider)) {
				collisionPlayer.tpOrigin = null;
				collisionPlayer.isTeleported=false;
			}
	}
}
