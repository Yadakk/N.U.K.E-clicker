using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemPlacer;

[CreateAssetMenu(fileName = "New ShopItem", menuName = "SO/ShopItem", order = 51)]
public class ShopItem : ScriptableObject
{
    public string Name;
    public string Desc;
    public int StartingCost;
    public float CostMultiplier;
    public Sprite Icon;
    public ItemShops Shop;
}
