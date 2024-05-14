using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utilities.IntBoolParseUtility;

public class ToggleSetting : MonoBehaviour
{
    [SerializeField] private bool _default;
    private Toggle _toggle;

    private void Start()
    {
        _toggle = GetComponentInChildren<Toggle>();
        _toggle.isOn = IntToBool(PlayerPrefs.GetInt(name, BoolToInt(_default)));
        _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool val)
    {
        PlayerPrefs.SetInt(name, BoolToInt(val));
    }
}
