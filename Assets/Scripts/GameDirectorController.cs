using System.Collections.Generic;
using UnityEngine;

public class GameDirectorController : MonoBehaviour
{
    List<GameObject> unusedEnemies = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> enemyPrefabs;
    public List<Transform> spawners;
    public float spawnCooldown;
    private float currentCooldown = 0;
    public int maxEnemies = 2;


    void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown > 0)
            return;

        if (enemies.Count >= maxEnemies)
            return;

        GameObject enemy;

        if (unusedEnemies.Count > 0)
        {
            enemy = RespawnEnemy(unusedEnemies[0]);
            unusedEnemies.RemoveAt(0);
        }
        else
        {
            enemy = SpawnEnemy();
        }

        enemies.Add(enemy);
        currentCooldown = spawnCooldown;
    }

    private GameObject SpawnEnemy()
    {
        LogsController.Log("Spawned new enemy");
        var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], GetSpawnPosition(), Quaternion.identity);
        enemy.GetComponent<HealthController>().OnDead += OnEnemyDead;
        return enemy;
    }

    private Vector3 GetSpawnPosition()
    {
        return spawners[Random.Range(0, spawners.Count)].position;
    }

    private GameObject RespawnEnemy(GameObject enemy)
    {
        LogsController.Log("Reused old enemy");
        enemy.transform.position = GetSpawnPosition();
        enemy.SetActive(true);
        return enemy;
    }

    private void OnEnemyDead(object sender, OnDeadEventArgs e)
    {
        e.gameObject.SetActive(false);
        enemies.Remove(e.gameObject);
        unusedEnemies.Add(e.gameObject);
    }
}
