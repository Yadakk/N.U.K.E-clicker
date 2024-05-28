using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static ItemPlacer;

public class ShopItem : MonoBehaviour
{
    public string Name;
    public string Desc;
    public Sprite Icon;
    public ItemShops Shop;
    public AffectedResource[] AffectedResources;

    public virtual bool TryBuy()
    {
        foreach (var affRes in AffectedResources)
        {
            if (!affRes.CanBuy()) return false;
        }

        foreach (var affRes in AffectedResources)
        {
            affRes.Buy();
        }

        return true;
    }

    public void LossLessUpgrade()
    {
        foreach (var affRes in AffectedResources)
        {
            affRes.IncrementChange();
            if (!affRes.IsChangePositive()) return;
            affRes.ChangeLessBuy();
        }
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
        if (!IsPercentChange) return stringBuilder.ToString();
        stringBuilder.Append(" (");
        PositivityColorSchemes.FormatNumber(ref stringBuilder, scheme, _change, true);
        stringBuilder.Append(")");
        return stringBuilder.ToString();
    }
}