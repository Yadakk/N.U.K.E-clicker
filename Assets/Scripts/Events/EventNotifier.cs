using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EventNotifier : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform EventFolder;
    public GameObject ExclamationMark;
    [SerializeField] private SoundPlayer _soundPlayer;
    private bool _hasEvents;
    private bool _isPointerInside;
    private int _displayedChildCount;

    public void Notify()
    {
        if (_soundPlayer != null) _soundPlayer.PlaySound();
    }

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
        UpdateTooltip();
        if (_hasEvents == EventFolder.childCount > 0) return;
        _hasEvents = EventFolder.childCount > 0;
        ExclamationMark.SetActive(_hasEvents);
    }

    private void UpdateTooltip()
    {
        if (!_isPointerInside) return;
        if (_displayedChildCount != EventFolder.childCount)
            _displayedChildCount = EventFolder.childCount;
        Tooltip.ShowTooltipStatic(_hasEvents ? "You have " + _displayedChildCount + " unanswered events" : "You have no unanswered events");
    }
}
