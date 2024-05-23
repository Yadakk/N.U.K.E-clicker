using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
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
        private set => _remainingSeconds = value; }
    public int RemainingMonths { get; private set; }
    public readonly UnityEvent OnTimerStarted = new();
    public readonly UnityEvent OnMonthsAmountChanged = new();
    private float _secondsToMonthsRatio;
    private void Start()
    {
        Instance = this;
        _secondsToMonthsRatio = Seconds / MonthsForConversion;
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
        SceneManager.LoadScene("GameOver");
    }

    private int SecondsToIngameMonths()
    {
        return Mathf.FloorToInt(RemainingSeconds / _secondsToMonthsRatio);
    }
}
