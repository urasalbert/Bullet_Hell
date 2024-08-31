using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentDropUpgrade : MonoBehaviour
{
    private Slider slider;
    private Button upgradeButton;
    public Button resetButton;

    private float sliderValue = 0f;
    private int maxRandomDropValue = 100;
    private int clickCount = 0;

    private void Awake()
    {
        upgradeButton = GetComponent<Button>();
        slider = GetComponentInChildren<Slider>();

        //Load pre saved values 
        sliderValue = PlayerPrefs.GetFloat("FragmentDropUpgradeSliderValue", 0f);
        maxRandomDropValue = (int)PlayerPrefs.GetFloat("maxRandomDropValueStoredValue", 0f);
        clickCount = Mathf.FloorToInt(sliderValue / 0.33f);

        slider.value = sliderValue;

        if (clickCount >= 3)
        {
            upgradeButton.interactable = false;
        }

        //When reset button clicked call ResetValues
        resetButton.onClick.AddListener(ResetValues);
    }

    public void OnButtonClick()
    {
        if (clickCount < 3 && MainMenuGold.Instance.currentGold != 0)
        {
            clickCount++;

            MainMenuGold.Instance.currentGold -= 1;

            sliderValue += 0.33f;
            slider.value = sliderValue;

            maxRandomDropValue -= 10;

            PlayerPrefs.SetFloat("FragmentDropUpgradeSliderValue", sliderValue);
            PlayerPrefs.SetFloat("maxRandomDropValueStoredValue", maxRandomDropValue);

            if (clickCount == 3)
            {
                slider.value = 1f;
                PlayerPrefs.SetFloat("FragmentDropUpgradeSliderValue", 1f);
                PlayerPrefs.SetFloat("maxRandomDropValueStoredValue", 70f);
                upgradeButton.interactable = false;
            }
        }
    }

    private void ResetValues()
    {
        int currentclickCount = Mathf.FloorToInt(sliderValue / 0.33f);
        MainMenuGold.Instance.currentGold += currentclickCount;

        //Reset all values
        sliderValue = 0f;
        maxRandomDropValue = 100;
        clickCount = 0;

        slider.value = sliderValue;

        PlayerPrefs.SetFloat("FragmentDropUpgradeSliderValue", sliderValue);
        PlayerPrefs.SetFloat("maxRandomDropValueStoredValue", maxRandomDropValue);

        upgradeButton.interactable = true;
    }
}