using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float elapsedTime = 0;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI eventText;


    private void Start()
    {
        StartCoroutine(StartTimer());
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
        int minutes = Mathf.FloorToInt(seconds / 60f); // Checking how many minutes it's been

        if (minutes == 0)
        {
            TriggerEvent("0 min passed!"); //Test code for timer events (if i don't remember xd)
        }
    }

    void TriggerEvent(string message)
    {
        eventText.text = message;
        Debug.Log(message);
    }
}
