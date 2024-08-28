using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    private Transform player;
    private float attractionDistance = 1f; // Collection distance 
    private float moveSpeed = 7f;
    [SerializeField] private int goldAmount = 1;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position); // Calculate distance for collection

        if (distance <= attractionDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (distance < 0.1f)
            {
                AddGold(goldAmount);
                PlayCollectionSound();
                Destroy(gameObject);
            }
        }
    }

    private void AddGold(int amount)
    {

        int currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        currentGold += amount;
        PlayerPrefs.SetInt("PlayerGold", currentGold);
        PlayerPrefs.Save();

        GoldDisplay.Instance.UpdateGoldText();
    }

    internal void PlayCollectionSound()
    {
        // Sound effect goes here
    }
}
