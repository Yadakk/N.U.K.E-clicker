using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using AssetBundleLib;
using static Bootstrap;

public class Display : MonoBehaviour
{
    [SerializeField] private Resource _resourceToDisplay;

    private Transform _icon;
    private Transform _value;

    private Image _image;
    private TextMeshProUGUI _text;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        _resourceToDisplay = AssetGetter<Resource>.GetAsset(Bundle, _resourceToDisplay.name);

        _icon = transform.GetChild(0);
        _value = transform.GetChild(1);

        _image = _icon.GetComponent<Image>();
        _text = _value.GetComponent<TextMeshProUGUI>();

        _image.sprite = _resourceToDisplay.Icon;
        _resourceToDisplay.OnAmountChange += AmountChangeHandler;

        UpdateCounter(_resourceToDisplay.Amount);
    }

    private void AmountChangeHandler(int newVal)
    {
        UpdateCounter(newVal);
    }

    private void UpdateCounter<T>(T newVal)
    {
        _text.text = newVal.ToString();
    }
}
