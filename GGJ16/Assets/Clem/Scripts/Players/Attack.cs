using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public PlayerDefaultCharacter player;

	// Use this for initialization
	void Start () {
		StartCoroutine(AttackTimeLine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AttackTimeLine() {
		yield return new WaitForSeconds(0.2f);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log(coll.gameObject.name);
		PlayerDefaultCharacter playerColl = coll.gameObject.GetComponent<PlayerDefaultCharacter>();
		
		if(playerColl != null) {
			if(playerColl.playerNum != player.playerNum) {
				playerColl.Hit(player.atk_pow);

			}
		}

	}

}
