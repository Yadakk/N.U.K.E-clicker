using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Resource))]
public class RandomiseResourceAmountAtStart : MonoBehaviour
{
    [SerializeField] private int _max;
    [SerializeField] private int _min;
    private Resource _resource;

    void Start()
    {
        _resource = GetComponent<Resource>();
        _resource.Amount = Random.Range(_min, _max);
    }
}
