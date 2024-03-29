﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public CharacterController2D cont;
    public Animator animator;
    private float horizontal;
    private int direction;
    private int health = 100;
    private float distance;
    public float speed = 10f;
    public void takeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Debug.Log(gameObject.name+"is dead");
            Die();
        }
        
        
    }
    
    private void Die()
    {
        animator.SetBool("isAlive", false);
        Destroy(gameObject, 0.5f);
    }

    private void FixedUpdate()
    {
        if (distance<1)
        {
            
            cont.Move(horizontal*Time.fixedDeltaTime,false,false);
            
        }
       
    }

    void Update()
    {
        distance = Math.Abs(player.transform.position.x-transform.position.x);
        if (transform.position.x - player.transform.position.x>0f)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
            
        }

        if (distance<1)
        {
            horizontal =direction * speed;
        }
        else
        {
            horizontal = 0f;
        }
    }
}
