using UnityEngine;
using System.Collections;

public class MovePlayer : Entities {
	public Rigidbody2D rb2D;
	//public static bool developerConsoleVisible;
	public Animator anim;
	//Choisir le numéro du joueur
	public string joystick;
	public float speed;
	public string playerType;


	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.freezeRotation = true;
		anim = GetComponent<Animator>();
		anim.SetBool ("Virgin", false);
		//Défini la direction 0:top, 1:right, 2: bottom, 3:left
		anim.SetInteger ("Direction",0);
	}
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal_"+joystick);
		float y = Input.GetAxisRaw("Vertical_"+joystick);
		rb2D.velocity = new Vector2(x * speed, y * speed);

		//Debug.Log("x : "+x+", y : "+y);
		if (x == 0 && y == 0) {
			anim.SetBool("Move",false);
			/*if (face=="down") {
				//debug = "idleDown_"+state;

			}else if(face=="up"){
				//debug = "idleUp_"+state;
				animation.Play("idleUp_"+state); 
			}else if(face=="left"){
				//debug = "idleLeft_"+state;
				//animation.Play("idleLeft_"+state) 
			}else if(face=="right"){
				//debug = "idleRight_"+state;
				//animation.Play("idleRight_"+state) 
			}*/
			
		}
		else if(y>0 && x==0){
			//animation.Play("walkUp_"+state)
			//debug="walkUp_"+state;
			anim.SetInteger ("Direction",0);
		}
		else if(y<0 && x==0){
			//animation.Play("walkDown_"+state)
			//debug="walkDown_"+state;
			anim.SetInteger ("Direction",2);

		}
		if(x>0 && y==0){
			//animation.Play("walk_"+state)
			//debug="walk_"+state;
			anim.SetInteger ("Direction",1);
		}	
		else if(x<0 && y==0){
			//animation.Play("walk_"+state)
			//debug="walk_"+state;
			anim.SetInteger ("Direction",3);
		}
		//Debug.Log (debug);
	}
}