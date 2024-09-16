using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    //Simple button for closing skill tree
    [SerializeField] private GameObject skillTreeUI;

    public void CloseSkillTree()
    {
            skillTreeUI.SetActive(false);
            ExperienceManager.Instance.isSkillTreeUIopen = false;
            Time.timeScale = 1.0f;
    }
}
