using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public float Seconds;

    [NonSerialized] public static Timer Instance;
    [NonSerialized] public float Remaining;

    private void Awake()
    {
        Instance = this;
    }
    public static void Init()
    {
        Instance.Remaining = Instance.Seconds;
        Instance.StartCoroutine(Instance.TimerCoroutine());
    }
    
    private IEnumerator TimerCoroutine()
    {
        while (Remaining > 0)
        {
            Remaining -= Time.deltaTime;
            yield return null;
        }
    }
}
