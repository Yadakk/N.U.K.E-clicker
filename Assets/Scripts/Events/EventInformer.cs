using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class EventInformer : MonoBehaviour
{
    public EventData Data { get; private set; }
    public EventController Controller { get; private set; }
    [SerializeField] private TextMeshProUGUI _descTmpu;
    [SerializeField] private TextMeshProUGUI _posTmpu;
    [SerializeField] private TextMeshProUGUI _negTmpu;

    private void Start()
    {
        _descTmpu = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayInfo(EventData data, EventController controller)
    {
        Controller = controller;
        Data = data;
        _descTmpu.text = Data.Desc;
        _posTmpu.text = Data.PositiveName;
        _negTmpu.text = Data.NegativeName;
    }

    public void ClearData()
    {
        HideData();
        Destroy(Controller.gameObject);
    }

    public void ClearData(EventController controller)
    {
        HideData();
        Destroy(controller.gameObject);
    }

    public void HideData()
    {
        Data = null;
        _descTmpu.text = string.Empty;
        _posTmpu.text = string.Empty;
        _negTmpu.text = string.Empty;
    }

    private void OnDisable()
    {
        HideData();
    }
}
