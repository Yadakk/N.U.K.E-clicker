using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveCanvas : MonoBehaviour
{
    private Canvas _canvas;
    public static Canvas Canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        Canvas = _canvas;
    }

    private void OnEnable()
    {
        Canvas = _canvas;
    }
}