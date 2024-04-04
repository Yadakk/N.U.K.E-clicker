using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssetBundleLib;

public class Bootstrap : MonoBehaviour
{
    public static AssetBundle Bundle;

    private void Start()
    {
        Bundle ??= AssetBundle.LoadFromFile("Assets/AssetBundles/game");

        StartEnabler.Instance.EnableAll(true);
        Clicker.OnInitAll?.Invoke();
        AlphaHit.OnInitAll?.Invoke();
        Display.OnInitAll?.Invoke();
        ItemPlacer.OnInitAll?.Invoke();
        InfoDisplayer.OnInitAll?.Invoke();
        CooldownRes.OnInitAll?.Invoke();
        TabSwitch.OnInitAll?.Invoke();
        Timer.Init();
        TimerDisplay.OnInitAll?.Invoke();
        StartEnabler.Instance.EnableAll(false);
    }
}