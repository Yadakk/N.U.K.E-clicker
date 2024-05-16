using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string Name;

    [SerializeField] private float _amount;

    [field: SerializeField]
    public bool PercentFormatted { get; private set; }
    [field: SerializeField]
    public Positivity ResourcePositivity { get; private set; }

    public delegate void OnAmountChangeDelegate(float newVal);
    public event OnAmountChangeDelegate OnAmountChange;
    public float Amount
    {
        get { return _amount; }
        set
        {
            if (_amount == value) return;
            _amount = value;

            if (OnAmountChange != null)
                OnAmountChange(_amount);
        }
    }

    public Sprite Icon;

    public enum Positivity
    {
        Positive,
        Neutral,
        Negative,
    }
}