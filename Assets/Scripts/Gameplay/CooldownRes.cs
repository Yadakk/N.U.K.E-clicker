using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownRes : MonoBehaviour
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
            _resourceToIncrease.Amount += _increaseBy.Amount;
            yield return new WaitForSeconds(1);
        }
    }
}
