using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHolder : MonoBehaviour
{
    public EventData Data { get; private set; }
    public readonly UnityEvent<EventData> OnDataSet = new();

    public void SetData(EventData data)
    {
        Data = data;
        OnDataSet.Invoke(Data);
    }
}
