using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlobalSoundSource : MonoBehaviour
{
    public static AudioSource AudioSource { get; private set; }

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
}
