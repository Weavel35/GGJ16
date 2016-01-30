using UnityEngine;
using System.Collections;

public class MovePlayer : Entities {
	public Rigidbody2D rb2D;
	//public static bool developerConsoleVisible;
	public Animation anim;
	public string debug;
	//orientation du personnage
	public string face;


	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.freezeRotation = true;
		anim = GetComponent<Animation>();
	}
	void Update()
	{
		float x = Input.GetAxisRaw("Horizontal_"+joystick);
		float y = Input.GetAxisRaw("Vertical_"+joystick);
		rb2D.velocity = new Vector2(x * speed, y * speed);

		//Debug.Log("x : "+x+", y : "+y);
		if (x == 0 && y == 0) {
			if (face=="down") {
				debug = "idleDown_"+state;
				//animation.Play("idleDown_"+state)
			}else if(face=="up"){
				debug = "idleUp_"+state;
				//animation.Play("idleUp_"+state) 
			}else if(face=="left"){
				debug = "idleLeft_"+state;
				//animation.Play("idleLeft_"+state) 
			}else if(face=="right"){
				debug = "idleRight_"+state;
				//animation.Play("idleRight_"+state) 
			}
			
		}
		else if(y>0 && x==0){
			//animation.Play("walkUp_"+state)
			debug="walkUp_"+state;
			face = "up";
		}
		else if(y<0 && x==0){
			//animation.Play("walkDown_"+state)
			debug="walkDown_"+state;
			face = "down";

		}
		if(x>0 && y==0){
			//animation.Play("walk_"+state)
			debug="walk_"+state;
			face = "right";
			transform.eulerAngles = new Vector3(0, 0, 0);//Normal
		}	
		else if(x<0 && y==0){
			//animation.Play("walk_"+state)
			debug="walk_"+state;
			face = "left";
			transform.eulerAngles = new Vector3(0, 180, 0); //Flipped
		}
		Debug.Log (debug);
	}
}