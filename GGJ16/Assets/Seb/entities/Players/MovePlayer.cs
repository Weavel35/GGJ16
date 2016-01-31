using UnityEngine;
using System.Collections;

public class MovePlayer : Entities {
	public Rigidbody2D rb2D;
	//public static bool developerConsoleVisible;
	public Animator anim;
	//Choisir le numéro du joueur
	public string playerType;
	private bool isMoving;
	private int Direction;


	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.freezeRotation = true;
		anim = GetComponent<Animator>();
		anim.SetBool ("Virgin", false);
		//Défini la direction 0:top, 1:right, 2: bottom, 3:left
		Direction = 0;
		anim.SetInteger ("Direction",Direction);
		isMoving = false;
		anim.SetBool ("Move", isMoving);


	}
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal_"+joystick);
		float y = Input.GetAxisRaw("Vertical_"+joystick);
		rb2D.velocity = new Vector2(x * speed, y * speed);

		//Debug.Log("x : "+x+", y : "+y);
		if (x == 0 && y == 0) {
				isMoving = false;
		} else {
			isMoving = true;
		}

		if(y>0 && x==0){
			Direction = 0;	
		}
		else if(y<0 && x==0){
			Direction = 2;
		}
		if(x>0 && y==0){
			Direction=1;
		}	
		else if(x<0 && y==0){
			Direction=3;
		}
		if (anim.GetInteger("Direction")!= Direction){
			anim.SetInteger ("Direction",Direction);
		}
		if (anim.GetBool ("Move") != isMoving) {
			anim.SetBool ("Move",isMoving);
		}

	}
}