using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveCanvas : MonoBehaviour
{
    private Canvas _canvas;

    public static Canvas Canvas;

    #region Initter
    private static UnityEvent _initAll = new();
    private void Awake()
    {
        _initAll.AddListener(OnInitAll);
    }
    public static void InitAll()
    {
        _initAll.Invoke();
    }
    private void OnInitAll()
    {
        _canvas = GetComponent<Canvas>();
        Canvas = _canvas;
    }
    #endregion

    private void OnEnable()
    {
        Canvas = _canvas;
    }
}