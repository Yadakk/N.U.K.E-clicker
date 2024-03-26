using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;
using static Bootstrap;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Resource _increaseResource;
    [SerializeField] private Resource _increaseBy;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        _increaseResource = AssetGetter<Resource>.GetAsset(Bundle, _increaseResource.name);
        _increaseBy = AssetGetter<Resource>.GetAsset(Bundle, _increaseBy.name);
    }

    public void OnClick()
    {
        _increaseResource.Amount += _increaseBy.Amount;
    }
}
