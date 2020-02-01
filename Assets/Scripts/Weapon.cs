using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoing;
    public GameObject bulletPrefab;
    public GameObject inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (GetComponent<Inventory>().CanShoot())
        {
            Instantiate(bulletPrefab, firePoing.position, firePoing.rotation);
        }
    }
}