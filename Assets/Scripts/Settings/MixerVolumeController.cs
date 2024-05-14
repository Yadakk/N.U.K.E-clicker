using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SliderSetting))]
public class MixerVolumeController : MonoBehaviour
{
    [SerializeField] private string _exposedParamName;
    private SliderSetting _sliderSetting;
    public AudioMixerGroup ControlledMixerGroup;

    private IEnumerator Start()
    {
        _sliderSetting = GetComponent<SliderSetting>();
        SetVolume(PlayerPrefs.GetFloat(_sliderSetting.name, _sliderSetting.Default));
        yield return new WaitUntil(() => _sliderSetting.Slider != null);
        Debug.Log("Waited");
        _sliderSetting.Slider.onValueChanged.AddListener(SetVolume);
    }

    private void Update()
    {
        Debug.Log(_sliderSetting.Slider);
    }

    private void SetVolume(float volume)
    {
        float t = Mathf.Log10(volume) + 1;
        Debug.Log(t);
        ControlledMixerGroup.audioMixer.SetFloat(_exposedParamName, Mathf.Lerp(-80f, 0f, t));
    }
}
