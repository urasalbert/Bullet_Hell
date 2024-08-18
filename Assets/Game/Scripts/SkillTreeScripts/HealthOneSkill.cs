using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthOneSkill : MonoBehaviour
{
    public static HealthOneSkill Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI skillCostText;
    private float pointCost = 1;
    [NonSerialized] public bool isClicked = false;
    private Image SkillImage;
    private bool isAlreadyTaken;
    [SerializeField] private GameObject skillTreeUI;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            SkillImage = GetComponent<Image>();
        }
    }


    public void GetTheSkill()
    {
        if (ExperienceManager.Instance.skillPoints >= pointCost)
        {
            isClicked = true;
            SkillImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking       
            if (isAlreadyTaken == false)
            {
                Time.timeScale = 1;
                skillTreeUI.SetActive(false);
                isAlreadyTaken = true;
                ExperienceManager.Instance.skillPoints -= pointCost;
                ExperienceManager.Instance.UpdateSkillPoints();
            }
            else
            {
                skillCostText.text = ("You don't have enough points to get the ability");
            }
        }
        else
        {
            return;
        }
    }
    public void SkillCost()
    {
        if (isClicked)
        {
            skillCostText.text = ("You have already took the ability ");
        }
        else if (ExperienceManager.Instance.skillPoints >= pointCost)
        {
            skillCostText.text = ("Ability can be taken for ") + pointCost.ToString() + (" points");
        }
        else
        {
            skillCostText.text = ("You don't have enough points to get the ability ") + pointCost.ToString() + (" points");
        }
    }
    public void ClearSkillCost()
    {
        skillCostText.text = (" ");
    }
}

