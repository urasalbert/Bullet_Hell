using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFragmentSounds : MonoBehaviour
{
    public static OtherFragmentSounds Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    public AudioClip goldCollectionSound;
    public AudioClip magnetCollectionSound;
    public AudioClip healCollectionSound;

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

    public void PlayGoldSound()
    {
        audioSource.clip = goldCollectionSound;
        audioSource.Play();
    }

    public void PlayMagnetSound()
    {
        audioSource.clip = magnetCollectionSound;
        audioSource.Play();
    }

    public void PlayHealSound()
    {
        audioSource.clip = healCollectionSound;
        audioSource.Play();
    }
}

