using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventNotifier : MonoBehaviour
{
    public Transform EventFolder;
    public GameObject ExclamationMark;
    [SerializeField] private SoundPlayer _soundPlayer;
    private bool _hasEvents;

    public void Notify()
    {
        if (_soundPlayer != null) _soundPlayer.PlaySound();
    }

    private void Update()
    {
        if (_hasEvents == EventFolder.childCount > 0) return;
        _hasEvents = EventFolder.childCount > 0;
        ExclamationMark.SetActive(_hasEvents);
    }
}
