using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;

public class CooldownRes : MonoBehaviour
{
    [SerializeField] private Resource _resourceToIncrease;
    [SerializeField] private Resource _increaseBy;

    public delegate void OnInitAllDelegate();
    public static OnInitAllDelegate OnInitAll;
    private void Awake()
    {
        OnInitAll += InitAllHandler;
    }
    private void InitAllHandler()
    {
        _resourceToIncrease = AssetGetter<Resource>.GetAsset(Bootstrap.Bundle, _resourceToIncrease.name);
        _increaseBy = AssetGetter<Resource>.GetAsset(Bootstrap.Bundle, _increaseBy.name);

        StartCoroutine(AddResCoroutine());
    }

    private IEnumerator AddResCoroutine()
    {
        while (true)
        {
            _resourceToIncrease.Amount += _increaseBy.Amount;
            yield return new WaitForSeconds(1);
        }
    }
}
