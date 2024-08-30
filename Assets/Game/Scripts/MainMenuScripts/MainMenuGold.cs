using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuGold : MonoBehaviour
{
    public static MainMenuGold Instance { get; private set; }//Singleton


    private TextMeshProUGUI goldText;
    public int currentGold;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            goldText = GetComponent<TextMeshProUGUI>();
            currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        }
    }
    void Start()
    {
        goldText.text = currentGold.ToString();
    }
}
