using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoing;
    public GameObject bulletPrefab;

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1")&&timer>=0.45f)
        {
            SoundMagerScript.PlaySound("shoot");
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (GetComponent<Game>().CanShoot())
        {
            Instantiate(bulletPrefab, firePoing.position, firePoing.rotation);
        }
    }
}