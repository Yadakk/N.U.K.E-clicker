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
        builder.AppendLine(data.PositiveName);
        foreach(var eff in data.PositiveEffects)
        {
            builder.AppendLine(eff.Resource.Name);
        }
        builder.AppendLine(data.NegativeName);
        foreach (var eff in data.NegativeEffects)
        {
            builder.AppendLine(eff.Resource.Name);
        }
        _tmpu.text = builder.ToString();
    }
}
