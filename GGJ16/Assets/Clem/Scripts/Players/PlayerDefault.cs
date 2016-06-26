using UnityEngine;
using System.Collections;

public abstract class PlayerDefault : MonoBehaviour {
	public enum PlayerType { Werewolf, Vampire, Succubus, Zombie };
	
	//Choisir le numéro du joueur
	public PlayerType playerType;
	private Rigidbody2D rb2D;

	//public static bool developerConsoleVisible;
	private Animator animator { get; set; }

	//Move
	private bool isMoving;
	private bool is_atk = false;
	private int direction;
	public int joystickNum;	

	//stats
	public int PV = 2;
	public int atk_pow = 1;
	public float atk_dist = 1;
	public float speed = 1.0f;
	private bool carryVirgin = false;
	private bool attck = false;
	private bool stunned = false;


	public virtual void Start() {
		rb2D=GetComponent<Rigidbody2D>();
		rb2D.freezeRotation=true;
		animator=GetComponent<Animator>();
		animator.SetBool("Virgin", false);
		//Défini la direction 0:top, 1:right, 2: bottom, 3:left
		direction=0;
		animator.SetInteger("Direction", direction);
		isMoving=false;
		carryVirgin=false;
		animator.SetBool("Move", isMoving);


	}
	void Update() {
		float x = Input.GetAxisRaw("Horizontal_"+joystickNum);
		float y = Input.GetAxisRaw("Vertical_"+joystickNum);
		rb2D.velocity=new Vector2(x, y).normalized*5*speed;


		if(Input.GetButtonDown("Att_"+joystickNum))
			StartCoroutine(Attack());


		//Debug.Log("x : "+x+", y : "+y);
		if(x==0&&y==0) {
			isMoving=false;
		} else {
			isMoving=true;
		}

		if(y>0&&x==0) {
			direction=0;
		} else if(y<0&&x==0) {
			direction=2;
		}
		if(x>0&&y==0) {
			direction=1;
		} else if(x<0&&y==0) {
			direction=3;
		}
		if(animator.GetInteger("Direction")!=direction) {
			animator.SetInteger("Direction", direction);
		}

		if(animator.GetBool("Move")!=isMoving && !is_atk) {
			animator.SetBool("Move", isMoving);
		}

	}

	public IEnumerator Attack() {

		
		is_atk = true;
		animator.SetBool("Attack", true);
		yield return null;
		animator.SetBool("Attack", false	);

		yield return new WaitForSeconds(0.8f);
		is_atk = false;

	}

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Virgin")) {
			/*other.gameObject.SetActive (false);*/
			Destroy(other);
			carryVirgin = true;
			animator.SetBool("Virgin", carryVirgin);

			Debug.Log("coucou");
		} else if(other.gameObject.CompareTag("Pentacle") && carryVirgin) {
			/*other.gameObject.SetActive (false);*/
			carryVirgin = false;
			animator.SetBool("Virgin", carryVirgin);

			Debug.Log("coucou");
		}
	}

	public abstract void SpecialAction();
	
}
