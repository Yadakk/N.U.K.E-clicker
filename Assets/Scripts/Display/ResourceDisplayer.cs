using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplayer : MonoBehaviour
{
    private Resource _resourceToDisplay;
    private Transform _icon;
    private Transform _value;
    private Image _image;
    private TextMeshProUGUI _text;
    private TooltipOnHover _tooltipOnHover;

    public void Init(Resource resourceToDisplay)
    {
        _resourceToDisplay = resourceToDisplay;

        _icon = transform.GetChild(0);
        _value = transform.GetChild(1);

        _image = _icon.GetComponent<Image>();
        _text = _value.GetComponent<TextMeshProUGUI>();
        _tooltipOnHover = _icon.GetComponent<TooltipOnHover>();
        _image.sprite = _resourceToDisplay.Icon;
        _resourceToDisplay.OnAmountChange += AmountChangeHandler;
        _tooltipOnHover.SetText(_resourceToDisplay.Name);
        UpdateCounter(_resourceToDisplay.Amount);
    }

    private void AmountChangeHandler(float newVal)
    {
        UpdateCounter(newVal);
    }

    private void UpdateCounter<T>(T newVal)
    {
        _text.text = newVal.ToString();
    }
}