using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using System;

public class TimerTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int RemainingMonths { get => GameTimer.Instance.RemainingMonths; }
    public int RemainingYears { get => Mathf.FloorToInt((float)RemainingMonths / 12); }
    private bool _isPointerInside;

    private void Start()
    {
        GameTimer.Instance.OnMonthsAmountChanged.AddListener(OnMonthsAmountChangedHandler);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerInside = true;
        DisplayTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerInside = false;
        Tooltip.HideTooltipStatic();
    }

    private void OnMonthsAmountChangedHandler()
    {
        if (_isPointerInside) DisplayTooltip();
    }

    private void DisplayTooltip()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("Time left:");
        if (RemainingYears > 0) stringBuilder.AppendLine(RemainingYears + " Years");
        if (RemainingMonths % 12 != 0) stringBuilder.AppendLine(RemainingMonths % 12 + " Months");
        if (!(RemainingYears > 0) && !(RemainingMonths % 12 != 0)) stringBuilder.AppendLine("Last month!");
        Tooltip.ShowTooltipStatic(stringBuilder.ToString());
    }
}
