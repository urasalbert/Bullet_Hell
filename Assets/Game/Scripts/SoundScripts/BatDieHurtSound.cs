using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDieHurtSound : MonoBehaviour
{
    public static BatDieHurtSound Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip dieSound;

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

    public void PlayBatDamageSound()
    {
        //I don't actively use hurt sound but I can use it for later 
        audioSource.clip = damageSound;
        audioSource.Play();
    }

    public void PlayBatDieSound()
    {
        audioSource.clip = dieSound;
        audioSource.Play();
    }

}
