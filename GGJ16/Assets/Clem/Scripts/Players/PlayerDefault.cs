using UnityEngine;
using System.Collections;

public abstract class PlayerDefault : MonoBehaviour {
	public enum PlayerType { Werewolf, Vampire, Succubus, Zombie };
	public enum Direction:int {  top = 0, right = 1, bottom = 2, left = 3};

	//Choisir le numéro du joueur
	public PlayerType playerType { get; set; }
	private Rigidbody2D rb2D;

	//public static bool developerConsoleVisible;
	private Animator animator { get; set; }

	//Move
	private bool isMoving;
	private bool is_atk = false;
	private Direction direction; //Défini la direction 0:top, 1:right, 2: bottom, 3:left
	public int joystickNum;

	//ChangeZones
	public bool isTeleported { get; set; }
	public Collider2D tpOrigin { get; set; }
	private Vector2 Spawn;

	//stats
	public int PV = 2;
	public int atk_pow = 1;
	public float atk_dist = 1;
	public float speed = 1.0f;
	private bool carryVirgin = false;
	private bool attck = false;
	private bool stunned = false;


	public virtual void Start() {
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
		float x = Input.GetAxisRaw("Horizontal_" + joystickNum);
		float y = Input.GetAxisRaw("Vertical_" + joystickNum);
		rb2D.velocity = new Vector2(x, y).normalized * 5 * speed;

		if(is_atk)
			return;


		if(Input.GetButtonDown("Att_" + joystickNum))
			StartCoroutine(Attack());



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
		if(animator.GetInteger("Direction") !=(int) direction) {
			animator.SetInteger("Direction",(int) direction);
		}

		if(animator.GetBool("Move") != isMoving && !is_atk) {
			animator.SetBool("Move", isMoving);
		}

	}

	public IEnumerator Attack() {

		Debug.Log("attack" + joystickNum);
		is_atk = true;
		animator.SetBool("Attack", true);
		Debug.Log(	Time.timeSinceLevelLoad);
		yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
		Debug.Log(	Time.timeSinceLevelLoad);

		while(animator.GetBool("Attack")) {
			//if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Animator.IsInTransition(0))
			
			
		}

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
