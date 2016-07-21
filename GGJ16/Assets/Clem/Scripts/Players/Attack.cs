using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public PlayerDefault player;

	// Use this for initialization
	void Start () {
		StartCoroutine(AttackTimeLine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AttackTimeLine() {
		yield return new WaitForSeconds(2f);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.gameObject.name);
		PlayerDefault playDef = collision.gameObject.GetComponent<PlayerDefault>();
		if(playDef != null) {
			Debug.Log(playDef.playerNum);
		}

		  foreach (ContactPoint contact in collision.contacts) {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
	}
}
