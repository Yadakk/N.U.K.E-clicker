using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class Resource : MonoBehaviour
{
    [field: SerializeField] public string Name { get; set; }
    [SerializeField] private float _amount;
    public float Amount
    {
        get { return _amount; }
        set
        {
            float oldAmount = _amount;
            if (_amount == value) return;
            _amount = value;
            if (!LimitHandler(MinLimit, false))
                LimitHandler(MaxLimit, true);
            OnAmountChange.Invoke(_amount, oldAmount);
        }
    }

    private bool LimitHandler(ResourceLimit limit, bool isUpper)
    {
        bool IsLimitReached() => isUpper ? _amount > limit.Limit : _amount < limit.Limit;
        float GetLimitOverflow() => _amount - limit.Limit;
        if (limit.HasLimit && IsLimitReached())
        {
            if (limit.ExchangedResource != null)
            {
                limit.ExchangedResource._amount += GetLimitOverflow();
                _amount -= GetLimitOverflow();
            }
            else if (limit.TriggersGameOverOnLimit && IsLimitReached())
            {
                SceneManager.LoadScene("GameOver");
                _amount = limit.Limit;
            }
            else _amount = limit.Limit;
            return true;
        }
        return false;
    }

    [field: SerializeField] public ResourceLimit MinLimit { get; set; }
    [field: SerializeField] public ResourceLimit MaxLimit { get; set; }
    [field: SerializeField] public bool IsPercentFormatted { get; set; }
    [field: SerializeField] public Positivity ResourcePositivity { get; set; }
    [field: SerializeField] public Sprite Icon { get; set; }
    public bool DisableFlash { get; set; } = false;
    public readonly UnityEvent<float, float> OnAmountChange = new();

    public enum Positivity
    {
        Positive,
        Neutral,
        Negative,
    }

    [Serializable] public class ResourceLimit
    {
        [field: SerializeField] public bool HasLimit { get; set; }
        [SerializeField] private float _limit;
        public float Limit 
        { 
            get
            {
                if (LimitControlledByResourceAmount != null) return LimitControlledByResourceAmount.Amount;
                return _limit; 
            } 
            set => _limit = value; 
        }

        [field: SerializeField] public Resource LimitControlledByResourceAmount { get; set; }
        [field: SerializeField] public bool TriggersGameOverOnLimit { get; set; }
        [field: SerializeField] public Resource ExchangedResource { get; set; }
    }
}