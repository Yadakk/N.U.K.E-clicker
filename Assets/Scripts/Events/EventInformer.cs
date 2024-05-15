using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class EventInformer : MonoBehaviour
{
    private TextMeshProUGUI _tmpu;

    private void Start()
    {
        _tmpu = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void DisplayInfo(EventData data)
    {
        StringBuilder builder = new();
        builder.AppendLine(data.Desc);
        _tmpu.text = builder.ToString();
    }
}
