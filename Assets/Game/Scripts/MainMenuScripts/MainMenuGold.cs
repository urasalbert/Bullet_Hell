using System;
using TMPro;
using UnityEngine;

public class MainMenuGold : MonoBehaviour
{
    public static MainMenuGold Instance { get; private set; } // Singleton

    private TextMeshProUGUI goldText;

    private int _currentGold;
    public int currentGold // Learned 30.08.24 "Properties" 
    {
        get => _currentGold;
        set
        {
            _currentGold = value;
            UpgradeMainMenuGoldText();
            PlayerPrefs.SetInt("PlayerGold", _currentGold); 
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            goldText = GetComponent<TextMeshProUGUI>();
            currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        }
    }

    private void Start()
    {
        UpgradeMainMenuGoldText();
    }

    public void UpgradeMainMenuGoldText()
    {
        goldText.text = "Gold: " + currentGold.ToString();
    }
}
