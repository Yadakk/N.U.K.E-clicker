using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SliderSetting))]
public class MixerVolumeController : MonoBehaviour, IInitOnSceneLoad
{
    [SerializeField] private string _exposedParamName;
    private SliderSetting _sliderSetting;
    public AudioMixerGroup ControlledMixerGroup;

    private void Start()
    {
        _sliderSetting.Slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        float t = Mathf.Pow(volume, 0.25f);
        ControlledMixerGroup.audioMixer.SetFloat(_exposedParamName, Mathf.Lerp(-80f, 0f, t));
    }

    public void OnSceneLoad()
    {
        _sliderSetting = GetComponent<SliderSetting>();
        SetVolume(PlayerPrefs.GetFloat(_sliderSetting.name, _sliderSetting.Default));
    }
}
