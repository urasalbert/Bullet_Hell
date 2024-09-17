using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; } // Singleton instance

    private float elapsedTime = 0f; 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI eventText;
    [NonSerialized] public float minutes;

    [SerializeField] private TextMeshProUGUI killedEnemyText;
    [SerializeField] private GameObject gameWinUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            gameWinUI.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            GameFinish();
        }
    }
    private void Start()
    {
        StartCoroutine(StartTimer());
        //TriggerEvent("Event text goes here"); 
        // Test code for timer events
    }

    IEnumerator StartTimer()
    {
        // Infinite loop to keep the timer running continuously
        while (true)
        {       
            elapsedTime += Time.deltaTime;
            UpdateTimerText(elapsedTime);  
            CheckEvents(elapsedTime);
            // Wait until the next frame before continuing the loop
            yield return null;
        }
    }

    void UpdateTimerText(float seconds)
    {
        float minutes = seconds / 60f; 
        int wholeMinutes = Mathf.FloorToInt(minutes); 
        int remainingSeconds = Mathf.FloorToInt(seconds % 60f); 
        // Update the timer text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", wholeMinutes, remainingSeconds);
    }

    void CheckEvents(float seconds)
    {
        minutes = seconds / 60f; // Calculate minutes as a decimal value
    }

    public void TriggerEvent(string eventMessage)
    {
        // Trigger event message
        Debug.Log(eventMessage);
        eventText.text = eventMessage;
        Invoke("ClearEventText", 10f);
    }

    void ClearEventText()
    {
        eventText.text = null;
    }

    void GameFinish()
    {
        // Code for game finish after 10 minutes would go here

        Time.timeScale = 0f;
        killedEnemyText.text = EnemyHealthManager.killedEnemy.ToString();
        gameWinUI.SetActive(true);
    }
}
