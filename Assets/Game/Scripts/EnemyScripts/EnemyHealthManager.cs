using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    //Can't use singleton it's not working with clones


    [SerializeField] internal float enemyMaxHealth = 1500;
    public float enemyCurrentHealth;
    [SerializeField] internal GameObject xpFragment;
    //internal GameObject parentObject;

    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            TakeDamage();
            Destroy(collision.gameObject);// Destroy after collision
        }

    }
    public void TakeDamage()
    {
        enemyCurrentHealth -= ProjectileWeaponController.Instance.damage; // I have 2 colliders damage deal twice because of it
        Debug.Log("Damage dealed!" + ProjectileWeaponController.Instance.damage);
        if (enemyCurrentHealth <= 0)
        {      
            Die();
        }
    }

    internal void Die()
    {
        Destroy(gameObject);
        Instantiate(xpFragment, transform.position, Quaternion.identity);
    }
}
