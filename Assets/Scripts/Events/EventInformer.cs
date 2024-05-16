using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class EventInformer : MonoBehaviour
{
    public EventData Data { get; private set; }
    [SerializeField] private TextMeshProUGUI _descTmpu;
    [SerializeField] private TextMeshProUGUI _posTmpu;
    [SerializeField] private TextMeshProUGUI _negTmpu;

    private void Start()
    {
        _descTmpu = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayInfo(EventData data)
    {
        Data = data;
        _descTmpu.text = Data.Desc;
        _posTmpu.text = Data.PositiveName;
        _negTmpu.text = Data.NegativeName;
    }
}
