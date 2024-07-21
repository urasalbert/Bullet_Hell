using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionSkillText;
    internal Image SkillImage;
    //internal Button SkillButton;

    private void Awake()
    {
        SkillImage = GetComponent<Image>();
        //SkillButton = GetComponent<Button>();
    }

    private void Start()
    {
        nameText.text = string.Empty;
        descriptionSkillText.text = string.Empty;
    }
    public void updateUI()
    {
        if (SkillTreeText.Instance == null)
        {
            Debug.LogError("SkillTreeText.Instance is null");
            return;
        }

        if (SkillTreeText.Instance.SkillNameText == null || SkillTreeText.Instance.SkillDescriptionText == null)
        {
            Debug.LogError("SkillTreeText lists are null");
            return;
        }

        if (id < 0 || id >= SkillTreeText.Instance.SkillNameText.Length || id >= SkillTreeText.Instance.SkillDescriptionText.Length)
        {
            Debug.LogError("Skill id is out of range");
            return;
        }

        //Update UI
        nameText.text = SkillTreeText.Instance.SkillNameText[id];
        descriptionSkillText.text = SkillTreeText.Instance.SkillDescriptionText[id];
    }

    public void RemoveText()
    {
        // Remove text when pointer exit
        nameText.text = string.Empty;
        descriptionSkillText.text = string.Empty;
    }

    public void ClickEvent() 
    {
        SkillImage.color = new Color32(0x38, 0x38, 0x38, 0xFF); // Darken color after clicking

    }
}
