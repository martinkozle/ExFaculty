using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnPoint;
    public GameObject player;
    public GameObject enemyPrefab;
    public int maxEnemies = 2;

    private List<GameObject> Enemies = new List<GameObject>();
    private float lastSpawn;


    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count < maxEnemies && Time.time - lastSpawn >= 5 &&
            Math.Abs(player.transform.position.x - spawnPoint.position.x) < 4 &&
            Math.Abs(player.transform.position.y-spawnPoint.position.y)<4)
        {
            Enemies.Add(Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation));
            lastSpawn = Time.time;
        }

        if (Enemies.Count>0)
        {
            Debug.Log(Enemies[0]);
        }

        if (Enemies.Count>1)
        {
            Debug.Log(Enemies[1]);
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].Equals(null))
            {
                Enemies.Remove(Enemies[i]);
            }
        }
    }
}