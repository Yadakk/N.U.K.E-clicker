using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JsonSaverLib;

public class SettingsSaver : MonoBehaviour
{
    [SerializeField] private string _path;
    [SerializeField] private Slider[] _sliders;

    private Settings _settings;

    [System.Serializable]
    private class Settings
    {
        public FloatSetting FloatSettings;
    }

    [System.Serializable]
    private class FloatSetting
    {
        public string Name;
        public float Value;
    }

    private void Save()
    {
        Saver.Save(_path, _settings);
    }

    private void Load()
    {
        _settings = Saver.Load<Settings>(_path);
    }
}