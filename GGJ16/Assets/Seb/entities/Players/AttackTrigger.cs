﻿using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int dmg = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger !=true && col.CompareTag("Ennemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
        }
    }
}
