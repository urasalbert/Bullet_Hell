using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle toggle;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume); //Save volume with playerpref
        PlayerPrefs.Save();
    }

    private void Start()
    {
        bool isFullScreen = PlayerPrefs.GetInt("FullScreen", 0) == 1; //Check bool value 1 = true 0 = false
        Screen.fullScreen = isFullScreen;

        toggle.isOn = isFullScreen;

        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume"); //Get saved volume when game launch

            // Set it again for slider + audiomixer
            audioMixer.SetFloat("Volume", savedVolume); 
            volumeSlider.value = savedVolume;
        }
        else
        {
            //If there is no saved volume set volume max value
            audioMixer.SetFloat("Volume", 20);
        }
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0); // condition ? value_if_true : value_if_false
    }
}
