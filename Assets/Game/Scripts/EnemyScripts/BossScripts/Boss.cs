using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Slider hpFill;
    private float maxHealth = 1000;
    private float currentHealth;
    private float speed = 10f; // Boss movement speed
    private Transform playerPos;
    private float radius = 6f; // Radius around the player where the boss will move
    private Vector2 targetPosition;

    EnemyDieExplosion enemyDieExplosion;
    GameTimer gameTimer;

    private void Awake()
    {
        enemyDieExplosion = GetComponent<EnemyDieExplosion>();
        playerPos = FindObjectOfType<PlayerMovement>().transform;
        hpFill = GetComponentInChildren<Slider>();
        gameTimer = FindObjectOfType<GameTimer>();

        currentHealth = maxHealth;

        if (hpFill == null)
        {
            Debug.Log("Health fill is null");
        }

        hpFill.value = currentHealth;
    }

    private void Start()
    {
        StartCoroutine(MoveRandomly());
    }

    private IEnumerator MoveRandomly()
    {
        while (true)
        {
            // Choose a random target position
            ChooseRandomPosition();
            // Move towards the target position
            while ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    private void ChooseRandomPosition()
    {
        // Choose a random angle
        float angle = Random.Range(0f, 360f);
        // Convert angle to radians
        float radian = angle * Mathf.Deg2Rad;
        // Calculate the new target position
        targetPosition = new Vector2(
            playerPos.position.x + Mathf.Cos(radian) * radius,
            playerPos.position.y + Mathf.Sin(radian) * radius
        );
    }

    private void Update()
    {
        hpFill.value = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ammo"))
        {
            currentHealth -= 25;
            EnemyDamageSound.Instance.PlayEnemyDamageSound();
        }
    }
    bool flag1 = false;
    void Die()
    {
        if (!flag1)
        {
            enemyDieExplosion.GoreExplosion();
            flag1 = true;
        }
        gameTimer.GameFinish();
        Destroy(gameObject);
    }
}
