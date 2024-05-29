using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class EventAdder : MonoBehaviour
{
    [SerializeField] private EventNotifier _eventNotifier;
    [SerializeField] private EventInformer _informer;
    [SerializeField] private Transform _eventFolder;
    [SerializeField] private Transform _eventMBFolder;
    [SerializeField] private Object _eventPrefab;
    [SerializeField] private float _minSeconds = 60f;
    [SerializeField] private float _maxSeconds = 120f;

    private IEnumerator Start()
    {
        List<EventData> events = _eventMBFolder.GetComponentsInChildren<EventMB>().Select(i => i.Data).ToList();
        if (events.Count == 0) yield break;
        while (true)
        {
            events = ListUtility.ShuffleWithoutRepetition(events);
            for (int i = 0; i < events.Count; i++)
            {
                yield return new WaitForSeconds(Random.Range(_minSeconds, _maxSeconds));
                var eventGO = Instantiate(_eventPrefab, _eventFolder) as GameObject;
                eventGO.GetComponent<EventHolder>().SetData(events[i]);
                var controller = eventGO.GetComponent<EventController>();
                controller.Informer = _informer;
                controller.Init();
                _eventNotifier.Notify();
            }
        }
    }
}
