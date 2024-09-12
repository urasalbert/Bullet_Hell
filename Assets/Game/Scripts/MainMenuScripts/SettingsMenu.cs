using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        Debug.Log(volume);
    }

    private void Start()
    {
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
}
