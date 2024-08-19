using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager Instance { get; private set; }

    internal float currentPlayerHealth = 100;
    internal float maxPlayerHealth = 100;
    internal bool isDead;
    [SerializeField] internal Image healthFill;

    private bool isMaxHealthIncreased = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            isDead = false;
            currentPlayerHealth = maxPlayerHealth;
        }
    }

    void Update()
    {
        if (currentPlayerHealth == 0)
        {
            Die();
        }

        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (HealthOneSkill.Instance.isClicked && !isMaxHealthIncreased)
        {
            maxPlayerHealth = 200;
            isMaxHealthIncreased = true;
            currentPlayerHealth = maxPlayerHealth;
        }

        if (healthFill != null)
        {
            healthFill.fillAmount = currentPlayerHealth / maxPlayerHealth;
        }
    }

    public void IncomeDamage(float damage)
    {
        currentPlayerHealth -= damage;
        UpdateHealth();
        Debug.Log("Current player health: " + currentPlayerHealth);
    }

    void Die()
    {
        //Die script goes here
    }
}
