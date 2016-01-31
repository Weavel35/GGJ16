using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
    public int dmg = 1;
	public Animator animSlash;
	private int direction;
	void start(){
		animSlash = GetComponent<Animator>();
	}
	/*void update(){
		direction = MovePlayer.anim.GetInteger ("Direction");
		if (direction == 0) {
			transform.position
		}
	}*/
	void OnTriggerEnter2D (Collider2D col){
		/*animSlash.SetBool("Attak",true);*/
		if (col.isTrigger !=true)
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
