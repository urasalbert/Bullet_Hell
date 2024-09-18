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
    [SerializeField] internal GameObject batsPrefab;
    [SerializeField] internal GameObject freakSkeletonPrefab;

    internal float spawnInterval = 6f;
    internal float rangedSpawnInterval = 10f;

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
    bool flag4 = false;//For spawn interval
    void Update()
    {
        if (Mathf.FloorToInt(GameTimer.Instance.minutes) != 
            Mathf.FloorToInt(GameTimer.Instance.minutes - Time.deltaTime) && !flag4 && Mathf.FloorToInt(GameTimer.Instance.minutes) != 0)
        {
            spawnInterval -= 0.5f;
            rangedSpawnInterval -= 0.5f;
            flag4 = true;
            GameTimer.Instance.TriggerEvent("Spawn Rate Increased!");
        }
        else if (Mathf.FloorToInt(GameTimer.Instance.minutes) ==
            Mathf.FloorToInt(GameTimer.Instance.minutes - Time.deltaTime) && flag4)
        {
            flag4 = false;
        }

        if (GameTimer.Instance.minutes >= 2 && flag1 == false)
        {
            GameTimer.Instance.TriggerEvent("You will face stronger opponents!");//Event text trigger for UI
            flag1 = true;  
        }

        if(Mathf.FloorToInt(GameTimer.Instance.minutes) == 10 && !flag2)
        {
            SpawnSounds.Instance.PlayBossSpawnSound();
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

            int randomIndex2 = Random.Range(0, archerSpawners.Count);
            Transform selectedArcherSpawner = archerSpawners[randomIndex2];

            GameObject rangedEnemy = Instantiate(rangedEnemyPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);

            GameObject archerRangerEnemy = Instantiate(archerEnemyPrefab, selectedArcherSpawner.position, selectedSpawner.rotation, parentObject.transform);
        }
    }

    void SpawnEnemy()
    {
        if (spawners.Count == 0) return;

        int randomIndex = Random.Range(0, spawners.Count);

        Transform selectedSpawner = spawners[randomIndex];

        GameObject selectedEnemyPrefab;

        // Randomly select an enemy prefab
        int maxPrefabCount = 2;
        if (Mathf.FloorToInt(GameTimer.Instance.minutes) % 2 == 0 && Mathf.FloorToInt(GameTimer.Instance.minutes) != 0)
            //If it's been more than two minutes                                                                                                                   
            //add the prefab in the third index to the pool.
        {
            maxPrefabCount++;            
        }          
         selectedEnemyPrefab = enemyPrefabs[Random.Range(0, maxPrefabCount)];
        
        GameObject enemy = Instantiate(selectedEnemyPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);


        // Check Health Manager script for debugging
        EnemyHealthManager enemyLife = enemy.GetComponent<EnemyHealthManager>();
        if (enemyLife != null)
        {
            //Debug.Log("Enemy spawned with Life script.");
        }
        else
        {
            //Debug.LogError("Spawned enemy is missing the Life script.");
        }
    }

    void SpawnBoss()
    {
        if (spawners.Count == 0) return;



        int randomIndex = Random.Range(0, spawners.Count);

        Transform selectedSpawner = spawners[randomIndex];

        GameObject boss = Instantiate(bossPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);
        BossSounds.Instance.PlayBossSpawnSound();
    }
}
