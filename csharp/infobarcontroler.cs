using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class speedotext : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 30f;

    [SerializeField]
    private float currentSpeed = 0f;

    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private PathFollower pathFollower;
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        currentSpeed = pathFollower.speed;
        UpdateSpeedometer();
        if (isTimerRunning)
        {
            UpdateTimer();
        }
    }

    float CalculateSpeed()
    {
        // Ensure that maxSpeed is not zero to avoid division by zero
        if (maxSpeed == 0f)
        {
            Debug.LogError("maxSpeed should be greater than zero.");
            return 0f;
        }

        // Calculate speed as a percentage of maxSpeed
        float speedPercentage = currentSpeed / maxSpeed;

        // Multiply by 320 to get a value between 0 and 320
        float speedValue = speedPercentage * 320f;

        return speedValue;
    }

    void UpdateSpeedometer()
    {
        // Call the CalculateSpeed function
        float speed = CalculateSpeed();

        // Update the speedText with the speed value + km/h
        speedText.text = speed.ToString("F1") + " km/h";
    }
    public void StartTimer()
    {
        // Reset the timer
        elapsedTime = 0f;
        isTimerRunning = true;
    }

    void UpdateTimer()
    {
        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        // Update the timerText with the formatted time
        timerText.text = FormatTime(elapsedTime);
    }

    string FormatTime(float timeInSeconds)
    {
        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000);

        // Format the time as minutes:seconds:milliseconds
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        return formattedTime;
    }
}
