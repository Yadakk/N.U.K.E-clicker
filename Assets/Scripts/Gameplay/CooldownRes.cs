using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;
using static Bootstrap;

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
    private void OnDisable()
    {
        OnInitAll -= InitAllHandler;
    }
    private void InitAllHandler()
    {
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
