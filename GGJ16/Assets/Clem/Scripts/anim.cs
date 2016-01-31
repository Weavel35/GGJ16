using UnityEngine;
using System.Collections;

public class anim : MonoBehaviour {

	private SpriteRenderer sr;
	public Sprite[] sprites;
	public float changeTime = 1f;
	private float nextTime;
	int currentSprite = 0;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		nextTime = Time.time+changeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>nextTime) {
			currentSprite++;
			nextTime = Time.time+changeTime;
			sr.sprite = sprites[currentSprite%sprites.Length];
		}
	}
}
