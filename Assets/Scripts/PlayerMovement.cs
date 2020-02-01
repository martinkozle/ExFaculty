﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove =  Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
                 
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("Crouched", true);
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            //animator.SetBool("Crouched", false);
        }
        
    }

    public void OnCrouch(bool crouched)
    {
        animator.SetBool("Crouched", crouched);
    }
    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    
}
