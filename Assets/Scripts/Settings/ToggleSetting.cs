using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSetting : MonoBehaviour
{
    private Toggle _toggle;

    private void Start()
    {
        _toggle = GetComponentInChildren<Toggle>();
        _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool val)
    {
        PlayerPrefs.SetInt(name, val ? 1 : 0);
    }
}
