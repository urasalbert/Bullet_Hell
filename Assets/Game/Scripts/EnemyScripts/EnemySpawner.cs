using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] internal List<Transform> spawners;
    [SerializeField] internal List<Transform> archerSpawners;

    [SerializeField] internal List<GameObject> enemyPrefabs; // A list holding multiple enemy prefabs
    [SerializeField] internal GameObject rangedEnemyPrefab;
    [SerializeField] internal GameObject archerEnemyPrefab;

    internal float spawnInterval = 5f;
    internal float rangedSpawnInterval = 10f;

    private float nextSpawnTime;
    private float nextRangedSpawnTime;
    private GameObject parentObject;

    private void Awake()
    {
        // Organize the hierarchy
        parentObject = GameObject.FindWithTag("Environment");
    }

    void Update()
    {
        if (GameTimer.Instance.minutes % 5 == 0 && GameTimer.Instance.minutes > 2) // If the time is more than 3 minutes
        {
            GameTimer.Instance.TriggerEvent("Spawn Rate Increased");
            spawnInterval -= 0.4f; // Decrease the spawn interval for melee enemies
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }

        if (Time.time >= nextRangedSpawnTime)
        {
            SpawnRangedEnemy();
            nextRangedSpawnTime = Time.time + rangedSpawnInterval;
        }
    }

    void SpawnRangedEnemy()
    {
        if (spawners.Count == 0) return; // If there are no spawners, just return
        else
        {
            int randomIndex = Random.Range(0, spawners.Count);
            Transform selectedSpawner = spawners[randomIndex];

            GameObject rangedEnemy = Instantiate(rangedEnemyPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);
        }
    }

    void SpawnEnemy()
    {
        if (spawners.Count == 0) return;

        int randomIndex = Random.Range(0, spawners.Count);
        int randomArcherIndex = Random.Range(0, archerSpawners.Count);

        Transform selectedSpawner = spawners[randomIndex];
        Transform selectedArcherSpawner = archerSpawners[randomArcherIndex];

        // Randomly select an enemy prefab
        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        GameObject enemy = Instantiate(selectedEnemyPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);

        GameObject archerenemy = Instantiate(archerEnemyPrefab, selectedArcherSpawner.position, selectedArcherSpawner.rotation, parentObject.transform);

        // Check Health Manager script for debugging
        EnemyHealthManager enemyLife = enemy.GetComponent<EnemyHealthManager>();
        if (enemyLife != null)
        {
            // Debug.Log("Enemy spawned with Life script.");
        }
        else
        {
            // Debug.LogError("Spawned enemy is missing the Life script.");
        }
    }
}
