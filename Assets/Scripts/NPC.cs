using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public GameObject player;

    public SpriteRenderer quest1;

    public SpriteRenderer quest2;

    public SpriteRenderer quest3;

    public SpriteRenderer QM;
    
    public SpriteRenderer EM;
    
    public SpriteRenderer QMG;
    
    private int currentQuest = 0;

    public Quest questController;

    private bool talking = false;

    private bool hasQuest = true;
    
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

        if (hasQuest)
        {
            QM.enabled = false;
            EM.enabled = true;
            QMG.enabled = false;
        }
        else if (questController.IsComplete())
        {
            QM.enabled = true;
            EM.enabled = false;
            QMG.enabled = false;
        }
        else
        {
            QM.enabled = false;
            EM.enabled = false;
            QMG.enabled = true;
        }
        
    }

    public Quest GetActiveQuest()
    {
        return questController;
    }

    private bool InRange()
    {
        return Mathf.Abs(transform.position.x - player.transform.position.x) < 0.5 &&
               Mathf.Abs(transform.position.y - player.transform.position.y) < 1;
    }

    // Update is called once per frame
    public void Talk()
    {
        
        Debug.Log(InRange());
        if (questController.IsComplete() == true && InRange())
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
                player.GetComponent<Game>().GiveLaser();
                questController.RemoveTasks();
                questController.AddTask("Collect metal fragments", 20);
                questController.AddTask("Collect magnets", 10);
                quest2.enabled = true;
            }
            else if (currentQuest == 2)
            {
                player.GetComponent<Game>().GiveHardDisk();
                questController.RemoveTasks();
                questController.AddTask("Deliver the Master Hard Drive to the System Administrator", 1);
                quest3.enabled = true;
            }
            currentQuest++;
        }
    }

    public void StopTalking()
    {
        talking = false;
        questController.DisplayQuest();
        quest1.enabled = false;
        quest2.enabled = false;
        quest3.enabled = false;
        hasQuest = false;
    }
}