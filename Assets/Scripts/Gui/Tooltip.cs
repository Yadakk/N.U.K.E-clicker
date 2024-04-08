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
    private RectTransform _backgroundRectTransform;
    private RectTransform _parentTransform;
    private static Tooltip _instance;
    private static bool _isActive;

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
        _instance = this;
        _camera = Camera.current;
        _canvas = ActiveCanvas.Canvas;
        _canvasRect = _canvas.GetComponent<RectTransform>();
        _tmpu = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _backgroundRectTransform = GetComponent<RectTransform>();
        _parentTransform = transform.parent.GetComponent<RectTransform>();
        HideTooltipStatic();
    }
    #endregion

    private void Update()
    {
        MoveToMouse();
    }

    private void MoveToMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentTransform, Input.mousePosition, _camera, out Vector2 localPoint);
        transform.localPosition = localPoint;

        Vector2 anchoredPosition = _backgroundRectTransform.anchoredPosition;

        if (anchoredPosition.x + _backgroundRectTransform.rect.width > _canvasRect.rect.width)
        {
            anchoredPosition.x = _canvasRect.rect.width - _backgroundRectTransform.rect.width;
        }

        if (anchoredPosition.y + _backgroundRectTransform.rect.height > _canvasRect.rect.height)
        {
            anchoredPosition.y = _canvasRect.rect.height - _backgroundRectTransform.rect.height;
    }

        _backgroundRectTransform.anchoredPosition = anchoredPosition;
    }

    private void ShowTooltip(string tooltipString)
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(true);

        _tmpu.text = tooltipString;
        Vector2 backgroundSize = new(_tmpu.preferredWidth,
                                     _tmpu.preferredHeight);
        _backgroundRectTransform.sizeDelta = backgroundSize;

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
        if(_isActive)
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