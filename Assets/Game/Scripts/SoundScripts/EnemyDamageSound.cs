using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSound : MonoBehaviour
{
    public static EnemyDamageSound Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    public AudioClip[] damageSounds;


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

    public void PlayEnemyDamageSound()
    {
        if (damageSounds.Length > 0) // Null check
        {
            int randomIndex = Random.Range(0, damageSounds.Length);
            audioSource.clip = damageSounds[randomIndex];
            audioSource.Play();
        }
    }

}

