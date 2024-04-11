using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusicMixer : MonoBehaviour
{
    [SerializeField] private MusicPlayer _player;
    private Slider _slider;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(_player.SetSound);
    }
}
