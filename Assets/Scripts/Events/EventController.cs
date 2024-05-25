using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

[RequireComponent(typeof(EventHolder))]
public class EventController : MonoBehaviour
{
    [field: SerializeField] public float MinLifeSpanSeconds { get; set; } = 1f;
    [field: SerializeField] public float MaxLifeSpanSeconds { get; set; } = 1f;
    private SoundPlayer _soundPlayer;
    private EventHolder _eventHolder;
    private EventData _eventData;
    private Button _button;
    private Timer _timer;
    private EventFillSetter _fillSetter;
    [NonSerialized] public EventInformer Informer;
    public static readonly UnityEvent OnAppliedChangesStatic = new();

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        _button = GetComponent<Button>();
        GetFillSetter();
        _button.onClick.AddListener(OnButtonClickHandler);
        if (_eventHolder.Data == null)
            _eventHolder.OnDataSet.AddListener(OnDataSetHandler);
        else
        {
            _eventData = _eventHolder.Data;
            SetUp();
        }
    }

    private void GetFillSetter()
    {
        if (_fillSetter == null) _fillSetter = GetComponentInChildren<EventFillSetter>();
    }

    public void Init()
    {
        _eventHolder = GetComponent<EventHolder>();
        CreateTimer();
    }

    private void CreateTimer()
    {
        if (_timer != null) return;
        var timerObject = new GameObject("EventTimer");
        timerObject.transform.parent = GlobalTimerContainer.Instance.transform;
        _timer = timerObject.AddComponent<Timer>();
        _timer.StartTimer(UnityEngine.Random.Range(MinLifeSpanSeconds, MaxLifeSpanSeconds));
        _timer.OnTimerFinished.AddListener(OnTimerFinishedHandler);
    }

    private void OnTimerFinishedHandler()
    {
        Destroy(_timer.gameObject);
        _eventHolder.Data.NegativeEffects.GetAllResources().ToList().ForEach(change => change.ApplyChanges());
        OnAppliedChangesStatic.Invoke();
        Informer.ClearData(this);
        _soundPlayer.PlaySound(1);
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

    private void Update()
    {
        SetFill();
    }

    private void OnEnable()
    {
        CreateTimer();
        GetFillSetter();
        SetFill();
    }

    private void SetFill()
    {
        _fillSetter.SetFillLerp(_timer.Remaining);
    }

    private void OnButtonClickHandler()
    {
        Informer.DisplayInfo(_eventData, this);
        _soundPlayer.PlaySound(0);
    }
}
