using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static EnemyHealthManager Instance { get; private set; }


    [SerializeField] internal float enemyMaxHealth = 100;
    public float enemyCurrentHealth;
    [SerializeField] internal GameObject xpFragment;
    [SerializeField] public GameObject parentObject;

    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage();
    }
    public  void TakeDamage()
    {
        enemyCurrentHealth -= ProjectileWeaponController.Instance.damage;
        if (enemyCurrentHealth <= 0)
        {
            Debug.Log("Damage dealed!");
            Die();
        }
    }

    internal void Die()
    {
        Destroy(gameObject);
        Instantiate(xpFragment, transform.position, Quaternion.identity, parentObject.transform);
    }
}
