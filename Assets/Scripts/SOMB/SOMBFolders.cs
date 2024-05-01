using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMBFolders : MonoBehaviour
{
    public static SOMBFolders Instance;
    [SerializeField] private GameObject _resourcesFolder;
    [SerializeField] private GameObject _shopItemsFolder;
    [System.NonSerialized] public Resource[] Resources;
    [System.NonSerialized] public ShopItem[] ShopItems;

    private void Awake()
    {
        Instance = this;
        Resources = _resourcesFolder.GetComponentsInChildren<Resource>();
        ShopItems = _shopItemsFolder.GetComponentsInChildren<ShopItem>();
    }
}
