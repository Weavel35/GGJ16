using UnityEngine;
using System.Collections;

public abstract class Entities : MonoBehaviour {
	//Choisir le numéro du joueur
	public string joystick;	
	public Animator animator { get; set; }

	//stats
	public int PV = 2;
	public int atk_pow = 1;
	public int atk_dist = 1;
	public float speed = 1.0f;
	public bool carryVirgin = false;
	public bool attck = false;
	public bool stunned = false;
	
	// Use this for initialization
	void Start () {
		animator=GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetButtonDown("Att_"+joystick))
			StartCoroutine(Attack());*/

	}

/*	private IEnumerator Attack() {

		Debug.Log("nopenope");
		attck = true;
		animator.SetBool("Attack", true);
		yield return null;
		animator.SetBool("Attack", false	);

		yield return new WaitForSeconds(0.8f);
		attck = false;
		
	}*/
}
