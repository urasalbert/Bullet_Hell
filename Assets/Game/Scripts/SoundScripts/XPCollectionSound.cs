using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPCollectionSound : MonoBehaviour
{
    public static XPCollectionSound Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;


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

    public void PlayXPCollectionSound()
    {
        audioSource.Play();
    }

}
