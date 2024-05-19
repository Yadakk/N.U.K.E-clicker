using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TmpuColorFlash : MonoBehaviour
{
    [field: SerializeField] public float FlashTime { get; set; } = 1f;
    [field: SerializeField] public float HoldFlashFor { get; set; } = 1f;
    [field: SerializeField] public Color MainColor { get; set; } = Color.white;
    private TextMeshProUGUI _tmpu;
    private float _t;
    private float _holdCountdown;
    private Color _flashColor;

    private void Start()
    {
        _holdCountdown = HoldFlashFor;
        _flashColor = MainColor;
        _tmpu = GetComponent<TextMeshProUGUI>();
    }
    
    private void Update()
    {
        CDPassiveChange();
        if (_holdCountdown == 0f) TPassiveChange();
        _tmpu.color = NicerColorLerp(MainColor, _flashColor, _t);
    }

    public void FlashColor(Color color)
    {
        _flashColor = color;
        _t = 1f;
        _holdCountdown = HoldFlashFor;
    }

    private void TPassiveChange()
    {
        if (_t > 0f && FlashTime > 0) _t -= Time.deltaTime / FlashTime;
        else _t = 0f;
    }

    private void CDPassiveChange()
    {
        if (_holdCountdown > 0f && HoldFlashFor > 0) _holdCountdown -= Time.deltaTime / HoldFlashFor;
        else _holdCountdown = 0f;
    }

    Color NicerColorLerp(Color A, Color B, float t)
    {
        return new Color(Mathf.Sqrt(A.r * A.r * (1 - t) + t * B.r * B.r),
                         Mathf.Sqrt(A.g * A.g * (1 - t) + t * B.g * B.g),
                         Mathf.Sqrt(A.b * A.b * (1 - t) + t * B.b * B.b));
    }
}
