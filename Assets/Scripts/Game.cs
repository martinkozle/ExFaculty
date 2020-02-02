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

    public Quest questController;

    public NPC npc;

    private bool canShoot = false;

    private int[] slots = new int[9];

    public int selectedSlot = 1;

    public Weapon weapon;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        slots[1] = 1;
        LowerHand();
        timer = 0f;
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

    public void GiveItems(int metalFrags, int magnets)
    {
        questController.IncreaseTaskProgress("Collect metal fragments", metalFrags);
        slots[4] += metalFrags;
        hotbarSelector.GetComponent<ItemSelector>().GetItem(5);
        questController.IncreaseTaskProgress("Collect magnets", magnets);
        slots[5] += magnets;
        hotbarSelector.GetComponent<ItemSelector>().GetItem(6);
    }

    public void GiveLaser()
    {
        slots[2] = 1;
        hotbarSelector.GetComponent<ItemSelector>().GetItem(3);
    }

    public void GiveHardDisk()
    {
        slots[6] = 1;
        hotbarSelector.GetComponent<ItemSelector>().GetItem(7);
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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
        else if (Input.GetKeyDown("5") && slots[4] > 0)
        {
            LowerHand();
            selectedSlot = 5;
        }
        else if (Input.GetKeyDown("6") && slots[5] > 0)
        {
            LowerHand();
            selectedSlot = 5;
        }
        else if (Input.GetKeyDown("7") && slots[6] > 0)
        {
            LowerHand();
            selectedSlot = 6;
        }
        else if (Input.GetKeyDown("8") && slots[7] > 0)
        {
            LowerHand();
            selectedSlot = 7;
        }

        if (Input.GetKeyDown("e"))
        {
            npc.Talk();
            if (selectedSlot == 3 && timer >= 0.45f)
            {
                weapon.Shoot();
                timer = 0f;
            }

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
                if (tmf.transform.position.x - 2.5 < transform.position.x &&
                    tmf.transform.position.x + 2.5 > transform.position.x &&
                    tmf.transform.position.y > transform.position.y &&
                    questController.ContainsTask("Repair TMF") &&
                    !questController.IsComplete("Repair TMF"))
                {
                    SoundMagerScript.PlaySound("fix");
                    tmf.enabled = true;
                    tmfRuined.enabled = false;
                    questController.UpdateTaskProgress("Repair TMF", 1);
                }

                if (mfs.transform.position.x - 2.5 < transform.position.x &&
                    mfs.transform.position.x + 2.5 > transform.position.x &&
                    mfs.transform.position.y > transform.position.y &&
                    questController.ContainsTask("Repair MFS/FEIT") &&
                    !questController.IsComplete("Repair MFS/FEIT"))
                {
                    SoundMagerScript.PlaySound("fix");
                    mfs.enabled = true;
                    mfsRuined.enabled = false;
                    questController.UpdateTaskProgress("Repair MFS/FEIT", 1);
                }
            }
        }
        
    }

    IEnumerator Sleep(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}