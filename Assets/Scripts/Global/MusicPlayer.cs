using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private bool _playOnStart;
    [SerializeField] private List<AudioClip> _clips;
    private AudioSource _source;
    private Coroutine _musicRoutine;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        if (_playOnStart) Play();
    }

    private IEnumerator MusicRoutine()
    {
        while (true)
        {
            for (int i = 0; i < _clips.Count; i++)
            {
                var clip = _clips[i];
                _source.clip = clip;
                _source.Play();
                yield return new WaitForSecondsRealtime(clip.length);
            }
            _clips = ListUtility.ShuffleWithoutRepetition(_clips);
        }
    }

    public void Stop()
    {
        if (_musicRoutine != null)
        {
            StopCoroutine(_musicRoutine);
            _source.Stop();
            _musicRoutine = null;
        }
    }

    public void Play()
    {
        if (_source.clip != null)
            _clips = ListUtility.ShuffleWithoutRepetition(_clips, _source.clip);
        else
            _clips = ListUtility.ShuffleWithoutRepetition(_clips);
        _musicRoutine = StartCoroutine(MusicRoutine());
    }
}