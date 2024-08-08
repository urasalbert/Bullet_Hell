using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldController : MonoBehaviour
{
    //Timer for shield if any projectile collide with shield close it for 5 seconds
    [SerializeField] internal GameObject shieldPrefab;
    internal GameObject player;
    internal float shieldTimer = 0;
    internal float elapsedTime = 0;
    internal bool startTimer = false;


    private void Awake()
    {
        shieldPrefab.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            startTimer = true;
        }
    }

    void Update()
    {
        if(!startTimer && ShieldSkill.Instance.isClicked)
        {
            shieldPrefab?.SetActive(true);
        }
        else
        {
            shieldPrefab.SetActive(false);
        }


        if(startTimer && elapsedTime <= 5)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0;
            startTimer = false;
        }
    }
}
