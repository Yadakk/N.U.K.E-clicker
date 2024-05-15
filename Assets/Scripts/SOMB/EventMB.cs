using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMB : MonoBehaviour
{
    [field: SerializeField]
    public EventData Data { get; private set; }
}

[System.Serializable]
public class EventData
{
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public string Desc { get; private set; }
    [field: SerializeField]
    public string PositiveName { get; private set; }
    [field: SerializeField]
    public EventResource[] PositiveEffects { get; private set; }
    [field: SerializeField]
    public string NegativeName { get; private set; }
    [field: SerializeField]
    public EventResource[] NegativeEffects { get; private set; }
}

[System.Serializable]
public class EventResource
{
    public Resource Resource;
    public int Change;
    public bool IsPercentChange;
}
