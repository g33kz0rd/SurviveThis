using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorController : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> enemyPrefabs;
    public List<Transform> spawners;
    public float spawnCooldown;
    private float currentCooldown = 0;


    void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown > 0)
            return;

        var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawners[Random.Range(0, spawners.Count)]);
        enemies.Add(enemy);
        currentCooldown = spawnCooldown;

    }
}
