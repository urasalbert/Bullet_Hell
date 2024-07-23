using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PierceSkill : MonoBehaviour
{
    public static PierceSkill Instance { get; private set; }
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
        isClicked = true;
        SkillImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking       
        if (isAlreadyTaken == false)
        {
            Time.timeScale = 1;
            skillTreeUI.SetActive(false);
            isAlreadyTaken = true;
        }
        else
        {
            return;
        }
    }
}
