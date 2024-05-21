using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public float Seconds;
    [NonSerialized] public static GameTimer Instance;
    [NonSerialized] public float Remaining;
    public readonly UnityEvent OnTimerStarted = new();

    private void Start()
    {
        Instance = this;
        Remaining = Seconds;
        StartCoroutine(TimerCoroutine());
    }
    
    private IEnumerator TimerCoroutine()
    {
        OnTimerStarted.Invoke();

        while (Remaining > 0)
        {
            Remaining -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene("GameOver");
    }
}
