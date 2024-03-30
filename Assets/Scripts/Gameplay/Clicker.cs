using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;
using static Bootstrap;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Resource _increaseResource;
    [SerializeField] private Resource _increaseBy;
    [SerializeField] private Resource _criticalChance;
    [SerializeField] private Resource _criticalBreads;
    [SerializeField] private Resource _breads;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        AssetUtility.GetFromBundle(Bundle, ref _increaseResource);
        AssetUtility.GetFromBundle(Bundle, ref _increaseBy);
        AssetUtility.GetFromBundle(Bundle, ref _criticalChance);
        AssetUtility.GetFromBundle(Bundle, ref _criticalBreads);
        AssetUtility.GetFromBundle(Bundle, ref _breads);
    }

    public void OnClick()
    {
        _increaseResource.Amount += _increaseBy.Amount;

        int roll = Random.Range(0, 100);
        if (roll < _criticalChance.Amount)
        {
            _increaseResource.Amount += _increaseBy.Amount;
            _breads.Amount += _criticalBreads.Amount;
        }
    }
}
