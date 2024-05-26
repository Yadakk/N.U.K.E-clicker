using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonsSetting : MonoBehaviour, IInitOnSceneLoad
{
    [SerializeField] private float _default = 0.75f;
    [SerializeField] private float _step = 0.1f;
    [SerializeField] private Vector2 _minMax = new(0f, 1f);
    public float Default { get => _default; }
    private PlusMinusButton[] _plusMinusButtons;
    public PlusMinusButton[] PlusMinusButtons { get => _plusMinusButtons; }
    private float _value;
    public float Value { get => _value; }
    public readonly UnityEvent<float> OnValueChanged = new();

    private void SetPrefs(float value)
    {
        PlayerPrefs.SetFloat(name, value);
    }

    private void Increment()
    {
        _value += _step;
        _value = Mathf.Clamp(_value, _minMax.x, _minMax.y);
        OnValueChanged.Invoke(Value);
    }

    private void Decrement()
    {
        _value -= _step;
        _value = Mathf.Clamp(_value, _minMax.x, _minMax.y);
        OnValueChanged.Invoke(Value);
    }

    private void OnSliderValueChangedHandler(float val)
    {
        PlayerPrefs.SetFloat(name, val);
    }

    public void OnSceneLoad()
    {
        OnValueChanged.AddListener(SetPrefs);
        _plusMinusButtons = GetComponentsInChildren<PlusMinusButton>();
        _value = PlayerPrefs.GetFloat(name, _default);

        foreach (var plusMinusButton in _plusMinusButtons)
        {
            plusMinusButton.GetButton();
            if (plusMinusButton.IsPlus)
                plusMinusButton.Button.onClick.AddListener(Increment);
            else
                plusMinusButton.Button.onClick.AddListener(Decrement);
        }
    }
}
