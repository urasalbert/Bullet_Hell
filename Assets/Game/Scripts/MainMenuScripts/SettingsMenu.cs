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
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        Debug.Log(volume);
    }

    private void Start()
    {
        bool isFullScreen = PlayerPrefs.GetInt("FullScreen", 0) == 1;
        Screen.fullScreen = isFullScreen;

        toggle.isOn = isFullScreen;

        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioMixer.SetFloat("Volume", savedVolume);
            volumeSlider.value = savedVolume;
            Debug.Log("Saved volume loaded: " + savedVolume);
        }
        else
        {
            audioMixer.SetFloat("Volume", 1);
            Debug.Log("Default volume set");
        }
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1 : 0); 
    }
}
