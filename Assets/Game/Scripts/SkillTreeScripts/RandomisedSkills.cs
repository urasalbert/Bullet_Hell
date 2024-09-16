using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomisedSkill : MonoBehaviour
{
    public List<Button> buttonList = new List<Button>();

    private List<Button> activeButtons = new List<Button>();

    private Vector2 offScreenPosition = new Vector2(-1000, -1000);

    public TextMeshProUGUI maxLevelText;
    public TextMeshProUGUI skillNameText;
    public GameObject skillTreeUI;

    public bool maxLevel = false; 
    void Start()
    {
        MoveButtonsOffScreen();
    }

    public void ShowRandomButtons()
    {
        if (buttonList.Count < 2)
        {
            maxLevel = true;
            skillNameText.text = string.Empty;
            maxLevelText.text = "You have reached the maximum level!";
            return;
        }

        MoveButtonsOffScreen();

        activeButtons.Clear();
        while (activeButtons.Count < 2)
        {
            int randomIndex = Random.Range(0, buttonList.Count);
            Button randomButton = buttonList[randomIndex];

            if (!activeButtons.Contains(randomButton))
            {
                activeButtons.Add(randomButton);
                randomButton.gameObject.SetActive(true);
                randomButton.onClick.AddListener(() => OnButtonClicked(randomButton));
            }
        }

        PositionButtonsAtFixedCoordinates();
    }

    public void OnButtonClicked(Button clickedButton)
    {
        buttonList.Remove(clickedButton);

        foreach (Button btn in activeButtons)
        {
            btn.gameObject.SetActive(false);
        }

        activeButtons.Clear();
        MoveButtonsOffScreen();
        CloseSkillUI();
    }
    void CloseSkillUI()
    {
        Time.timeScale = 1;
        skillTreeUI.SetActive(false);
    }
    private void MoveButtonsOffScreen()
    {
        foreach (Button btn in buttonList)
        {
            RectTransform rectTransform = btn.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = offScreenPosition;
        }
    }

    private void PositionButtonsAtFixedCoordinates()
    {
        if (activeButtons.Count >= 2)
        {
            RectTransform rectTransform1 = activeButtons[0].GetComponent<RectTransform>();
            rectTransform1.anchoredPosition = new Vector2(-220, 80);

            RectTransform rectTransform2 = activeButtons[1].GetComponent<RectTransform>();
            rectTransform2.anchoredPosition = new Vector2(220, 80);
        }
    }
}
