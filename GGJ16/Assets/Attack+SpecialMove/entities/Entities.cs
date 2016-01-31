using UnityEngine;
using System.Collections;

public abstract class Entities : MonoBehaviour {
	//etat du personnage, prend "default ou "virgin", animation nommée en accord
	public string state="default";
	public float speed;
	//Choisir le numéro du joueur
	public string joystick;
	public string debug;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
