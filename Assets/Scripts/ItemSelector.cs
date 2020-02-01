using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer[] hotbarSelectors;
    public SpriteRenderer[] hotbarItems;
    private float startingX;
    private float startingY;
    
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        Debug.Log(startingX);
        startingX = transform.position.y;
    }

    void MoveHotbarSelector(int slot)
    {
        for (int i = 0; i < hotbarSelectors.Length; i++)
        {
            if (i == slot - 1)
            {
                hotbarSelectors[i].enabled = true;
            }
            else
            {
                hotbarSelectors[i].enabled = false;
            }
        }
    }

    public void GetItem(int slot)
    {
        hotbarItems[slot - 1].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHotbarSelector(player.GetComponent<Game>().selectedSlot);
    }
}
