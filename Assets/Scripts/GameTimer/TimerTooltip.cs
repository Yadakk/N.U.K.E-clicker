using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class TimerTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int RemainingMonths { get => GameTimer.Instance.RemainingMonths; }
    private int _remainingYears;

    private void Start()
    {
        _remainingYears = Mathf.FloorToInt((float)RemainingMonths / 12);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("Time left:");
        stringBuilder.AppendLine(_remainingYears + " Years");
        stringBuilder.AppendLine(_remainingYears * 12 - RemainingMonths + " Months");
        Tooltip.ShowTooltipStatic(stringBuilder.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}
