using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

    private Succubus player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("").GetComponent<Succubus>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag(""))
        {
            //player.Damage(1);
        }

    }

}
