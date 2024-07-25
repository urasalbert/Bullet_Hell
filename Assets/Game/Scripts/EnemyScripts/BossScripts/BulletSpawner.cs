using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;
    private GameObject parentObject;

    [SerializeField] private float firingRate = 1f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    private void Awake()
    {
        parentObject = GameObject.FindWithTag("Environment");
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }


    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity, parentObject.transform);
            spawnedBullet.GetComponent<BossBullet>().speed = speed;
            spawnedBullet.GetComponent<BossBullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}


