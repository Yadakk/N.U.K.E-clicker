using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalRadioSwitch : MonoBehaviour
{
    [SerializeField] private MusicPlayer _ambientPlayer;
    [SerializeField] private MusicPlayer _radioPlayer;

    void Start()
    {
        RadioToggle.OnAnyToggleSwitched.AddListener(OnAnyToggleSwitchedHandler);
    }

    private void OnAnyToggleSwitchedHandler(bool isOn)
    {
        if (isOn)
        {
            _ambientPlayer.Stop();
            _radioPlayer.Play();
        }
        else
        {
            _ambientPlayer.Play();
            _radioPlayer.Stop();
        }
    }
}