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
            affectedResource.Change = affectedResource.Change * affectedResource.Multiplier;
        }
    }
}

[System.Serializable]
public class AffectedResource
{
    public Resource Resource;
    public int Change;
    public int Multiplier = 1;
}