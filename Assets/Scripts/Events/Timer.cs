using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public readonly UnityEvent OnTimerFinished = new();

    private readonly float _initial = 1f;
    private float _seconds;
    private bool _isRunning;
    public float Remaining { get; private set; } = 1f;
    public float Seconds { get => _seconds; private set => _seconds = value; }

    private void Update()
    {
        Remaining -= Time.deltaTime / _seconds;
        if (_isRunning && Remaining < 0)
        {
            OnTimerFinished.Invoke();
            _isRunning = false;
        }
    }

    public void StartTimer(float seconds)
    {
        _isRunning = true;
        _seconds = seconds;
        Remaining = _initial;
    }
}
