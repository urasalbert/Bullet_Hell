using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) // For test
        {
            HealthBarManager.Instance.IncomeDamage(10);
            Debug.Log("Damage Dealed" + HealthBarManager.Instance.currentPlayerHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            HealthBarManager.Instance.IncomeDamage(10);
        }
    }

}
