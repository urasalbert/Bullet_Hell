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
    [NonSerialized] public float experienceToNextLevel = 100;
    public Image xpBar;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI skillPointUIText;
    public GameObject skillTreeUI;
    public float skillPoints = 0;
    public TextMeshProUGUI pressPText;
    [NonSerialized] public bool isSkillTreeUIopen;

    LevelUpEffect levelUpEffect;
    RandomisedSkill RandomisedSkill;
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
            isSkillTreeUIopen = false;
            skillPoints = 0;
            levelUpEffect = GetComponent<LevelUpEffect>();
            pressPText.gameObject.SetActive(false);
            RandomisedSkill = FindObjectOfType<RandomisedSkill>();
        }
    }
    private void Start()
    {
        UpdateXPBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown("b")) // For testing delete this later
        {
            AddExperience(10000);
        }

        //Manuel skill tree key
        if (Input.GetKeyDown("p") && !isSkillTreeUIopen)
        {
            pressPText.gameObject.SetActive(false);
            PlayXPMenuOpenSound();
            OpenSkillUI();
        }
        else if (Input.GetKeyDown("p") && isSkillTreeUIopen)
        {
            PlayXPMenuOpenSound();
            CloseSkillUI();
        }
    }

    public void PlayXPMenuOpenSound()
    {
        LevelUpSkillUISounds.Instance.PlayMenuClickSound(); //Menu and click sound the same
    }

    public void AddExperience(float amount)
    {
        int extraXPvalue = (int)PlayerPrefs.GetFloat("extraXPvalueStoredValue", 0f);
        totalExperience += amount + extraXPvalue;

        Debug.Log("Added xp amount: " + (amount + extraXPvalue));
        UpdateXPBar();
        CheckForLevelUp();
    }

    void LevelUpSound()
    {
        LevelUpSkillUISounds.Instance.PlayLevelUpSound();
    }
    internal void CheckForLevelUp()
    {
        if (totalExperience >= experienceToNextLevel)
        {
            LevelUp();
            UpdateSkillPoints();
            textMeshProUGUI.text = ("Level: ") + currentLevel.ToString();
            UpdateXPBar();
        }
    }
    bool flag1 = false;
    private void LevelUp()
    {
        if (!RandomisedSkill.maxLevel)
        {
            OpenSkillUI();
            RandomisedSkill.ShowRandomButtons();
            totalExperience -= experienceToNextLevel;
            currentLevel++;
            LevelUpSound();
            skillPoints++;
            experienceToNextLevel *= 1.1f; //Increase xp requirement by 20 percent at each level

            if (levelUpEffect != null)
            {
                StartCoroutine(levelUpEffect.CreateandDestroyEffect()); // Trigger the level-up effect
            }
            if (!flag1)// Information text show up
            {
                //pressPText.gameObject.SetActive(true);
                flag1 = true;
            }
        }     
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

    void OpenSkillUI()
    {
        Time.timeScale = 0;
        skillTreeUI.SetActive(true);
        //isSkillTreeUIopen = true;
    }

    void CloseSkillUI()
    {
        Time.timeScale = 1;
        skillTreeUI.SetActive(false);
        isSkillTreeUIopen = false;
    }


}
