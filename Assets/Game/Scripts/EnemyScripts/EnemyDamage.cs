using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //I did the damage hitting with layers because in
    //overlapcircle enemy and player do not collide

    internal float detectionRadius = 0.15f;
    public LayerMask playerLayer;
    private float damageInterval = 1.5f; // Damage interval
    private float lastDamageTime;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        lastDamageTime = -damageInterval; // First damage is instant
    }

    private void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        if (playerCollider != null && Time.time >= lastDamageTime + damageInterval)
        {
            DamagePlayer(playerCollider.gameObject);
            lastDamageTime = Time.time; // Update last damage timer
            
        }
    }

    private void DamagePlayer(GameObject player)
    {
        // Dealing damage
        HealthBarManager.Instance.IncomeDamage(10);
        //Playing damage animation
        animator.SetTrigger("isShoot");

        DamageSound();

        //Debug.Log("Damage Dealed: " + HealthBarManager.Instance.currentPlayerHealth);
    }

    void DamageSound()
    {
        EnemyDamageSound.Instance.PlayEnemyDamageSound();
    }
}
