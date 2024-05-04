using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsSaver : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;

    private bool _wasLoaded;

    private void Awake()
    {
        if (_wasLoaded) return;
        Load();
        _wasLoaded = true;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        foreach (var slider in _sliders)
        {
            PlayerPrefs.SetFloat(slider.name, slider.value);
        }

        PlayerPrefs.Save();
    }

    public void Load()
    {
        foreach (var slider in _sliders)
        {
            slider.value = PlayerPrefs.GetFloat(slider.name);
        }
    }
}