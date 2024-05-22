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
    public float RemainingSeconds { get; private set; }
    public int RemainingMonths { get; private set; }
    public readonly UnityEvent OnTimerStarted = new();
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
            RemainingMonths = Mathf.CeilToInt(RemainingSeconds / _secondsToMonthsRatio);
            yield return null;
        }

        SceneManager.LoadScene("GameOver");
    }
}
