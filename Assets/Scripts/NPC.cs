using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

public class Task
{
    private string taskName;
    private int progress;
    private int total;

    public Task(string taskName, int total)
    {
        this.taskName = taskName;
        this.total = total;
    }

    public void IncreaseProgress(int amount)
    {
        progress += amount;
    }

    public void UpdateProgress(int amount)
    {
        progress = amount;
    }

    public bool IsComplete()
    {
        return progress >= total;
    }

    public int GetProgress()
    {
        return progress;
    }

    public int GetTotal()
    {
        return total;
    }
}

public class Quest
{
    private Dictionary<string, Task> tasks;
    public bool submitted = false;

    public Quest(int numTasks)
    {
        tasks = new Dictionary<string, Task>(numTasks);
    }

    public void AddTask(string taskName, int amount)
    {
        tasks[taskName] = new Task(taskName, amount);
    }

    public void UpdateTaskProgress(string task, int amount)
    {
        tasks[task].UpdateProgress(amount);
    }

    public void IncreaseTaskProgress(string task, int amount)
    {
        tasks[task].IncreaseProgress(amount);
    }

    public bool IsComplete()
    {
        foreach (var task in tasks)
        {
            if (!task.Value.IsComplete())
            {
                return false;
            }
        }

        return true;
    }

    public List<Task> GetTasks()
    {
        return tasks.Values.ToList();
    }
}

public class NPC : MonoBehaviour
{
    public GameObject player;

    private string state = "beginning";

    private int currentQuest = 0;

    private Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        quest = new Quest(2);
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
        if (quest.submitted == true)
        {
            if (currentQuest == 0)
            {
                quest = new Quest(2);
                quest.AddTask("Collect metal fragments", 20);
                quest.AddTask("Collect magnets", 10);
                currentQuest++;
            }
            else if (currentQuest == 1)
            {
                quest = new Quest(1);
                quest.AddTask("Deliver the Master Hard Drive to the System Administrator", 1);
                currentQuest++;
            }
        }
    }
}