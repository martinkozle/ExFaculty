using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Inventory : MonoBehaviour
{
    public SpriteRenderer loweredHand;

    public SpriteRenderer raisedHand;

    public SpriteRenderer laserGun;

    public SpriteRenderer miningDrill;

    public Tilemap map;

    private bool canShoot = false;

    private int[] items = new int[9];

    // Start is called before the first frame update
    void Start()
    {
        LowerHand();
    }

    void LowerHand()
    {
        loweredHand.enabled = true;
        raisedHand.enabled = false;
        laserGun.enabled = false;
        canShoot = false;
        miningDrill.enabled = false;
    }

    void RaiseHand()
    {
        loweredHand.enabled = false;
        raisedHand.enabled = true;
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
            LowerHand();
            RaiseHand();
            miningDrill.enabled = true;
        }
        else if (Input.GetKeyDown("3"))
        {
            LowerHand();
            RaiseHand();
            laserGun.enabled = true;
            canShoot = true;
        }

        if (Input.GetKeyDown("e"))
        {
            var tilePos = map.WorldToCell(new Vector2(
                transform.position.x + GetComponent<CharacterController2D>().getDirection(),
                transform.position.y));
            map.SetTile(tilePos, null);
        }
    }
}