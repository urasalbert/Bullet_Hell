using System;
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
    public TextMeshProUGUI skillPointUIText;
    public GameObject skillTreeUI;
    public float skillPoints = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            skillTreeUI.SetActive(false);
            skillPoints = 0;
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
            LevelUp();
            UpdateSkillPoints();
            textMeshProUGUI.text = ("Level: ") + currentLevel.ToString();
            skillPointUIText.text = ("Skill Points: ") + skillPoints.ToString();
            UpdateXPBar();
        }
    }

    private void LevelUp()
    {
        totalExperience -= experienceToNextLevel;
        currentLevel++;
        skillPoints++;
        experienceToNextLevel *= 1.6f; //Increase xp requirement by 20 percent at each level
        Time.timeScale = 0;
        skillTreeUI.SetActive(true);

    }
    public void UpdateSkillPoints()
    {
        skillPointUIText.text = ("SkillPoint: ") + skillPoints.ToString();
    }
    private void UpdateXPBar()
    {
        if (xpBar != null)
        {
            xpBar.fillAmount = totalExperience / experienceToNextLevel;
        }
    }
}
