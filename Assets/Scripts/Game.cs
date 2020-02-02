using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Game : MonoBehaviour
{
    public SpriteRenderer loweredHand;

    public SpriteRenderer raisedHand;

    public SpriteRenderer laserGun;

    public SpriteRenderer miningDrill;

    public SpriteRenderer hammer;

    public SpriteRenderer tmf;

    public SpriteRenderer tmfRuined;

    public SpriteRenderer mfs;

    public SpriteRenderer mfsRuined;

    public Tilemap map;

    public GameObject hotbarSelector;

    public NPC npc;

    private bool canShoot = false;

    private int[] slots = new int[9];

    public int selectedSlot = 1;

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
        hammer.enabled = false;
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
            hammer.enabled = true;
            selectedSlot = 4;
        }

        if (Input.GetKeyDown("e"))
        {
            npc.Talk();
            if (selectedSlot == 2)
            {
                var tilePos = map.WorldToCell(new Vector2(
                    transform.position.x + GetComponent<CharacterController2D>().getDirection() / 2.0f,
                    transform.position.y));
                var tile = map.GetTile(tilePos);
                if (tile != null && tile.name == "MeteorBlock")
                    map.SetTile(tilePos, null);
                if (tile != null && tile.name == "Crate")
                {
                    map.SetTile(tilePos, null);
                    slots[3] = 1;
                    hotbarSelector.GetComponent<ItemSelector>().GetItem(4);
                }
            }

            if (selectedSlot == 4)
            {
                SoundMagerScript.PlaySound("fix");
                if (tmf.transform.position.x - 2.5 < transform.position.x &&
                    tmf.transform.position.x + 2.5 > transform.position.x &&
                    tmf.transform.position.y > transform.position.y)
                {
                    tmf.enabled = true;
                    tmfRuined.enabled = false;
                }

                if (mfs.transform.position.x - 2.5 < transform.position.x &&
                    mfs.transform.position.x + 2.5 > transform.position.x &&
                    mfs.transform.position.y > transform.position.y)
                {
                    mfs.enabled = true;
                    mfsRuined.enabled = false;
                }
            }
        }
    }
}