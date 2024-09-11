using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSound : MonoBehaviour
{
    public static FreezeSound Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;


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

    public void PlayFreezeSound()
    {
        if(audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.Log("Freeze audio source clip is empty!");
        }
    }
}
