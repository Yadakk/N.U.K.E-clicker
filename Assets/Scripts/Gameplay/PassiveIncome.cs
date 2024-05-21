using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    [SerializeField] private Resource _resourceToIncrease;
    [SerializeField] private Resource _increaseBy;

    public delegate void OnInitAllDelegate();
    private void Start()
    {
        StartCoroutine(AddResCoroutine());
    }

    private IEnumerator AddResCoroutine()
    {
        while (true)
        {
            _resourceToIncrease.DisableFlash = true;
            _resourceToIncrease.Amount += _increaseBy.Amount;
            _resourceToIncrease.DisableFlash = false;
            yield return new WaitForSeconds(1);
        }
    }
}