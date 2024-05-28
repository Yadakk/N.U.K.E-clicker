using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public StarsController StarsController;
    public float Seconds;
    public int MonthsForConversion = 60;
    [NonSerialized] public static GameTimer Instance;
    private float _remainingSeconds;
    public float RemainingSeconds 
    { 
        get
        {
            if (_remainingSeconds < 0) return 0;
            return _remainingSeconds;
        }
        set => _remainingSeconds = value;
    }

    public int RemainingMonths { get; private set; }
    public readonly UnityEvent OnTimerStarted = new();
    public readonly UnityEvent OnMonthsAmountChanged = new();
    public float MonthDurationInSeconds { get => Seconds / MonthsForConversion; }
    private void Start()
    {
        Instance = this;
        RemainingSeconds = Seconds;
        StartCoroutine(TimerCoroutine());
    }
    
    private IEnumerator TimerCoroutine()
    {
        OnTimerStarted.Invoke();

        while (RemainingSeconds > 0)
        {
            RemainingSeconds -= Time.deltaTime;
            bool monthsChanged = RemainingMonths != SecondsToIngameMonths();
            RemainingMonths = SecondsToIngameMonths();
            if (monthsChanged) OnMonthsAmountChanged.Invoke();
            yield return null;
        }
        IntersceneVariables.IsBadEnding = false;
        StarsController.AddStars();
        SceneManager.LoadScene("GameOver");
    }

    private int SecondsToIngameMonths()
    {
        return Mathf.FloorToInt(RemainingSeconds / MonthDurationInSeconds);
    }
}
