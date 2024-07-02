using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    private Vector3 targetPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f); // Destroy bullet after 5 sec
    }

    void FixedUpdate()
    {
        Vector2 direction = (targetPosition - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject); // Mermiyi yok et
        }
    } */
}
