using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    public static BossSounds Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource bossSpawnAudioSource;
    [SerializeField] private AudioSource projectileAudioSource;


    [SerializeField] private AudioClip bossSpawn;
    [SerializeField] private AudioClip bossExplosion;
    [SerializeField] private AudioClip bossProjectile;
    [SerializeField] private AudioClip explosionWarning;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayBossSpawnSound()
    {
        Debug.Log("Boss sounds working!");
        bossSpawnAudioSource.clip = bossSpawn;
        bossSpawnAudioSource.Play();
    }

    public void PlayBossExplosionSound()
    {
        audioSource.clip = bossExplosion;
        audioSource.Play();
    }

    public void PlayBossProjectileSound()
    {
        projectileAudioSource.clip = bossProjectile;
        projectileAudioSource.Play(); 
    }

    public void PlayWarningSound()
    {
        audioSource.clip = explosionWarning;
        audioSource.Play();
    }

}
