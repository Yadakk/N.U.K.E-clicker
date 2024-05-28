using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetting : MonoBehaviour
{
    [SerializeField] private float _default = 0.75f;
    public float Default { get => _default; }
    private Slider _slider;
    public Slider Slider
    {
        get
        {
            GetSlider();
            return _slider;
        }
    }

    private void GetSlider()
    {
        if (_slider == null) _slider = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        GetSlider();
        _slider.value = PlayerPrefs.GetFloat(name, _default);
        _slider.onValueChanged.AddListener(OnSliderValueChangedHandler);
    }

    private void OnSliderValueChangedHandler(float val)
    {
        PlayerPrefs.SetFloat(name, val);
    }
}
