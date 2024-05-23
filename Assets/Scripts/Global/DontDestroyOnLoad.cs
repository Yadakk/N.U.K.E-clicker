using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public DontDestroyOnLoad Instance { get; private set; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}