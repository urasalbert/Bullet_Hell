using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }// Singleton instance

    private float elapsedTime = 0;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI eventText;
    [NonSerialized] public float minutes;

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
    private void Start()
    {
        StartCoroutine(StartTimer());
        TriggerEvent("Event text goes here"); //Test code for timer events (if i don't remember xd)
    }


    IEnumerator StartTimer()
    {
        // Infinite loop to keep the timer running
        while (true)
        {
            // Increase elapsed time by the time passed since the last frame
            elapsedTime += Time.deltaTime;
            // Update the displayed timer text
            UpdateTimerText(elapsedTime);
            // Check for any events that should trigger based on the elapsed time
            CheckEvents(elapsedTime);
            // Wait until the next frame before continuing the loop
            yield return null;
        }
    }

    void UpdateTimerText(float seconds)
    {
        // Calculate minutes and remaining seconds from the total elapsed time
        int minutes = Mathf.FloorToInt(seconds / 60f);
        int remainingSeconds = Mathf.FloorToInt(seconds % 60f);
        // Update the timer text with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
    void CheckEvents(float seconds)
    {
        minutes = Mathf.FloorToInt(seconds / 60f); // Checking how many minutes it's been
        //Debug.Log("Minutes: " + minutes); // Debugging the minutes value
    }
    public void TriggerEvent(string eventMessage)
    {

        //It does not need to take a minute value
        //its adjustment is made when calling the event triggers.
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
        // After 20 minutes the game will end, its codes are here
    }
}
