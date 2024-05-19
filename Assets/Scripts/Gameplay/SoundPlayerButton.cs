using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

[RequireComponent(typeof(Button))]
public class SoundPlayerButton : MonoBehaviour
{
    private AudioSource _source;
    [field: SerializeField] public List<AudioClip> Clips { get; set; }
    private Button _button;

    private void Start()
    {
        _source = GlobalSoundSource.AudioSource;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        AudioClip clipToPlay;
        if (Clips.Count > 1)
            clipToPlay = Clips[Random.Range(0, Clips.Count - 1)];
        else
            clipToPlay = Clips[0];
        _source.PlayOneShot(clipToPlay);
    }
}
