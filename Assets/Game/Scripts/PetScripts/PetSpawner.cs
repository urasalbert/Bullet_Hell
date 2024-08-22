using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField ]internal GameObject purpleEyePetPreafab;
    private GameObject parentobject;

    private bool isSpawned = false;

    [SerializeField] private Transform petSpawner;

    private void Awake()
    {
        parentobject = GameObject.FindGameObjectWithTag("Environment");
    }

    void Update()
    {
        SpawnPet();
    }

    void SpawnPet()
    {
        if (PetOneSkill.Instance.isClicked && !isSpawned)
        {
            Instantiate(purpleEyePetPreafab, petSpawner.position, Quaternion.identity, parentobject.transform);
            isSpawned = true;
        }
    }
}
