using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileSkill : MonoBehaviour
{
    public static ProjectileSkill Instance { get; private set; }

    public bool isClicked = false;
    internal Image SkillImage;
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



    private void Start()
    {

    }

    public void GetTheSkill()
    {
        isClicked = true;
        SkillImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking

    }
}
