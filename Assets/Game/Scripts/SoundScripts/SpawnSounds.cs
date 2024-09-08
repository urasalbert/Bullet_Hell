using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSounds : MonoBehaviour
{
    public static SpawnSounds Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    public AudioClip bossSpawnSound;


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

    public void PlayBossSpawnSound()
    {
        audioSource.clip = bossSpawnSound;
        audioSource.Play();
    }
}

