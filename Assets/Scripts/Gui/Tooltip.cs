using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Tooltip : MonoBehaviour
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }
    private IEnumerator UpdateTooltip()
    {
        while (true)
        {
            Vector2 anchoredPosition = _rect.anchoredPosition;
            Rect screenRect = new Rect(0, 0, Screen.currentResolution.width, Screen.currentResolution.height);

            if (anchoredPosition.x < screenRect.x)
            {
                anchoredPosition.x = screenRect.x;
            }

            if (anchoredPosition.y < screenRect.y)
            {
                anchoredPosition.y = screenRect.y;
            }

            yield return null;
        }
    }
}