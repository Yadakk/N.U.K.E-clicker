using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using static Utilities.IntBoolParseUtility;

[RequireComponent(typeof(Toggle))]
public class RadioToggle : MonoBehaviour
{
    public readonly static UnityEvent<bool> OnAnyToggleSwitched = new();
    public readonly static string PrefsKey = "PlayRadio";
    private Toggle _toggle;
    private Image _image;
    bool _toggledByPress = true;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _image = GetComponent<Image>();
        SetRadioGraphics(IntToBool(PlayerPrefs.GetInt(PrefsKey)));
        OnAnyToggleSwitched.AddListener(OnUpdateAllTogglesHandler);
        _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool playRadio)
    {
        if (_toggledByPress)
        {
            PlayerPrefs.SetInt(PrefsKey, BoolToInt(playRadio));
            OnAnyToggleSwitched.Invoke(playRadio);
        }
    }

    private void OnUpdateAllTogglesHandler(bool playRadio)
    {
        SetRadioGraphics(playRadio);
    }

    private void SetRadioGraphics(bool playRadio)
    {
        ToggleByCode(playRadio);
        _image.color = playRadio ? Color.green : Color.white;
    }

    private void ToggleByCode(bool playRadio)
    {
        _toggledByPress = false;
        _toggle.isOn = playRadio;
        _toggledByPress = true;
    }
}
