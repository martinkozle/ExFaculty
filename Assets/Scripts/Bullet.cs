using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject explosion;
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject,10f);
    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        
        Enemy enemy = info.GetComponent<Enemy>();
        if (enemy!=null)
        {
            enemy.takeDamage(damage);
        }
        GameObject tmpExp = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(tmpExp, 0.25f);
    }
    
   
    // Update is called once per frame
   
}

