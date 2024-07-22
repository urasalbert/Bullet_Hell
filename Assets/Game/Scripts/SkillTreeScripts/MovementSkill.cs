using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSkill : MonoBehaviour
{
    public static MovementSkill Instance { get; private set; }

    [NonSerialized] public bool isClicked = false;
    [SerializeField] private GameObject skillTreeUI;
    private bool isAlreadyTaken = false;
    private Image spriteImage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            spriteImage = GetComponent<Image>();
        }
    }

    public void GetTheSkill()
    {
        isClicked = true;
        spriteImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking       
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
