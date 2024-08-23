using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    [SerializeField] internal GameObject purpleEyePetPreafab;
    [SerializeField] internal GameObject greenEyePetPrefab;

    private GameObject parentobject;

    private bool isPurpleSpawned = false;
    private bool isGreenSpawned = false;

    [SerializeField] private Transform petSpawner;
    [SerializeField] private Transform petSpawner2;

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
        if (PetOneSkill.Instance.isClicked && !isPurpleSpawned)
        {
            Instantiate(purpleEyePetPreafab, petSpawner.position, Quaternion.identity, parentobject.transform);
            isPurpleSpawned = true;
        }
        if (PetTwoSkill.Instance.isClicked && !isGreenSpawned)
        {
            Instantiate(greenEyePetPrefab, petSpawner2.position, Quaternion.identity, parentobject.transform);
            isGreenSpawned = true;
        }
    }
}
