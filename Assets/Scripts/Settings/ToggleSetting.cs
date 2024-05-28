using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utilities.IntBoolParseUtility;

public class ToggleSetting : MonoBehaviour, IInitOnSceneLoad
{
    [SerializeField] private bool _default;
    public bool Default { get => _default; }
    private Toggle _toggle;
    public Toggle Toggle
    {
        get
        {
            if (_toggle == null) _toggle = GetComponentInChildren<Toggle>();
            return _toggle;
        }
        set
        {
            _toggle = value;
        }
    }

    private SoundPlayer _soundPlayer;

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        Toggle.isOn = IntToBool(PlayerPrefs.GetInt(name, BoolToInt(_default)));
        Toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
    }

    private void OnToggleValueChangedHandler(bool val)
    {
        if (_soundPlayer != null) _soundPlayer.PlaySound(BoolToInt(!val));
        PlayerPrefs.SetInt(name, BoolToInt(val));
    }

    public void OnSceneLoad()
    {
        Toggle = GetComponentInChildren<Toggle>();
    }
}
