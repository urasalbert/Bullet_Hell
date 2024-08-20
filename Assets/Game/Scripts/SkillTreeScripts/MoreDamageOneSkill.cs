using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoreDamageOneSkill : MonoBehaviour
{
    public static MoreDamageOneSkill Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI skillCostText;
    float pointCost = 2;

    [NonSerialized] public bool isClicked = false;
    internal Image SkillImage;
    public GameObject skillTreeUI;
    bool isAlreadyTaken = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            SkillImage = GetComponent<Image>();
        }
    }

   public void GetTheSkill()
    {
        //Check if the player has enough skill points
        if (ExperienceManager.Instance.skillPoints >= pointCost)
        {
            isClicked = true;
            SkillImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking       
            if (isAlreadyTaken == false)
            {
                Time.timeScale = 1;
                skillTreeUI.SetActive(false);
                isAlreadyTaken = true;
                ExperienceManager.Instance.skillPoints -= pointCost; //Subtract the score of the
                                                                     //received ability from the total score
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


