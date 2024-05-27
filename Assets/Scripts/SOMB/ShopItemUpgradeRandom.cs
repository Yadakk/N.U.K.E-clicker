using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class ShopItemUpgradeRandom : ShopItem
{
    public GameObject ShopItemFolder;
    public int AmountOfItemsToUpgradeRandomly;
    private List<ShopItem> _shopItems = new();

    private void Start()
    {
        _shopItems = ShopItemFolder.GetComponentsInChildren<ShopItem>().ToList();
        _shopItems.Remove(this);
    }

    public override bool TryBuy()
    {
        if (!base.TryBuy()) return false;
        else
        {
            List<ShopItem> pickedItems = ListUtility.TakeRandom(_shopItems, AmountOfItemsToUpgradeRandomly).ToList();
            pickedItems.ForEach(item => item.LossLessUpgrade());
        }
        return true;
    }
}
