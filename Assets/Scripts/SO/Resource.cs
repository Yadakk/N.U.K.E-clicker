using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "SO/Resource", order = 52)]
public class Resource : ScriptableObject
{
    [field: SerializeField]
    private int _amount;

    public delegate void OnAmountChangeDelegate(int newVal);
    public event OnAmountChangeDelegate OnAmountChange;
    public int Amount
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
}