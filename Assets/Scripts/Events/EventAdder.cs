using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAdder : MonoBehaviour
{
    [SerializeField] private Transform _eventFolder;
    [SerializeField] private Object _eventPrefab;
    [SerializeField] private float _minSeconds = 60f;
    [SerializeField] private float _maxSeconds = 120f;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSeconds, _maxSeconds));
            Instantiate(_eventPrefab, _eventFolder);
        }
    }
}
