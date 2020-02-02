﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMagerScript : MonoBehaviour
{

    public static AudioClip jumpSound, shootSound, fixSound,deathSound,drillMusic;
    public static AudioSource audioSource;
        
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        shootSound = Resources.Load<AudioClip>("shoot");
        fixSound = Resources.Load<AudioClip>("fix");
        deathSound = Resources.Load<AudioClip>("death");
        drillMusic = Resources.Load<AudioClip>("drill");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "fix":
                audioSource.PlayOneShot(fixSound);
                break;
            case "shoot":
                audioSource.PlayOneShot(shootSound);
                break;
            case "death":
                audioSource.PlayOneShot(deathSound);
                break;
            case "drill":
                audioSource.PlayOneShot(drillMusic);
                break;
                
        }
    }
}
