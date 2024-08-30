using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour
{
    private Slider slider;
    private Button upgradeButton;
    public Button resetButton; 

    private float sliderValue = 0f;
    private float healthValue = 0f;
    private int clickCount = 0;

    private void Awake()
    {
        upgradeButton = GetComponent<Button>();
        slider = GetComponentInChildren<Slider>();

        //Load pre saved values 
        sliderValue = PlayerPrefs.GetFloat("HealthUpgradeSliderValue", 0f);
        healthValue = PlayerPrefs.GetFloat("HealthUpgradeStoredValue", 0f);
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
        if (clickCount < 3)
        {
            clickCount++;

            sliderValue += 0.33f;
            slider.value = sliderValue;

            healthValue += 10f;

            PlayerPrefs.SetFloat("HealthUpgradeSliderValue", sliderValue);
            PlayerPrefs.SetFloat("HealthUpgradeStoredValue", healthValue);

            if (clickCount == 3)
            {
                slider.value = 1f;
                PlayerPrefs.SetFloat("HealthUpgradeSliderValue", 1f);
                PlayerPrefs.SetFloat("HealthUpgradeStoredValue", 30f);
                upgradeButton.interactable = false;
            }
        }
    }

    private void ResetValues()
    {
        //Reset all values
        sliderValue = 0f;
        healthValue = 0f;
        clickCount = 0;

        slider.value = sliderValue;

        PlayerPrefs.SetFloat("HealthUpgradeSliderValue", sliderValue);
        PlayerPrefs.SetFloat("HealthUpgradeStoredValue", healthValue);

        upgradeButton.interactable = true;
    }
}
