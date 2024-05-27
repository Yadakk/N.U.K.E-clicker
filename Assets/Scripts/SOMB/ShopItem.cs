using System.Collections;
using System.Collections.Generic;
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
            if (!(affRes.Resource.Amount + affRes.Change >= affRes.Resource.MinLimit.Limit))
            {
                return false;
            }
        }

        foreach (var affRes in AffectedResources)
        {
            affRes.Resource.Amount += affRes.Change;
            affRes.Change = affRes.RoundChangeToInt ? Mathf.Round(NewChange(affRes)) : NewChange(affRes);
        }

        return true;
    }

    public void LossLessUpgrade()
    {
        foreach (var affRes in AffectedResources)
        {
            affRes.Change = affRes.RoundChangeToInt ? Mathf.Round(NewChange(affRes)) : NewChange(affRes);
            if (affRes.Resource.ResourcePositivity == Resource.Positivity.Positive && affRes.Change < 0) break;
            if (affRes.Resource.ResourcePositivity == Resource.Positivity.Negative && affRes.Change > 0) break;
            affRes.Resource.Amount += affRes.Change;
        }
    }

    private static float NewChange(AffectedResource affectedResource)
    {
        return affectedResource.Change * affectedResource.Multiplier;
    }
}

[System.Serializable]
public class AffectedResource
{
    public Resource Resource;
    public float Change;
    public float Multiplier = 1;
    public bool RoundChangeToInt;
}