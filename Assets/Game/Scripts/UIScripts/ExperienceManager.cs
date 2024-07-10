using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance { get; private set; }

    public float totalExperience;
    public int currentLevel = 1;
    public float experienceToNextLevel = 500;
    public Image xpBar;
    public TextMeshProUGUI textMeshProUGUI;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        UpdateXPBar();
    }

    private void Update()
    {
        

        if(Input.GetKeyDown("b")) // For testing delete this later
        {
            AddExperience(10);
        }
    }

    public void AddExperience(float amount)
    {
        totalExperience += amount;
        UpdateXPBar();
        CheckForLevelUp();
    }

    internal void CheckForLevelUp()
    {
        if (totalExperience >= experienceToNextLevel)
        {
            totalExperience -= experienceToNextLevel;
            currentLevel++;
            experienceToNextLevel *= 1.2f; //Increase xp requirement by 20 percent at each level
            textMeshProUGUI.text = ("Level: ") + currentLevel.ToString();
            UpdateXPBar();
        }
    }

    private void UpdateXPBar()
    {
        if (xpBar != null)
        {
            xpBar.fillAmount = totalExperience / experienceToNextLevel;
        }
    }
}
