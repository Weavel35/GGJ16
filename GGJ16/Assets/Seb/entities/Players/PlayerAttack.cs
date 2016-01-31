﻿using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCD = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
		//if (Input.GetButtonDown("Att_"+joystick) && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;

            }
        }

        anim.SetBool("Attack", true);


    }

}
