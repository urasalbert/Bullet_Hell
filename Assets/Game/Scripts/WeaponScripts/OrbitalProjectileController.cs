using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject orbitalProjectilePrefab;
    [SerializeField] private Transform orbitalProjectileLocation;
    [SerializeField] private Transform orbitalProjectileLocation2;

    private GameObject parentObject;
    private void Awake()
    {
        parentObject = GameObject.FindGameObjectWithTag("Environment");
    }
    bool flag = false;
    bool flag2 = false;
    void Update()
    {

        if (ProjectileOrbitSkill.Instance.isClicked && !flag)
        {
            GameObject orbitalProjectile1 = Instantiate(orbitalProjectilePrefab, orbitalProjectileLocation.position,
                Quaternion.identity, parentObject.transform);
            flag = true;
        }
        if (ProjectileOrbitTwoSkill.Instance.isClicked && !flag2)
        {
            GameObject orbitalProjectile1 = Instantiate(orbitalProjectilePrefab, orbitalProjectileLocation2.position,
                 Quaternion.identity, parentObject.transform);
            flag2 = true;
        }
    }
}
