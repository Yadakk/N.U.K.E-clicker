using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private string _textToDisplay;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltipStatic(_textToDisplay);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }

    public void SetText(string text)
    {
        _textToDisplay = text;
    }
}
