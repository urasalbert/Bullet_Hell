using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMageCastSound : MonoBehaviour
{
    public static ArcherMageCastSound Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    public AudioClip archerCastSound;
    public AudioClip mageCastSound;

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

    public void PlayArcherCastSound()
    {
        audioSource.clip = archerCastSound;
        audioSource.Play();
    }

    public void PlayMageCastSound()
    {
        audioSource.clip = mageCastSound;
        audioSource.Play();
    }
}
