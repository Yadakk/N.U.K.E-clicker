using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDistanceSetting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SliderSetting _sliderSetting;
    public Vector2 MinMaxDistance;

    private void Start()
    {
        _sliderSetting = GetComponent<SliderSetting>();
        SetTooltipDistance(PlayerPrefs.GetFloat(name, _sliderSetting.Default));
        _sliderSetting.Slider.onValueChanged.AddListener(OnSliderValueChangedHandler);
    }

    private void OnSliderValueChangedHandler(float val)
    {
        SetTooltipDistance(val);
    }

    private void SetTooltipDistance(float val)
    {
        float offset = Mathf.Lerp(MinMaxDistance.x, MinMaxDistance.y, val);
        Tooltip.Offset = Vector2.one * offset;
        PlayerPrefs.SetFloat(name, val);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.ShowTooltipStatic("Test tooltip");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideTooltipStatic();
    }
}
