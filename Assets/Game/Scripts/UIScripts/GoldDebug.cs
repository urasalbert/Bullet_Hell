using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDebug : MonoBehaviour
{ 
    //Just for debug delete it later
    Transform playerTransform;
    public GameObject goldPrefab;


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
       /* if (Input.GetKeyDown("l"))
        {
            AddGoldAmount();
        }
        else if (Input.GetKeyDown("k"))
        {
            ResetGoldAmount();
        }
       */
    }


    void AddGoldAmount()
    {
        Instantiate(goldPrefab, playerTransform.position , Quaternion.identity);
    }

    void ResetGoldAmount()
    {
        int currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        PlayerPrefs.SetInt("PlayerGold", 0);
        PlayerPrefs.Save();
    }
}
