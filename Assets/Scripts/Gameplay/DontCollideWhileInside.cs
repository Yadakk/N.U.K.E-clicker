using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCollideWhileInside : MonoBehaviour
{
    private int _insideTriggers;
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<PolygonCollider2D>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _insideTriggers++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _insideTriggers--;
        if (_insideTriggers == 0)
            _collider.isTrigger = false;
    }
}