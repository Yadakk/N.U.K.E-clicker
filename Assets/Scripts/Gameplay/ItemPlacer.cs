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

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        var shopItems = AssetGetter<ShopItem>.GetAssets(Bootstrap.Bundle);

        foreach (var shopItem in shopItems)
        {
            if (shopItem.Shop == _shop)
            {
                Object instItem = Instantiate(_itemPrefab, transform);
                instItem.GetComponent<Image>().sprite = shopItem.Icon;
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
