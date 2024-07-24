using System.Collections.Generic;
using UnityEngine;

public class SkillTreeText : MonoBehaviour
{
    public static SkillTreeText Instance { get; private set; }

    public List<Skill> SkillList = new List<Skill>();
    public GameObject SkillHolder;
    public string[] SkillDescriptionText;
    public string[] SkillNameText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            //Start Skill List
            SkillList = new List<Skill>();
        }
    }

    void Start()
    {
        // Add texts with index
        SkillNameText = new string[] { "Projectile Hell", "Movement Rush", "Bigger Better", "Pierce All of Them",
        "One Up One Down"};
        SkillDescriptionText = new string[]
        {
            "Adds one projectile to the number of projectiles already owned.",
            "Provides some increase in movement speed.",
            "Makes the projectiles you have bigger.",
            "Your bullets shatter all enemies but disappear fast.",
            "You send one more projectile up and down."
        };

        // Add all Skill components in SkillHolder to SkillList
        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>())
        {
            SkillList.Add(skill);
        }

        // Set the id of each Skill
        for (var i = 0; i < SkillList.Count; i++)
        {
            SkillList[i].id = i;
        }

        // Update all Skill UIs
        UpdateAllSkillUI();
    }

    private void UpdateAllSkillUI()
    {
        foreach (var skill in SkillList)
        {
            skill.updateUI();
        }
    }

}
