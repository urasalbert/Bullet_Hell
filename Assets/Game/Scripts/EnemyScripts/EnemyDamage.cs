using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //I did the damage hitting with layers because in
    //overlapcircle enemy and player do not collide

    public float detectionRadius = 1.0f;
    public LayerMask playerLayer;
    public float damageInterval = 1.0f; // Damage interval
    private float lastDamageTime;

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
        Debug.Log("Damage Dealed: " + HealthBarManager.Instance.currentPlayerHealth);
    }

}
