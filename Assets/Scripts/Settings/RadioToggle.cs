using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class RadioToggle : MonoBehaviour
{
    private Toggle _toggle;

    private void Start()
    {
        _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool playRadio)
    {
        
    }
}
