using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    //Can't use singleton it's not working with clones

    EnemyDieExplosion enemyDieExplosion;

    [SerializeField] internal float enemyMaxHealth;
    [SerializeField] internal GameObject xpFragment;
    [SerializeField] internal GameObject lifeFragment;
    public float enemyCurrentHealth;
    
    [NonSerialized] public bool isDead;
    [NonSerialized] public GameObject parentObject;

    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
        isDead = false;
        enemyDieExplosion = GetComponent<EnemyDieExplosion>();

        parentObject = GameObject.FindWithTag("Environment");
        if (parentObject == null)
        {
            Debug.LogError("Parent object null in EnemyHealthManager.");
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            TakeDamage();
            // Do not destroy it here for pierce skill, if you do pierce breaks
        }
        if (collision.CompareTag("PetAmmo"))
        {
            //Maybe I'll add pet damage scale later
            //I already have destroy function in lasermovement script
            TakeDamage();           
        }

    }
    internal float damage1 = 50, damage2 = 70, damage3 = 100;
    public void TakeDamage()
    {
        //If player took the first damage skill in skill tree add 20 more points to the damage
        if (MoreDamageOneSkill.Instance.isClicked)
        {
            enemyCurrentHealth -= damage1;
            //Debug.Log("More damage one is working");
        }
        if (MoreDamageTwoSkill.Instance.isClicked)
        {
            enemyCurrentHealth -= damage2;
            //Debug.Log("More damage two is working");
        }
        if(MoreDamageThreeSkill.Instance.isClicked)
        {
            enemyCurrentHealth -= damage3;
            //Debug.Log("More damage three is working");
        }
        else
        {
            enemyCurrentHealth -= 30;
            //Debug.Log("More damage skills is not working");
            // I have 2 colliders damage deal twice because of it                                                                             
            //If I have one collider damage deal once                                                                           
            //Debug.Log("Damage dealed!" + ProjectileWeaponController.Instance.damage);
        }

        if (enemyCurrentHealth <= 0)
        {
            Die();
            isDead = true;
        }
    }

    internal void Die()
    {
        enemyDieExplosion.GoreExplosion();
        Destroy(gameObject);
        DropXpFragment();
        DropLifeFragment();
    }

    void DropLifeFragment()
    {
        float randomValue = UnityEngine.Random.Range(0f, 100f);

        if(randomValue <= 1f)//1 percent chance to drop life fragment
        {
            Instantiate(lifeFragment, transform.position, Quaternion.identity, parentObject.transform);
        }
    }

    void DropXpFragment()
    {
        Instantiate(xpFragment, transform.position, Quaternion.identity, parentObject.transform);
        //Create experience fragment after enemy dead
    }
}
