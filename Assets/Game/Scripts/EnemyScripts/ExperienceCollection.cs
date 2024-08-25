using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceCollection : MonoBehaviour
{

    private Transform player;
    private float attractionDistance = 2f; //Collection distance 
    private float moveSpeed = 7f;
    [SerializeField] private float experienceAmount;

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
                ExperienceManager.Instance.AddExperience(experienceAmount);
                PlayCollectionSound();
                Destroy(gameObject);
            }
        }
    }

    internal void PlayCollectionSound()
    {
        //Sound effect goes here
    }

}
