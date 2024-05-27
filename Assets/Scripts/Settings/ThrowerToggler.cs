using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utilities.IntBoolParseUtility;

[RequireComponent(typeof(PrefabThrower))]
public class ThrowerToggler : MonoBehaviour
{
    [SerializeField] private ToggleSetting _toggleSetting;
    private PrefabThrower _prefabThrower;

    void Start()
    {
        _prefabThrower = GetComponent<PrefabThrower>();
        UpdateThrower();
        _toggleSetting.Toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool val)
    {
        UpdateThrower(val);
    }

    private void UpdateThrower() => _prefabThrower.enabled = IntToBool(PlayerPrefs.GetInt(_toggleSetting.name, BoolToInt(_toggleSetting.Default)));
    private void UpdateThrower(bool val) => _prefabThrower.enabled = val;
}