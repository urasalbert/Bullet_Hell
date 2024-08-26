using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    //Bat movement
    public float moveSpeed = 5f;
    private Transform player;
    public float lifetime = 15f;

    private Vector3 direction;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Start()
    {
        direction = (player.position - transform.position).normalized;

        Invoke("DestroyEnemy", lifetime);
    }

    private void Update()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void DestroyEnemy()
    {

        Destroy(gameObject);
    }
}
