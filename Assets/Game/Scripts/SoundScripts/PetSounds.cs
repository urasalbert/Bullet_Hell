using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public AudioClip projectileExplosion;
    public AudioClip greenPetAttack;
    public AudioClip redPetAttack;
    public AudioClip petSpawn;

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
