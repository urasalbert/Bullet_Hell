using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void Update()
    {
        
    }

    //Spawn props randomized 
    void SpawnProps()
    {
        foreach(GameObject spawnpoint in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[rand], spawnpoint.transform.position, Quaternion.identity);
            prop.transform.parent = spawnpoint.transform; //Make spawned objects child for organization
        }
    }
}
