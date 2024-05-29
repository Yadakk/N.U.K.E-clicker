using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text;

public class EventTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private EventController _controller;
    public EventController Controller
    {
        get
        {
            if (_controller == null) _controller = GetComponent<EventController>();
            return _controller;
        }

        set => _controller = value;
    }
    private bool _isPointerInside;
    private int _currentlyDisplayedMonths;
    private int _currentlyDisplayedYears;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerInside = false;
        Tooltip.HideTooltipStatic();
    }

    private void Update()
    {
        if (!_isPointerInside) return;
        int timerMonths = Mathf.FloorToInt(Controller.Timer.Seconds * Controller.Timer.Remaining / GameTimer.Instance.MonthDurationInSeconds);
        if (timerMonths != _currentlyDisplayedMonths)
            _currentlyDisplayedMonths = timerMonths;
        int timerYears = Mathf.FloorToInt((float)_currentlyDisplayedMonths / 12);
        if (timerYears != _currentlyDisplayedYears)
            _currentlyDisplayedYears = timerMonths;

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("Time until negative choice gets auto-picked:");
        if (_currentlyDisplayedYears > 0) stringBuilder.AppendLine(_currentlyDisplayedYears + " Years");
        if (_currentlyDisplayedMonths % 12 != 0) stringBuilder.AppendLine(_currentlyDisplayedMonths % 12 + " Months");
        if (!(_currentlyDisplayedYears > 0) && !(_currentlyDisplayedMonths % 12 != 0)) stringBuilder.AppendLine("Last month!");
        Tooltip.ShowTooltipStatic(stringBuilder.ToString());
    }
}
