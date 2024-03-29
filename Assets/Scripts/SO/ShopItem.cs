using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemPlacer;
using static Bootstrap;
using AssetBundleLib;

[CreateAssetMenu(fileName = "New ShopItem", menuName = "SO/ShopItem", order = 51)]
public class ShopItem : ScriptableObject
{
    public string Name;
    public string Desc;
    public Sprite Icon;
    public ItemShops Shop;
    public AffectedResource[] AffectedResources;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        foreach (var affectedResource in AffectedResources)
        {
            AssetUtility.GetFromBundle(Bundle, ref affectedResource.Resource);
        }
    }

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