using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] private Object _itemPrefab;
    [SerializeField] private ItemShops _shop;
    [SerializeField] private InfoDisplayer _infoDisplayer;

    private void Start()
    {
        var shopItems = SOMBFolders.Instance.ShopItems;

        foreach (var shopItem in shopItems)
        {
            if (shopItem.Shop == _shop)
            {
                Object instItem = Instantiate(_itemPrefab, transform);
                instItem.GetComponent<Image>().sprite = shopItem.Icon;
                Item itemComp = instItem.GetComponent<Item>();
                itemComp.ShopItem = shopItem;
                itemComp.InfoDisplayer = _infoDisplayer;
            }
        }
    }

    public enum ItemShops
    {
        Greed,
        Ego,
        Apathy,
    }
}
