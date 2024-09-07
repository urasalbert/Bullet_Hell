using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieSound : MonoBehaviour
{
    public static EnemyDieSound Instance { get; private set; }

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

    public void PlayEnemyDieSound()
    {
        if (damageSounds.Length > 0) // Null check
        {
            int randomIndex = Random.Range(0, damageSounds.Length);
            audioSource.clip = damageSounds[randomIndex];
            audioSource.Play();
        }
    }
}
