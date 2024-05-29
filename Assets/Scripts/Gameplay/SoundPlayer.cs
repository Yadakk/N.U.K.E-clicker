using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class SoundPlayer : MonoBehaviour
{
    [field: SerializeField] public List<AudioClip> Clips { get; set; }
    protected AudioSource _source;

    protected virtual void Start()
    {
        _source = GlobalSoundSource.AudioSource;
    }

    public void PlaySound()
    {
        if (Clips.Count == 0) return;
        AudioClip clipToPlay;
        if (Clips.Count > 1) clipToPlay = Clips[Random.Range(0, Clips.Count)];
        else clipToPlay = Clips[0];
        _source.PlayOneShot(clipToPlay);
    }

    public void PlaySound(int index)
    {
        if (Clips.Count == 0) return;
        if (_source == null) _source = GlobalSoundSource.AudioSource;
        _source.PlayOneShot(Clips[index]);
    }
}