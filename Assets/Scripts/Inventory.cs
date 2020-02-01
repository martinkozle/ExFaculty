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

    private int[] slots = new int[9];

    private int selectedSlot = 1;

    // Start is called before the first frame update
    void Start()
    {
        slots[1] = 1;
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
            selectedSlot = 1;
        }
        else if (Input.GetKeyDown("2") && slots[1] > 0)
        {
            LowerHand();
            RaiseHand();
            miningDrill.enabled = true;
            selectedSlot = 2;
        }
        else if (Input.GetKeyDown("3") && slots[2] > 0)
        {
            LowerHand();
            RaiseHand();
            laserGun.enabled = true;
            canShoot = true;
            selectedSlot = 3;
        }
        else if (Input.GetKeyDown("4") && slots[3] > 0)
        {
            LowerHand();
            RaiseHand();
            
        }

        if (Input.GetKeyDown("e") && selectedSlot == 2)
        {
            var tilePos = map.WorldToCell(new Vector2(
                transform.position.x + GetComponent<CharacterController2D>().getDirection() / 2.0f,
                transform.position.y));
            if (map.GetTile(tilePos).name == "MeteorBlock")
                map.SetTile(tilePos, null);
            if (map.GetTile(tilePos).name == "Crate")
            {
                map.SetTile(tilePos, null);
                slots[3] = 1;
            }
        }
    }
}