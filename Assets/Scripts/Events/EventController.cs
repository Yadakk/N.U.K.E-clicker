using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(EventHolder))]
public class EventController : MonoBehaviour
{
    [field: SerializeField] public float LifeSpanSeconds { get; set; } = 1f;
    private EventHolder _eventHolder;
    private EventData _eventData;
    private Button _button;
    private Timer _timer;
    private EventFillSetter _fillSetter;
    [NonSerialized] public EventInformer Informer;

    private void Start()
    {
        _button = GetComponent<Button>();
        _timer = GetComponent<Timer>();
        _eventHolder = GetComponent<EventHolder>();
        _fillSetter = GetComponentInChildren<EventFillSetter>();
        _button.onClick.AddListener(OnButtonClickHandler);
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
        _timer.StartTimer(LifeSpanSeconds);
        _timer.OnTimerFinished.AddListener(() => Destroy(gameObject));
    }

    private void Update()
    {
        _fillSetter.SetFillLerp(_timer.Remaining);
    }

    public void OnButtonClickHandler()
    {
        Informer.DisplayInfo(_eventData, this);
    }
}
