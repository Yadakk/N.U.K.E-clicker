using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSaver : MonoBehaviour
{
    [SerializeField] private string _path;
    [SerializeField] private Settings _settings;

    [System.Serializable]
    private class Settings
    {
        public Slider[] _sliders;
    }

    private void Save()
    {
        foreach(Slider slider in _settings._sliders)
        {
            
        }
    }
}