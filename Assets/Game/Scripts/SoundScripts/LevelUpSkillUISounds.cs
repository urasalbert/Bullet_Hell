using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSkillUISounds : MonoBehaviour
{
    public static LevelUpSkillUISounds Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    public AudioClip menuClickSound;
    public AudioClip menuHoverOverSound;
    public AudioClip levelUpSound;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLevelUpSound()
    {
        audioSource.clip = levelUpSound;
        audioSource.Play();
    }
    public void PlayMenuHoverSound()
    {
        audioSource.clip = menuHoverOverSound;
        audioSource.Play();
    }
    public void PlayMenuClickSound()
    {
        audioSource.clip = menuClickSound;
        audioSource.Play();
    }

}
