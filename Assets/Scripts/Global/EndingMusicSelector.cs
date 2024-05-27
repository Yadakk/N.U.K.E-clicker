using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMusicSelector : MonoBehaviour
{
    public MusicPlayer GoodEndingMusicPlayer;
    public MusicPlayer BadEndingMusicPlayer;

    private void Start()
    {
        bool isBadEnding = IntersceneVariables.IsBadEnding;
        if (isBadEnding) BadEndingMusicPlayer.Play();
        else GoodEndingMusicPlayer.Play();
    }
}