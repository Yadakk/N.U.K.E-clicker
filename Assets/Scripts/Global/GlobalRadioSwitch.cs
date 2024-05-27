using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Utilities.IntBoolParseUtility;

public class GlobalRadioSwitch : MonoBehaviour
{
    [SerializeField] private MusicPlayer _ambientPlayer;
    [SerializeField] private MusicPlayer _radioPlayer;
    private SoundPlayer _soundPlayer;
    public bool IsMuted { get; set; } = true;

    private void Start()
    {
        _soundPlayer = GetComponent<SoundPlayer>();
        OnAnyToggleSwitchedHandler(IntToBool(PlayerPrefs.GetInt(RadioToggle.PrefsKey)));
        RadioToggle.OnAnyToggleSwitched.AddListener(OnAnyToggleSwitchedHandler);
        IsMuted = false;
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
        if (!IsMuted && _soundPlayer != null) _soundPlayer.PlaySound(BoolToInt(!isOn));
    }
}