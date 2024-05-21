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
        _rectTransform = GetComponent<RectTransform>();
        _parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    public void SetFillLerp(float t)
    {
        Rect rect = _rectTransform.rect;
        rect.x = Mathf.Lerp(-GetOffset(), GetOffset(), t);

    }

    private float GetOffset()
    {
        return _parentRectTransform.rect.position.x + _parentRectTransform.rect.x;
    }
}
