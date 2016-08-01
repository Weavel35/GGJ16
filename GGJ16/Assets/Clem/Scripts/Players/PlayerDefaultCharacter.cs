using UnityEngine;
using System.Collections;
using System;

public abstract class PlayerDefaultCharacter : MonoBehaviour {
	public enum PlayerType { Werewolf, Vampire, Succubus, Zombie };
	public enum Direction : int { top = 0, right = 1, bottom = 2, left = 3 };

	//Choisir le numéro du joueur
	public PlayerType playerType { get; set; }
	private Rigidbody2D rb2D;

	//public static bool developerConsoleVisible;
	private Animator animator { get; set; }

	//Move
	private bool isMoving;
	private bool is_atk = false;
	private Direction direction; //Défini la direction 0:top, 1:right, 2: bottom, 3:left
	public int playerNum;

	//ChangeZones
	public bool isTeleported { get; set; }

	public Collider2D tpOrigin { get; set; }
	private Vector2 Spawn;

	//stats
	private int PV_start;
	public int PV = 2;
	public int atk_pow = 1;
	public float atk_dist = 1;
	public float speed = 1.0f;
	public float invicibilityLength = 1.5f;

	private bool carryVirgin = false;
	private bool attck = false;
	private bool stunned = false;
	private bool invincible = false;

	public virtual void Start() {
		PV_start = PV;
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.freezeRotation = true;
		animator = GetComponent<Animator>();
		animator.SetBool("Virgin", false);
		//Défini la direction 0:top, 1:right, 2: bottom, 3:left
		direction = 0;
		animator.SetInteger("Direction", (int) direction);
		isMoving = false;
		carryVirgin = false;
		animator.SetBool("Move", isMoving);

		Spawn = this.transform.position;
		isTeleported = false;
	}
	void Update() {
		float x = Input.GetAxisRaw("Horizontal_" + playerNum);
		float y = Input.GetAxisRaw("Vertical_" + playerNum);

		if(is_atk) {
			rb2D.velocity = Vector2.zero;
			return;

		}

		rb2D.velocity = new Vector2(x, y).normalized * 5 * speed;

		if(Input.GetButtonDown("Att_" + playerNum)) {
			is_atk = true;
			StartCoroutine(Attack());
		}



		if(x == 0 && y == 0) {
			isMoving = false;
		} else {
			isMoving = true;
		}
		//orientation du personnage
		if(y > 0 && x == 0) {
			direction = Direction.top;
		} else if(y < 0 && x == 0) {
			direction = Direction.bottom;
		}
		if(x > 0 && y == 0) {
			direction = Direction.right;
		} else if(x < 0 && y == 0) {
			direction = Direction.left;
		}
		if(animator.GetInteger("Direction") != (int) direction) {
			animator.SetInteger("Direction", (int) direction);
		}

		if(animator.GetBool("Move") != isMoving && !is_atk) {
			animator.SetBool("Move", isMoving);
		}

	}

	public IEnumerator Attack() {

		Debug.Log("attack" + playerNum);
		GameObject attack = Instantiate(Resources.Load("Attack") as GameObject);
		attack.transform.position = this.transform.position + getVectorDirection();
		attack.GetComponent<Attack>().player = this;
		animator.SetBool("Attack", true);
		yield return new WaitForEndOfFrame();
		//Debug.Log(	animator.GetCurrentAnimatorStateInfo(0).length + " " + Time.timeSinceLevelLoad);
		//yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
		//Debug.Log(	Time.timeSinceLevelLoad);


		yield return new WaitForSeconds(0.3f);
		animator.SetBool("Attack", false);

		is_atk = false;

	}

	private Vector3 getVectorDirection() {
		switch(direction) {
			case Direction.top:
				return new Vector3(0, 1, 0);
			case Direction.bottom:
				return new Vector3(0, -1, 0);
			case Direction.right:
				return new Vector3(1, 0, 0);
			case Direction.left:
				return new Vector3(-1, 0, 0);
			default:
				Debug.Log("getAttackDirection what?");
				return new Vector3(0, 0, 0);
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Virgin") && !stunned && !invincible && !carryVirgin) {
			/*other.gameObject.SetActive (false);*/
			Destroy(other.gameObject);
			carryVirgin = true;
			animator.SetBool("Virgin", carryVirgin);
			Debug.Log("Virgin");
		} else if(other.gameObject.CompareTag("Pentacle") && carryVirgin) {
			/*other.gameObject.SetActive (false);*/
			carryVirgin = false;
			animator.SetBool("Virgin", carryVirgin);

			Debug.Log("Virgin pentacle");
		}
	}


	public void Hit(int damage) {
		if(invincible)
			return;
		invincible = true;

		animator.SetBool("Virgin", false);
		GameObject droppedVirgin = Instantiate(Resources.Load("Virgin") as GameObject);
		droppedVirgin.transform.position = this.transform.position;

		if(PV - damage < 0) {
			Dead();
		} else {
			PV -= damage;
		}
		StartCoroutine(invincibilityFrames());
		
	}

	private void Dead() {
		Debug.Log("dead " + this.gameObject.name);
		this.transform.position = Spawn;
		PV = PV_start;
		animator.SetBool("Virgin", false);
		direction = 0;
		animator.SetInteger("Direction", (int) direction);
		isMoving = false;
		isTeleported = false;
		carryVirgin = false;
		/*TODO 
		*	Vierge en fuite?
		*	
		*/
	}


	IEnumerator invincibilityFrames() {
		Color c = this.GetComponent<SpriteRenderer>().color;
		c.a = 0.25f;
		this.GetComponent<SpriteRenderer>().color = c;

		float startTime = Time.timeSinceLevelLoad;
		float blinkLenght = 0.3f;
		float blinkTime = startTime + blinkLenght;
		while(Time.timeSinceLevelLoad < startTime + invicibilityLength) {
			yield return new WaitForEndOfFrame();
			if(Time.timeSinceLevelLoad < blinkTime) {
				if(c.a == 0.75f) {
					c.a = 0.25f;
					this.GetComponent<SpriteRenderer>().color = c;
					blinkTime += blinkLenght;
				} else {
					c.a = 0.75f;
					this.GetComponent<SpriteRenderer>().color = c;
				}
			}
		}


		c.a = 1f;
		this.GetComponent<SpriteRenderer>().color = c;
		invincible = false;

	}

	public abstract void SpecialAction();

}
