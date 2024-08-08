using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShieldSkill : MonoBehaviour
{
    public static ShieldSkill Instance { get; private set; }

    [NonSerialized] public bool isClicked = false;

    internal Image SkillImage;
    public GameObject skillTreeUI;
    bool isAlreadyTaken = false;

    //public UnityEvent<bool> trigger;

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