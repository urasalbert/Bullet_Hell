using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExperienceManager.Instance.AddExperience(10);
            Destroy(gameObject);
        }
    }

    internal void PlayCollectionSound()
    {
        //Sound effect goes here
    }

}
