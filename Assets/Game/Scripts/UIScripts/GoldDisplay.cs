using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    public static GoldDisplay Instance {  get; private set; }

    [SerializeField] private TextMeshProUGUI goldText; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateGoldText();
    }

    public void UpdateGoldText()
    {
        int currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        goldText.text = "Gold: " + currentGold;
    }
}
