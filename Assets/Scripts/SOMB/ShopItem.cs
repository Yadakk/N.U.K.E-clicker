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

    public void Buy()
    {
        foreach (var affectedResource in AffectedResources)
        {
            affectedResource.Resource.Amount += affectedResource.Change;
            affectedResource.Change = affectedResource.RoundChangeToInt ? Mathf.RoundToInt(NewChange(affectedResource)) : NewChange(affectedResource);
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