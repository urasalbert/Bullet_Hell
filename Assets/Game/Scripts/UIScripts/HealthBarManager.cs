using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager Instance { get; private set; }

    internal float currentPlayerHealth;
    internal float maxPlayerHealth = 100;
    internal bool isDead;
    [SerializeField] internal Image healthFill;


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

        currentPlayerHealth = maxPlayerHealth;
        isDead = false;
    }

    void Update()
    {
        if (currentPlayerHealth == 0)
        {
            Die();
        }
    }

    void UpdateHealth()
    {
        if (healthFill != null)
        {
            healthFill.fillAmount = currentPlayerHealth / 100;
        }
    }
    public void IncomeDamage(float damage)
    {
        currentPlayerHealth -= damage;
        UpdateHealth();

    }
    void Die()
    {
        //Die Script Goes Here
    }
}
