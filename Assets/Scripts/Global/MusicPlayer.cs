using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;
    private AudioSource _src;
    private AudioMixer _masterMixer;

    private void Awake()
    {
        _src = GetComponent<AudioSource>();
        StartCoroutine(PlayMusicCoroutine());
        _masterMixer = _src.outputAudioMixerGroup.audioMixer;
    }

    public void SetSound(float soundLevel)
    {
        _masterMixer.SetFloat("musicVol", Mathf.Lerp(-80, 0,soundLevel));
    }

    private IEnumerator PlayMusicCoroutine()
    {
        while (true)
        {
            AudioClip clip = null;
            List<AudioClip> clipsRemaining = _clips.ToList();
            if (clip != null) clipsRemaining.Remove(clip);

            while (clipsRemaining.Count > 0)
            {
                int clipIndex = Random.Range(0, clipsRemaining.Count);
                clip = clipsRemaining[clipIndex];
                clipsRemaining.Remove(clip);
                _src.clip = clip;
                _src.Play();
                yield return new WaitForSeconds(clip.length);
            }
        }
    }
}
