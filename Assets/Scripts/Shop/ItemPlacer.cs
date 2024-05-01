using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssetBundleLib;
using Unity.VisualScripting;

public class ItemPlacer : MonoBehaviour
{
    [SerializeField] private Object _itemPrefab;
    [SerializeField] private ItemShops _shop;
    [SerializeField] private InfoDisplayer _infoDisplayer;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void OnDisable()
    {
        OnInitAll -= InitAllHandler;
    }
    private void InitAllHandler()
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
