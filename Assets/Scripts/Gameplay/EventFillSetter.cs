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
        _rectTransform.sizeDelta = new(Mathf.Lerp(0f, _parentRectTransform.sizeDelta.x, t), 0f);
    }
}