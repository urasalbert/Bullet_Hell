using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform playerTransform;
    public float moveSpeed;
    private float initialMoveSpeed; // Store the initial move speed for later (freeze effects)
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool isFrozen; // Track if the enemy is frozen

    [SerializeField] private GameObject freezeEffect;
    [SerializeField] private bool hasAttackAnim;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        initialMoveSpeed = moveSpeed; // Capture the initial move speed at
                                      // start for freeze and movement speed bugs
    }

    void Update()
    {
        Move();

        // Check and flip the sprite direction only if the enemy is not frozen
        if (moveSpeed > 0)
        {
            SpriteDirectionChecker();
        }
    }

    void Move()
    {
        float offset = Random.Range(-0.5f, 0.5f) > 0 ? 0.5f : -0.5f;
        Vector2 targetPosition = new Vector2(playerTransform.position.x + offset, playerTransform.position.y);

        if (hasAttackAnim)
        {
            // If has attack anim, move with offsets for animations
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    // Face the moving direction
    void SpriteDirectionChecker()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            // Player is to the left, face left
            spriteRenderer.flipX = false;
        }
        else
        {
            // Player is to the right, face right
            spriteRenderer.flipX = true;
        }
    }

    public void EnemyChill()
    {
        float randomValue = Random.Range(0f, 3f);
        float chillTimer = 3f;

        if (ChillEnemySkill.Instance.isClicked && randomValue <= 2f)
        {
            // Make enemy sprite color blue for chill effect
            spriteRenderer.color = new Color(46f / 255f, 118f / 255f, 229f / 255f);

            // Reduce movement speed but ensure it doesn't go below 0
            moveSpeed = Mathf.Max(moveSpeed - 1, 0);

            UpdateFreezeEffect();

            // Start coroutine to end chill effect after 3 seconds
            StartCoroutine(EndChillEffect(chillTimer));
        }
    }
    void UpdateFreezeEffect()
    {
        if (moveSpeed == 0)
        {
            freezeEffect.SetActive(true);
            isFrozen = true;
            // Disable the Animator to stop all animations
            if (animator != null)
            {
                animator.enabled = false;
            }
        }
        else
        {
            freezeEffect.SetActive(false);
            isFrozen = false;
            // Enable the Animator to resume animations
            if (animator != null)
            {
                animator.enabled = true;
            }
        }
    }

    IEnumerator EndChillEffect(float delay)
    {
        yield return new WaitForSeconds(delay);

        spriteRenderer.color = Color.white;

        // Restore moveSpeed, ensuring it doesn't exceed initialMoveSpeed
        moveSpeed = Mathf.Min(moveSpeed + 1, initialMoveSpeed);

        // Update freeze effect to re-enable movement and animations if needed
        UpdateFreezeEffect();
    }
}

