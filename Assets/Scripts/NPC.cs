using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;



public class NPC : MonoBehaviour
{
    public GameObject player;

    private string state = "beginning";

    private int currentQuest = 0;

    public Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        quest.RemoveTasks();
        quest.AddTask("Repair TMF", 1);
        quest.AddTask("Repair MFS/FEIT", 1);
    }

    public Quest GetActiveQuest()
    {
        return quest;
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.IsSubmitted() == true)
        {
            if (currentQuest == 0)
            {
                quest.RemoveTasks();
                quest.AddTask("Collect metal fragments", 20);
                quest.AddTask("Collect magnets", 10);
                currentQuest++;
            }
            else if (currentQuest == 1)
            {
                quest.RemoveTasks();
                quest.AddTask("Deliver the Master Hard Drive to the System Administrator", 1);
                currentQuest++;
            }
        }
    }
}