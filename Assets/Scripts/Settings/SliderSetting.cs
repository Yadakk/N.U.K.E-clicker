using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetting : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.onValueChanged.AddListener(OnSliderValueChangedHandler);
    }

    private void OnSliderValueChangedHandler(float val)
    {
        PlayerPrefs.SetFloat(name, val);
    }
}
