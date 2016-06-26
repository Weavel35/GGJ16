using UnityEngine;
using System.Collections;

public class ChangeZone : MonoBehaviour {
	
	public ChangeZone Destination;
	public bool blocked = false;
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
		if(blocked)
			return;

		DefaultPlayer collisionPlayer = coll.GetComponent<DefaultPlayer>();
		if(collisionPlayer!=null)
			if(!collisionPlayer.isTeleported ) {
				collisionPlayer.isTeleported=true;
				collisionPlayer.tpOrigin = thisCollider;
				
				collisionPlayer.transform.position=Destination.transform.position;
			}
	}

	void OnTriggerExit2D(Collider2D coll) {
		DefaultPlayer collisionPlayer = coll.GetComponent<DefaultPlayer>();
		if(collisionPlayer!=null)
			if(collisionPlayer.isTeleported && !collisionPlayer.tpOrigin.Equals(thisCollider)) {
				collisionPlayer.tpOrigin = null;
				collisionPlayer.isTeleported=false;
			}
	}
}
