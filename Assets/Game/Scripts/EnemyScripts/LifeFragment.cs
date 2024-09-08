using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class LifeFragment : MonoBehaviour
{

    private Transform player;
    private float attractionDistance = 1f; //Collection distance 
    private float moveSpeed = 7f;
    [SerializeField] private float healthAmount;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    bool flag1 = true;
    void Update()
    {
        if (PickUpRadiusSkill.Instance.isClicked && flag1)//If player took the pickupradius
                                                          //skill get more distance for collection                         
        {
            attractionDistance += 2f;
            flag1 = false;
        }


        float distance = Vector3.Distance(transform.position, player.position); //Calculate distance for collection

        if (distance <= attractionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (distance < 0.1f)
            {
                HealthBarManager.Instance.currentPlayerHealth += healthAmount;
                PlayCollectionSound();
                Destroy(gameObject);
            }
        }
    }

    internal void PlayCollectionSound()
    {
        OtherFragmentSounds.Instance.PlayHealSound();
    }

}

