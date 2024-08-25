using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack1 : MonoBehaviour
{
    private Transform playerTransform;
    private float radius = 4f;
    public GameObject explosionPrefab;
    public GameObject warningPrefab;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        InvokeRepeating("CreateExplosions", 0f, 8f);
    }

    void CreateExplosions()
    {
        for (int i = 0; i < 4; i++)//Create explosion 4 times
        {
            Vector3 randomPosition = GetRandomPositionAroundPlayer();
            StartCoroutine(SpawnWarningAndExplosion(randomPosition));
        }
    }

    IEnumerator SpawnWarningAndExplosion(Vector3 position)
    {
        GameObject warning = Instantiate(warningPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(warning);

        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        Animator explosionAnimator = explosion.GetComponent<Animator>();

        if (explosionAnimator != null)
        {
            float explosionDuration = explosionAnimator.GetCurrentAnimatorStateInfo(0).length;
            //Get explosion duration for destroy
            yield return new WaitForSeconds(explosionDuration);
        }
        Destroy(explosion);
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        Vector3 randomPosition = new Vector3(randomCircle.x, randomCircle.y, 0);
        return playerTransform.position + randomPosition;
    }
}
