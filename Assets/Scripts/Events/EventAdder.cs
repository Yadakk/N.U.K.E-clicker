using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Utilities;

public class EventAdder : MonoBehaviour
{
    [SerializeField] private Transform _eventFolder;
    [SerializeField] private Transform _eventMBFolder;
    [SerializeField] private Object _eventPrefab;
    [SerializeField] private float _minSeconds = 60f;
    [SerializeField] private float _maxSeconds = 120f;

    private IEnumerator Start()
    {
        List<EventMB> eventMBs = _eventMBFolder.GetComponentsInChildren<EventMB>().ToList();
        if (eventMBs.Count == 0) yield break;
        while (true)
        {
            eventMBs = ListUtility.ShuffleWithoutRepetition(eventMBs);
            for (int i = 0; i < eventMBs.Count; i++)
            {
                yield return new WaitForSeconds(Random.Range(_minSeconds, _maxSeconds));
                var eventGO = Instantiate(_eventPrefab, _eventFolder) as GameObject;
            }
        }
    }
}
