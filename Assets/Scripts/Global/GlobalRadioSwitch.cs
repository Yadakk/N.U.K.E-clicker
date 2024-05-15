using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.VisualScripting.Member;
using static Utilities.IntBoolParseUtility;

public class GlobalRadioSwitch : MonoBehaviour
{
    [SerializeField] private MusicPlayer _ambientPlayer;
    [SerializeField] private MusicPlayer _radioPlayer;

    private void Start()
    {
        OnAnyToggleSwitchedHandler(IntToBool(PlayerPrefs.GetInt(RadioToggle.PrefsKey)));
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