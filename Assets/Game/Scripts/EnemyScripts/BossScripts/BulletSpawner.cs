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
    [SerializeField] private float rotationSpeed = 50f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    private void Awake()
    {
        parentObject = GameObject.FindWithTag("Environment");
    }
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
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

            BossSounds.Instance.PlayBossProjectileSound();

            spawnedBullet.GetComponent<BossBullet>().speed = speed;
            spawnedBullet.GetComponent<BossBullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}


