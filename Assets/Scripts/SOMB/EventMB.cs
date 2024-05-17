using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EventMB : MonoBehaviour
{
    [field: SerializeField] public EventData Data { get; private set; }
}

[System.Serializable]
public class EventData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Desc { get; private set; }
    [field: SerializeField] public string PositiveName { get; private set; }
    [field: SerializeField] public EventBundle PositiveEffects { get; private set; }
    [field: SerializeField] public string NegativeName { get; private set; }
    [field: SerializeField] public EventBundle NegativeEffects { get; private set; }
}

[System.Serializable]
public class EventBundle
{
    [field: SerializeField] public EventResourceChange[] ResourceChanges { get; private set; }
    [field: SerializeField] public EventResourceRandomChange[] ResourceRandomChanges { get; private set; }
}

public abstract class EventResource
{
    [field: SerializeField] public Resource Resource { get; private set; }
    [field: SerializeField] public bool IsPercentChange { get; private set; }
}

[System.Serializable]
public class EventResourceChange : EventResource
{
    [field: SerializeField] public int Change { get; private set; }
}

[System.Serializable]
public class EventResourceRandomChange : EventResource
{
    [field: SerializeField] public int MinChange { get; private set; }
    [field: SerializeField] public int MaxChange { get; private set; }
    public int Next { get => Random.Range(MinChange, MaxChange); }
}

[System.Serializable]
public class EventResourceDepr
{
    public Resource Resource;
    public int Change;
    public bool IsPercentChange;
}
