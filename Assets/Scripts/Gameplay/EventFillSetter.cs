using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class EventFillSetter : MonoBehaviour
{
    private RectTransform _rectTransform;
    private RectTransform _parentRectTransform;

    private void Start()
    {
        NullCheckGetComponents();
    }

    private void NullCheckGetComponents()
    {
        if (_rectTransform == null) _rectTransform = GetComponent<RectTransform>();
        if (_parentRectTransform == null) _parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    public void SetFillLerp(float t)
    {
        NullCheckGetComponents();
        _rectTransform.sizeDelta = new(Mathf.Lerp(0f, _parentRectTransform.sizeDelta.x, t), 0f);
    }
}