using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetting : MonoBehaviour
{
    [SerializeField] private float _default = 0.75f;
    public float Default { get => _default; }
    private Slider _slider;
    public Slider Slider { get => _slider; }

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = PlayerPrefs.GetFloat(name, _default);
        _slider.onValueChanged.AddListener(OnSliderValueChangedHandler);
    }

    private void OnSliderValueChangedHandler(float val)
    {
        PlayerPrefs.SetFloat(name, val);
    }
}
