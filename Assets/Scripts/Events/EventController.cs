using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(EventHolder))]
public class EventController : MonoBehaviour
{
    private EventHolder _eventHolder;
    private EventData _eventData;
    private Button _button;
    [NonSerialized] public EventInformer Informer;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClickHandler);
        _eventHolder = GetComponent<EventHolder>();
        if (_eventHolder.Data == null)
            _eventHolder.OnDataSet.AddListener(OnDataSetHandler);
        else
        {
            _eventData = _eventHolder.Data;
            SetUp();
        }
    }

    private void OnDataSetHandler(EventData data)
    {
        _eventData = data;
        SetUp();
    }

    private void SetUp()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = _eventData.Name;
    }

    public void OnButtonClickHandler()
    {
        Informer.DisplayInfo(_eventData);
    }
}
