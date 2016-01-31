using UnityEngine;
using System.Collections;

public class BehaviorVillager : MonoBehaviour {
	/*public int playerX;
	public int playerY;*/
	public int speed;
	public Animator anim;
	private float range;
	private Collider2D target;
	private int Direction;
	private float x;
	private float xtarget;
	private float ytarget;
	private float y; 
	// Use this for initialization
	void Start () {
		//transform.position = new Vector3(playerX, playerY);
		anim = GetComponent<Animator>();
		Direction = 0;
		anim.SetInteger ("Direction",Direction);
		anim.SetBool ("Move", false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void getOrientation(){
		xtarget = target.transform.position.x;
		ytarget = target.transform.position.y;
		x = transform.position.x;
		y = transform.position.y;
		if (xtarget <= x) {
			if (Mathf.Abs (x) - Mathf.Abs (xtarget) > Mathf.Abs (y) - Mathf.Abs (ytarget)) {
				Direction = 3;
			} else if (ytarget > y) {
				Direction = 0;
			} else {
				Direction = 2;
			}
		} else {
			if (Mathf.Abs(x)-Mathf.Abs(xtarget)>Mathf.Abs(y)-Mathf.Abs(ytarget)){
				Direction = 1;
			}
			else if(ytarget>y){
					Direction = 0;
			}else{
					Direction=2;
			}
		}
		if (anim.GetInteger ("Direction") != Direction) {
			anim.SetInteger ("Direction", Direction);
		}
		anim.SetBool ("Move", true);

	}
	void OnTriggerEnter2D(Collider2D player){
		x = transform.position.x;
		y = transform.position.y;

		if (!target) {
			target = player;
			getOrientation ();
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.Translate (Vector2.MoveTowards (transform.position, player.transform.position, range) * speed * Time.deltaTime);
			Debug.Log (range);
		}
	}
	void OnTriggerStay2D(Collider2D player){

		if (target==null) {
			target = player;
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.Translate (Vector2.MoveTowards (transform.position, player.transform.position, range) * speed * Time.deltaTime);
		}
		else if (player.name==target.name){
			range = Vector2.Distance (transform.position, player.transform.position);
			transform.position= Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		}
		getOrientation ();
	}
	void OnTriggerExit2D(Collider2D player){
		if (player.name == target.name) {
			target = null;
			anim.SetBool ("Move", false);
		}

	}
}
