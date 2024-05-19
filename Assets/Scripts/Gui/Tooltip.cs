using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Tooltip : MonoBehaviour
{
    private Camera _camera;
    private Canvas _canvas;
    private TextMeshProUGUI _tmpu;
    private RectTransform _canvasRect;
    private RectTransform _rectTransform;
    private static Tooltip _instance;
    private static bool _isActive;
    [field: SerializeField] public Vector2 Offset { get; set; }

    private void Start()
    {
        _instance = this;
        _camera = Camera.current;
        _canvas = ActiveCanvas.Canvas;
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _tmpu = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
        HideTooltipStatic();
    }

    private void Update()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, _camera, out Vector2 localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = _rectTransform.anchoredPosition + Offset;

        if (anchoredPosition.x + _rectTransform.rect.width > _canvasRect.rect.width)
        {
            anchoredPosition.x = _canvasRect.rect.width - _rectTransform.rect.width;
        }

        if (anchoredPosition.y + _rectTransform.rect.height > _canvasRect.rect.height)
        {
            anchoredPosition.y = _canvasRect.rect.height - _rectTransform.rect.height;
    }

        _rectTransform.anchoredPosition = anchoredPosition;
    }

    private void ShowTooltip(string tooltipString)
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(true);

        _tmpu.text = tooltipString;
        Vector2 backgroundSize = new(_tmpu.preferredWidth,
                                     _tmpu.preferredHeight);
        _rectTransform.sizeDelta = backgroundSize;

        _isActive = true;

        MoveToMouse();
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);

        _isActive = false;
    }

    private void ToggleTooltip(string tooltipString)
    {
        if (_isActive)
        {
            HideTooltip();
        }
        else
        {
            ShowTooltip(tooltipString);
        }
    }

    public static void ShowTooltipStatic(string tooltipString)
    {
        _instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltipStatic()
    {
        _instance.HideTooltip();
    }

    public static void ToggleTooltipStatic(string tooltipString)
    {
        _instance.ToggleTooltip(tooltipString);
    }
}