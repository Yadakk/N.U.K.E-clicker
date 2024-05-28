using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class ShopItemUpgradeRandom : ShopItem
{
    public List<ShopItem> ExcludedItems;
    public GameObject ShopItemFolder;
    public int AmountOfItemsToUpgradeRandomly;
    private List<ShopItem> _shopItems = new();

    private void Start()
    {
        _shopItems = ShopItemFolder.GetComponentsInChildren<ShopItem>().ToList();
        ExcludedItems.ForEach(item => _shopItems.Remove(item));
    }

    public override bool TryBuy()
    {
        if (!base.TryBuy()) return false;
        List<ShopItem> pickedItems = ListUtility.TakeRandom(_shopItems, AmountOfItemsToUpgradeRandomly).ToList();
        pickedItems.ForEach(item => item.LossLessUpgrade());
        return true;
    }
}
