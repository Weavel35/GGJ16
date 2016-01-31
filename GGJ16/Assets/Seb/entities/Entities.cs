using UnityEngine;
using System.Collections;

public abstract class Entities : MonoBehaviour {
	public float speed;
	//Choisir le numéro du joueur
	public string joystick;	
	public int cureHealth = 1;	
	public void Damage(int dmg)
    {
        cureHealth -= dmg;

    }
<<<<<<< HEAD
=======
	
>>>>>>> seb
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
