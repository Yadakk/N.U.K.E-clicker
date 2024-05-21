using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimerContainer : MonoBehaviour
{
    public static GlobalTimerContainer Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }
}
