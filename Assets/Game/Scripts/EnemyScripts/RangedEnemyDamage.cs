using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyDamage : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamagePlayer();
            Destroy(this.gameObject);
        }
    }

    private void DamagePlayer()
    {
        // Dealing damage
        HealthBarManager.Instance.IncomeDamage(25);
        Debug.Log("Damage Dealed: " + HealthBarManager.Instance.currentPlayerHealth);
    }
}
