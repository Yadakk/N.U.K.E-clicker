using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using static ItemPlacer;

public class ShopItem : MonoBehaviour
{
    public string Name;
    public string Desc;
    public Sprite Icon;
    public ItemShops Shop;
    public int BuysLeft = 0;
    public AffectedResource[] AffectedResources;
    public readonly UnityEvent OnLimitReached = new();
    private bool _isLimitReached;

    private void Start()
    {
        OnLimitReached.AddListener(() => _isLimitReached = true);
    }

    public virtual bool TryBuy()
    {
        if (_isLimitReached) return false;

        foreach (var affRes in AffectedResources)
        {
            if (!affRes.CanBuy()) return false;
        }

        foreach (var affRes in AffectedResources)
        {
            affRes.Buy();
        }

        DeductBuy();

        return true;
    }

    public void LossLessUpgrade()
    {
        if (_isLimitReached) return;

        foreach (var affRes in AffectedResources)
        {
            affRes.IncrementChange();
            if (!affRes.IsChangePositive()) return;
            affRes.ChangeLessBuy();
        }

        DeductBuy();
    }

    private void DeductBuy()
    {
        if (--BuysLeft == 0) OnLimitReached.Invoke();
    }
}

[System.Serializable]
public class AffectedResource
{
    public Resource Resource;
    [field: SerializeField] private float _change;
    public bool IsPercentChange;
    public float Multiplier = 1;
    public bool RoundChangeToInt;
    public bool HasMinimumResourceAmount;
    public float MinimumResourceAmount;
    public bool HasMaximumResourceAmount;
    public float MaximumResourceAmount;

    public float Change
    {
        get
        {
            float calculatedChange = _change;
            if (IsPercentChange) calculatedChange = Resource.Amount * _change / 100f;
            if (RoundChangeToInt) calculatedChange = Mathf.Round(calculatedChange);
            return calculatedChange;
        }
        set
        {
            _change = value;
            if (RoundChangeToInt) _change = Mathf.Round(_change);
        }
    }

    public bool CanBuy()
    {
        if (HasMinimumResourceAmount && Resource.Amount < MinimumResourceAmount ||
            HasMaximumResourceAmount && Resource.Amount > MaximumResourceAmount) return false;

        return Resource.Amount + Change >= Resource.MinLimit.Limit;
    }

    public void Buy()
    {
        ChangeLessBuy();
        IncrementChange();
    }

    public void IncrementChange()
    {
        _change *= Multiplier;
    }

    public void ChangeLessBuy()
    {
        Resource.Amount += Change;
    }

    public bool IsChangePositive()
    {
        return Resource.ResourcePositivity == Resource.Positivity.Positive && Change > 0 ||
               Resource.ResourcePositivity == Resource.Positivity.Negative && Change < 0;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        PositivityColorScheme scheme = PositivityColorSchemes.PositivityToColorScheme(Resource);
        PositivityColorSchemes.FormatNumber(ref stringBuilder, scheme, Change, Resource.IsPercentFormatted);
        stringBuilder.Append(" ");
        stringBuilder.Append(Resource.Name);

        if (IsPercentChange)
        {
            stringBuilder.Append(" (");
            PositivityColorSchemes.FormatNumber(ref stringBuilder, scheme, _change, true);
            stringBuilder.Append(")");
        }
        if (HasMinimumResourceAmount)
        {
            stringBuilder.AppendLine();
            stringBuilder.Append("Minimum required: ");
            stringBuilder.Append(MinimumResourceAmount);
            stringBuilder.Append(" ");
            stringBuilder.Append(Resource.Name);
        }
        if (HasMaximumResourceAmount)
        {
            stringBuilder.AppendLine();
            stringBuilder.Append("Maximum required: ");
            stringBuilder.Append(HasMinimumResourceAmount);
            stringBuilder.Append(" ");
            stringBuilder.Append(Resource.Name);
        }

        return stringBuilder.ToString();
    }
}