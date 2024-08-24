using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject orbitalProjectilePrefab;
    [SerializeField] private Transform orbitalProjectileLocation;

    private GameObject parentObject;
    private void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag("Environment");
    }
    bool flag = false;
    void Update()
    {
        
        if (ProjectileOrbitSkill.Instance.isClicked && !flag)
        {
            GameObject orbitalProjectile1 = Instantiate(orbitalProjectilePrefab, orbitalProjectileLocation.position, 
                Quaternion.identity, parentObject.transform);
            flag = true;
        }
    }
}
