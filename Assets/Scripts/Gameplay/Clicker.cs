using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private Resource _increaseResource;
    [SerializeField] private Resource _increaseBy;
    [SerializeField] private Resource _criticalChance;
    [SerializeField] private Resource _criticalBreads;
    [SerializeField] private Resource _breads;
    [SerializeField] private PrefabThrower _capThrower;
    [SerializeField] private PrefabThrower _breadThrower;

    public void OnClick()
    {
        float roll = Random.Range(0, 100);
        if (roll < _criticalChance.Amount)
        {
            _increaseResource.Amount += _increaseBy.Amount * 3;
            _breads.Amount += _criticalBreads.Amount;
            _breadThrower.Throw();
        }
        else
        {
            _increaseResource.Amount += _increaseBy.Amount;
        }
        _capThrower.Throw();
    }
}
