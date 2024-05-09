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
    private PrefabThrower _thrower;

    private void Start()
    {
        _thrower = GetComponent<PrefabThrower>();
        _thrower.enabled = false;
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

        if (_thrower != null) _thrower.Throw();
    }
}
