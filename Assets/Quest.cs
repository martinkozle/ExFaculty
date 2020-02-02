﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;

public class Task
{
    public string taskName;
    public int progress;
    public int total;

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
}

public class Quest : MonoBehaviour
{
    public GameObject questTracker;
    public GameObject textObject;
    private Dictionary<string, Task> tasks = new Dictionary<string, Task>();
    private bool submitted = false;

    public bool IsSubmitted()
    {
        return submitted;
    }

    public void RemoveTasks()
    {
        tasks = new Dictionary<string, Task>();
        textObject.GetComponent<TextMeshProUGUI>().SetText("");
    }

    public void AddTask(string taskName, int amount)
    {
        tasks[taskName] = new Task(taskName, amount);
        SetText();
    }

    public void SetText()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var task in tasks)
        {
            sb.Append(task.Value.taskName + "\t" + task.Value.progress + "/" + task.Value.total + "\n");
        }
        textObject.GetComponent<TextMeshProUGUI>().SetText(sb.ToString());
    }

    public void UpdateTaskProgress(string task, int amount)
    {
        tasks[task].UpdateProgress(amount);
        SetText();
    }

    public void IncreaseTaskProgress(string task, int amount)
    {
        tasks[task].IncreaseProgress(amount);
        SetText();
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

    public void Update()
    {
    }
}