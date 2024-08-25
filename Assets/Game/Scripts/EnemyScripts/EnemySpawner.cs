using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] internal List<Transform> spawners;
    [SerializeField] internal List<Transform> archerSpawners;

    [SerializeField] internal List<GameObject> enemyPrefabs; // A list holding multiple enemy prefabs
    [SerializeField] internal GameObject rangedEnemyPrefab;
    [SerializeField] internal GameObject archerEnemyPrefab;
    [SerializeField] internal GameObject bossPrefab;

    internal float spawnInterval = 10f;
    internal float rangedSpawnInterval = 15f;

    private float nextSpawnTime;
    private float nextRangedSpawnTime;
    private GameObject parentObject;

    private void Awake()
    {
        // Organize the hierarchy
        parentObject = GameObject.FindWithTag("Environment");
    }

    bool flag1 = false;//For triggerevents
    bool flag2 = false;//For boss spawn
    bool flag3 = false;//For spawn interval
    void Update()
    {
        if (GameTimer.Instance.minutes % 2 == 0 && !flag3 && GameTimer.Instance.minutes != 0)
        {
            spawnInterval -= 3f;
            flag3 = true;
            GameTimer.Instance.TriggerEvent("Spawn Rate Increased");
        }
        else if (GameTimer.Instance.minutes % 2 != 0 && flag3)
        {
            flag3 = false;
        }

        if (GameTimer.Instance.minutes >= 2 && flag1 == false)
        {
            GameTimer.Instance.TriggerEvent("You will face stronger opponents!");//Event text trigger for UI
            flag1 = true;  
        }

        if(GameTimer.Instance.minutes == 10 && !flag2)
        {
            SpawnBoss();
            flag2 = true;
        }

        if (Time.time >= nextSpawnTime && GameTimer.Instance.minutes != 10)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }

        if (Time.time >= nextRangedSpawnTime && GameTimer.Instance.minutes != 10)
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

        GameObject selectedEnemyPrefab;

        // Randomly select an enemy prefab
        if (GameTimer.Instance.minutes < 2)//If it's been more than two minutes
                                            //add the prefab in the third index to the pool.
        {
            selectedEnemyPrefab = enemyPrefabs[Random.Range(0, 2)];
        }
        else
        {          
            selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        }
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

    void SpawnBoss()
    {
        if (spawners.Count == 0) return;

        int randomIndex = Random.Range(0, spawners.Count);

        Transform selectedSpawner = spawners[randomIndex];

        GameObject boss = Instantiate(bossPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);
    }
}
