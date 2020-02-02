using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
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

    private void Start()
    {
        player=GameObject.Find("Player");
    }

    private void Die()
    {
        animator.SetBool("isAlive", false);
        Destroy(gameObject, 0.5f);
    }

    private void FixedUpdate()
    {
        if (distance<4)
        {
            
            cont.Move(horizontal*Time.fixedDeltaTime,false,false);
            
        }
       
    }

    private void Update()
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

        if (distance<4)
        {
            horizontal =direction * speed;
        }
        else
        {
            horizontal = 0f;
        }
    }
}
