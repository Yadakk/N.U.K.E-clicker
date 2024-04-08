using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private Image _image;
    private Coroutine _coroutine;
    private bool _enableFlag;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void OnDisable()
    {
        OnInitAll -= InitAllHandler;

        if (_coroutine != null)
        {
            StopCoroutine(UpdateTimer());
            _coroutine = null;
        }
    }
    private void InitAllHandler()
    {
        _image = GetComponent<Image>();
        _coroutine ??= StartCoroutine(UpdateTimer());
    }

    private void OnEnable()
    {
        if (!_enableFlag)
        {
            _enableFlag = true;
            return;
        }

        _coroutine ??= StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            _image.fillAmount = Timer.Instance.Remaining / Timer.Instance.Seconds;
            yield return null;
        }
    }
}
