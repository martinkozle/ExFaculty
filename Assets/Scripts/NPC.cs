using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Serialization;


public class NPC : MonoBehaviour
{
    public GameObject player;

    public SpriteRenderer quest1;

    public SpriteRenderer quest2;

    public SpriteRenderer quest3;

    private int currentQuest = 0;

    public Quest questController;

    private bool talking = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (!InRange() && talking)
        {
            StopTalking();
        }
    }

    public Quest GetActiveQuest()
    {
        return questController;
    }

    private bool InRange()
    {
        return Mathf.Abs(transform.position.x - player.transform.position.x) < 0.5 &&
               Mathf.Abs(transform.position.y - player.transform.position.y) < 0.5;
    }

    // Update is called once per frame
    public void Talk()
    {
        
        Debug.Log(InRange());
        if (questController.IsSubmitted() == true && InRange())
        {
            talking = true;
            if (currentQuest == 0)
            {
                questController.RemoveTasks();
                questController.AddTask("Repair TMF", 1);
                questController.AddTask("Repair MFS/FEIT", 1);
                quest1.enabled = true;
            }
            else if (currentQuest == 1)
            {
                questController.RemoveTasks();
                questController.AddTask("Collect metal fragments", 20);
                questController.AddTask("Collect magnets", 10);
                currentQuest++;
                quest2.enabled = true;
            }
            else if (currentQuest == 2)
            {
                questController.RemoveTasks();
                questController.AddTask("Deliver the Master Hard Drive to the System Administrator", 1);
                currentQuest++;
                quest3.enabled = true;
            }
        }
    }

    public void StopTalking()
    {
        talking = false;
        questController.DisplayQuest();
        quest1.enabled = false;
        quest2.enabled = false;
        quest3.enabled = false;
    }
}