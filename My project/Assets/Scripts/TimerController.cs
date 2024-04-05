using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    [Header("Timer Component")]

    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Timer Format")]
    public bool hasFormat;
    public TimerFormat format;
    private Dictionary<TimerFormat, string> timerFormat = new Dictionary<TimerFormat, string>();

    [Header("Timer Limit")]
    public bool hasLimit;
    public float timerLimit;

    void Start()
    {
    
        timerFormat.Add(TimerFormat.Whole, "0");
        timerFormat.Add(TimerFormat.TenthDecimal, "0.0");
        timerFormat.Add(TimerFormat.HundrethsDecimal, "0.00");

        currentTime = 0;
        SetTimerText();
    }

    void Update()
    {
    currentTime = countDown ? currentTime - Time.deltaTime : currentTime + Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        if (hasFormat)
        {
            timerText.text = currentTime.ToString(format: timerFormat[format]);
        }
        else
        {
            timerText.text = currentTime.ToString();
        }
    }

    public enum TimerFormat
    {
        Whole,
        TenthDecimal,
        HundrethsDecimal
    }
}
