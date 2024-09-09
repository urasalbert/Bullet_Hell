using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSounds : MonoBehaviour
{
    public static PetSounds Instance {  get; private set; } 

    [SerializeField] private AudioSource audioSource;

    public AudioClip projectileExplosion;
    public AudioClip greenPetAttack;
    public AudioClip redPetAttack;
    public AudioClip petSpawn;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayGreenPetProjectileEXP()
    {
        audioSource.clip = projectileExplosion;
        audioSource.Play();
    }
    public void PlayGreenPetAttack()
    {
        audioSource.clip = greenPetAttack;
        audioSource.Play();
    }
    public void PlayRedPetAttack()
    {
        audioSource.clip = redPetAttack;
        audioSource.Play();
    }

    public void PlayPetSpawn()
    {
        audioSource.clip = petSpawn;
        audioSource.Play();
    }
}
