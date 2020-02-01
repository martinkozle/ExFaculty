using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public SpriteRenderer loweredHand;

    public SpriteRenderer raisedHand;

    public SpriteRenderer weapon;

    private bool canShoot = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LowerHand();
    }
    
    void LowerHand()
    {
        loweredHand.enabled = true;
        raisedHand.enabled = false;
        weapon.enabled = false;
        canShoot = false;
    }
    
    void RaiseHand()
    {
        loweredHand.enabled = false;
        raisedHand.enabled = true;
        weapon.enabled = true;
        canShoot = true;
    }

    public bool CanShoot()
    {
        return canShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            LowerHand();
        }
        else if (Input.GetKeyDown("2"))
        {
            RaiseHand();
        }
    }
}
