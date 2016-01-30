using UnityEngine;
using System.Collections;

public class BehaviorVillager : MonoBehaviour {
	/*public int playerX;
	public int playerY;*/
	public int speed;
	private float range;
	private Collider2D target;
	// Use this for initialization
	void Start () {
		//transform.position = new Vector3(playerX, playerY);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D player){
		if (!target) {
			target = player;
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.Translate (Vector2.MoveTowards (transform.position, player.transform.position, range) * speed * Time.deltaTime);
		}
	}
	void OnTriggerStay2D(Collider2D player){
		/*Debug.Log ("Current: "+target);
		Debug.Log ("Other :"+player.name);*/
		if (target==null) {
			target = player;
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.Translate (Vector2.MoveTowards (transform.position, player.transform.position, range) * speed * Time.deltaTime);
		}
		else if (player.name==target.name){
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.position= Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
			//Debug.Log (player.transform.position);
		}
	}
	void OnTriggerExit2D(Collider2D player){
		if (player.name == target.name) {
			target = null;
		}

	}
}
