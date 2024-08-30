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
    internal float elapsedTime = 0;

    private float menuHealthUpgradeValue;

    internal bool isDead;
    internal bool isrejectDeathUsed = false;
    internal bool isImmunityShieldActive = false;
    internal bool timerStarted = false;

    [SerializeField] internal Image healthFill;
    [SerializeField] internal GameObject immunityShield;

    private bool isMaxHealthIncreased = false;

    private void Awake()
    {
        menuHealthUpgradeValue = PlayerPrefs.GetFloat("HealthUpgradeStoredValue");

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            isDead = false;
            immunityShield.SetActive(false);
            currentPlayerHealth = maxPlayerHealth + menuHealthUpgradeValue;

            Debug.Log("health upgrade value: " + menuHealthUpgradeValue);
            Debug.Log("Current health: " + currentPlayerHealth);
        }
    }

    void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            RejectDeath();
        }

        UpdateHealth();

        if (elapsedTime <= 5 && timerStarted)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            removeImmunityShield();
        }
    }

    void UpdateHealth()
    {
        if (HealthOneSkill.Instance.isClicked && !isMaxHealthIncreased)
        {
            maxPlayerHealth = 200 + menuHealthUpgradeValue;
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
        //If immunity shield is active the player cannot be damaged
        if (!isImmunityShieldActive)
        {
            currentPlayerHealth -= damage;
            UpdateHealth();
        }
        //Debug.Log("Current player health: " + currentPlayerHealth);
    }

    void Die()
    {
       //Debug.Log("Player died");
        //Die script goes here
    }
    void RejectDeath()
    {
        if (RejectDeathSkill.Instance.isClicked && !isrejectDeathUsed)
        {
            //Equalize to fifty percent of the maximum health
            currentPlayerHealth = maxPlayerHealth * 0.5f;
            isrejectDeathUsed = true;
            timerStarted = true;
            getImmunityShield();
        }
        else
        {
            Die();
        }
    }
    void getImmunityShield()
    {
        immunityShield.SetActive(true);
        isImmunityShieldActive = true;

    }
    void removeImmunityShield()
    {
        immunityShield.SetActive(false);
        isImmunityShieldActive=false;
    }
}
