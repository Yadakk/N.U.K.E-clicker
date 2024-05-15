using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utilities.IntBoolParseUtility;

public class ToggleSetting : MonoBehaviour, IInitOnSceneLoad
{
    [SerializeField] private bool _default;
    public bool Default { get => _default;}
    private Toggle _toggle;
    public Toggle Toggle => _toggle;

    private void Start()
    {
        _toggle.isOn = IntToBool(PlayerPrefs.GetInt(name, BoolToInt(_default)));
        _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool val)
    {
        PlayerPrefs.SetInt(name, BoolToInt(val));
    }

    public void OnSceneLoad()
    {
        _toggle = GetComponentInChildren<Toggle>();
    }
}
